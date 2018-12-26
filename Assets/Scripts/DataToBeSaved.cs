using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class DataToBeSaved : MonoBehaviour {

	public static DataToBeSaved Instance;
	public SocketIOComponent socket;
	//public LoginPlayer player;//{get{return MainScene_GameManager.Instance.transform.root.GetComponent<LoginPlayer> ();}}
	public string color;
	public string pseudo;
	public string mapName;

	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if(Instance != this) {
			Destroy (gameObject);
		}
	}


	void Start(){
		

	}

	IEnumerator ConnectToServer(){
		yield return new WaitForSeconds (.5f);
		socket.Emit ("player connected");
	}

	public void JoinTheGame(){
		socket.Emit ("player connected");
		//StartCoroutine (ConnectToServer ());
	}



}
