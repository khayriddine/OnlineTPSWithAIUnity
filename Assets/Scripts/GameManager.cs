using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public string[] colors = new string[]{"blue","red","yellow","green","white","purple"};
	public string[] maps = new string[]{"Dust 2","Nuke","Italy"};

	public Material[] materials;
	public List<Dictionary<string,string>> allOtherClients;

	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void OnEnable(){
		Dictionary<string,string> newClient = new Dictionary<string, string>();
		newClient ["color"] = DataToBeSaved.Instance.color;
		newClient ["map"] = DataToBeSaved.Instance.mapName;
		newClient ["pseudo"] = DataToBeSaved.Instance.pseudo;
		DataToBeSaved.Instance.socket.Emit ("newClient",new JSONObject(newClient));
	}
	// Use this for initialization
	void Start () {
		allOtherClients = new List<Dictionary<string, string>> ();
		DataToBeSaved.Instance.socket.On ("new player connected", OnNewPlayerConnected);
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	void OnNewPlayerConnected(SocketIOEvent e){
		Dictionary<string,string> client = e.data.ToDictionary ();
		allOtherClients.Add (client);
		Debug.Log(client["pseudo"] + " is connected , on "+ client["color"] + "team");
	}
}
