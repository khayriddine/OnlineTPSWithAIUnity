using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public SocketIOComponent socket;
	//static elemnts
	public string[] colors = new string[]{"blue","red","yellow","green","white","purple"};
	public string[] maps = new string[]{"Dust 2","Nuke","Italy"};
	[SerializeField] Texture[] charactersIcon;
	[SerializeField] Material[] charactersMaterial;
	[SerializeField] GameObject PlayerModel;
	[SerializeField] GameObject ChatContent;
	[SerializeField] GameObject prefabText;
	PlayerEventHandler PlayerEvent;
	public GameObject CharacterModel;
	public Dictionary<string,string> CurrentPlayer;
	//variable elemnts
	[SerializeField] GameObject playerIcon;

	public List<Dictionary<string,string>> allOtherClients;
	public List<GameObject> allOtherCharacters;
	public CharacterEventHandler characterEvent;
	GameObject playerObj;
	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else {
			Destroy (gameObject);
		}


	}

	void OnEnable(){
		PlayerEvent = GetComponent<PlayerEventHandler> ();
		PlayerEvent.SendMsgEvent += PlayerSendMessage;
		//characterEvent = gameObject.GetComponent<CharacterEventHandler> ();
		//subscribe to events: 
		CurrentPlayer = new Dictionary<string, string>();
		CurrentPlayer ["color"] = DataToBeSaved.Instance.color;
		CurrentPlayer ["map"] = DataToBeSaved.Instance.mapName;
		CurrentPlayer ["pseudo"] = DataToBeSaved.Instance.pseudo;
		Transform spawn = GameObject.FindWithTag (CurrentPlayer ["color"]).transform;
		playerObj = GameObject.Instantiate (PlayerModel, spawn.position, spawn.rotation);
		JSONObject json = new JSONObject (CurrentPlayer);
		//Instance.socket.Emit ("newClient",json);
		StartCoroutine (JoinTheGame (json));

		//creation of new client


	}

	void OnDisable(){
		PlayerEvent.SendMsgEvent -= PlayerSendMessage;
	}
	// Use this for initialization
	void Start () {
		
		//StartCoroutine (JoinTheGame (json));

		allOtherClients = new List<Dictionary<string, string>> ();
		allOtherCharacters = new List<GameObject>();
		Instance.socket.On ("ancientClients", AddAncientsClients);
		Instance.socket.On ("new player connected", OnNewPlayerConnected);
		Instance.socket.On ("broadcastMsg", OnMsgReceived);
		Instance.socket.On ("userDisconnect", OnPlayerDisconnect);
	}
	// Update is called once per frame
	void Update () {

	}
	IEnumerator JoinTheGame(JSONObject json){
		yield return new WaitForSeconds (.5f);
		Instance.socket.Emit ("newClient",json);

	}
	public void DisplayMsgOnScreen(string msg,string color){

		GameObject textObj = Instantiate (prefabText, ChatContent.transform);
		textObj.GetComponent<Text> ().text = msg ;
		textObj.GetComponent<Text> ().color = GetPlayerColor(color);
	}

	public Color GetPlayerColor(string color){
		Color c = new Color ();

		switch (color) {
		case "blue" : c  = Color.blue;
			break;
		case "red" : c  = Color.red;
			break;
		case "yellow" : c  = Color.yellow;
			break;
		case "green" : c  = Color.green;
			break;
		case "white" : c  = Color.white;
			break;
		case "purple" : c  = Color.magenta;
			break;
		}

		return c;
	}
	void OnMsgReceived(SocketIOEvent e){
		Dictionary<string,string> dict = e.data.ToDictionary ();
		DisplayMsgOnScreen (dict ["msg"], dict ["color"]);
	}
	void OnPlayerDisconnect(SocketIOEvent e){
		
		Dictionary<string,string> disconnectedClient = e.data.ToDictionary ();
		Debug.Log (disconnectedClient ["pseudo"] + " is disconnected !");
		allOtherClients.Remove (disconnectedClient);
		GameObject disconnectedCharacter = GameObject.Find(disconnectedClient["pseudo"]);
		allOtherCharacters.Remove (disconnectedCharacter);
		Destroy (disconnectedCharacter);
				
	}

	void AddAncientsClients(SocketIOEvent e){
		Dictionary<string,string> ancientClient = e.data.ToDictionary ();
		allOtherClients.Add (ancientClient);

		Transform spawn = GameObject.FindWithTag (ancientClient ["color"]).transform;
		GameObject ancientCharacter = GameObject.Instantiate (GameManager.Instance.CharacterModel, spawn.position, spawn.rotation);
		ancientCharacter.GetComponent<Character> ().Create (ancientClient);
		ancientCharacter.transform.GetChild(1).GetComponent<Renderer> ().material = charactersMaterial [Find (colors, ancientClient["color"])];
		allOtherCharacters.Add (ancientCharacter);
	}

	void OnNewPlayerConnected(SocketIOEvent e){
		Dictionary<string,string> newClient = e.data.ToDictionary ();
		allOtherClients.Add (newClient);

		Transform spawn = GameObject.FindWithTag (newClient ["color"]).transform;
		GameObject newCharacter = GameObject.Instantiate (GameManager.Instance.CharacterModel, spawn.position, spawn.rotation);
		newCharacter.GetComponent<Character> ().Create (newClient);
		allOtherCharacters.Add (newCharacter);
		newCharacter.transform.GetChild(1).GetComponent<Renderer> ().material = charactersMaterial [Find (colors, newClient["color"])];
			//.GetComponentInChildren<Renderer> ().material = charactersMaterial [Find (colors, client["color"])];
		Debug.Log(newClient["pseudo"] + " is connected , on "+ newClient["color"] + " team");


		//Instance.socket.Emit ("ancientClient",new JSONObject(playerObj.GetComponent<Character>().dict));
	}

	public void UpdateSkinCharacter(string color, GameObject mesh){
		mesh.GetComponent<Renderer> ().material = charactersMaterial [Find (colors, color)];
		playerIcon.GetComponent<RawImage>().texture = charactersIcon[Find (colors, color)];

	}

	public void PlayerSendMessage(string msg){
		Dictionary<string,string> json = new  Dictionary<string,string> ();
		json ["msg"] = msg;
		Instance.socket.Emit ("chat",new JSONObject(json));
	}

	int Find(string[] array,string word){
		int i;
		for(i=0;i<array.Length;i++) {
			if (array [i].Equals (word))
				return i;
		}
		return -1;
	}

}
