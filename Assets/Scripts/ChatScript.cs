using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using System;


public class ChatScript : MonoBehaviour {
	[SerializeField] InputField MsgText;
	PlayerEventHandler playerEvent;
	void OnEnable(){
		playerEvent = GetComponent<PlayerEventHandler> ();
		playerEvent.SendMsgEvent += DisplayMyMsgOnScreen;
	}

	void OnDisable(){
		playerEvent.SendMsgEvent -= DisplayMyMsgOnScreen;
	}
	void Start(){
		MsgText.DeactivateInputField ();
	}
	void Update(){
		if (MsgText.isFocused) {
			GameObject.FindWithTag ("Player").GetComponent<ThirdPersonUserControlCustomized> ().enabled = false;
		}
		else
			GameObject.FindWithTag ("Player").GetComponent<ThirdPersonUserControlCustomized> ().enabled = true;
		if (Input.GetKey (KeyCode.Return)) {
			if (MsgText.isFocused) {
				MsgText.ActivateInputField ();
				string msg = MsgText.GetComponentInChildren<Text> ().text;
				playerEvent.CallSendMsgEvent (msg);
				MsgText.DeactivateInputField ();
				MsgText.gameObject.SetActive(false);

			}
		}else {
			MsgText.gameObject.SetActive(true);
		}

	}
	string ConvertMsg(string msg){
		string msgToDisplay;
		if (msg.Substring (0, 2).Equals ("/a")) {
			msgToDisplay = String.Concat( "[ ALL ]" ,msg.Substring (3, msg.Length - 3));
		} 
		else if(msg[0] == '/'){
			msgToDisplay = "[ "+msg.Substring(1,1)+" ]" + msg.Substring (3, msg.Length - 3);
		}
		else
			msgToDisplay =  msg;

		return msgToDisplay;
	}

	public void DisplayMyMsgOnScreen(string msg){
		GameManager.Instance.DisplayMsgOnScreen (ConvertMsg (msg),GameManager.Instance.CurrentPlayer ["color"]);
	}





}
