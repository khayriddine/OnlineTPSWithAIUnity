using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoginPlayer : MonoBehaviour {

	[SerializeField] GameObject pseudoText;
	[SerializeField] GameObject pseudoPass;
	[SerializeField] MainSceneEventHandler MainEventHandler;

	[HideInInspector] public string MapName;
	[HideInInspector] public string CharacterColor;


	string name;
	string pass;
	bool isReady;
	int indexCharacter,indexMap;


	public string Name{ get{ 
			name = "";
			if (pseudoText != null)
				name = pseudoText.GetComponentInChildren<Text> ().text;
			return name; }
	}
	public string Pass{ get{ 
			pass = "";
			if (pseudoPass != null)
				pass = pseudoPass.GetComponentInChildren<Text> ().text;
			return pass; }
	}
	// Use this for initialization
	void Start () {
		MapName = "Dust 2";
		CharacterColor = "blue";
		indexCharacter = 0;
		indexMap = 0;


	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (Name);
	}
	public void NextCharacter(){
		indexCharacter++;
		indexCharacter %= 6;
		CharacterColor =  MainScene_GameManager.Instance.characters [indexCharacter];
		MainEventHandler.CallMyCharacterColorChanged (CharacterColor);

	}
	public void PrevCharacter(){
		indexCharacter--;
		if (indexCharacter < 0)
			indexCharacter = 5;
		CharacterColor =  MainScene_GameManager.Instance.characters [indexCharacter];
		MainEventHandler.CallMyCharacterColorChanged (CharacterColor);

	}
	public void NextMap(){
		indexMap++;
		indexMap %= 3;
		MapName =  MainScene_GameManager.Instance.maps [indexMap];
		MainEventHandler.CallMyMapChanged (MapName);

	}
	public void PrevMap(){
		indexMap--;
		if (indexMap < 0)
			indexMap = 2;
		MapName =  MainScene_GameManager.Instance.maps [indexMap];
		MainEventHandler.CallMyMapChanged (MapName);

	}
	public void Play(){
		if (String.IsNullOrEmpty(Name)) {
			MainScene_GameManager.Instance.NameAnimator.SetBool ("Error", true);

		}
		if (String.IsNullOrEmpty (Pass)) {
				MainScene_GameManager.Instance.PassAnimator.SetBool ("Error", true);
		}
		if(!Pass.Equals("123")){
			MainScene_GameManager.Instance.NameAnimator.SetBool ("Error", true);
		}

		if(!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Pass) && Pass.Equals("123"))
			SceneManager.LoadScene(MapName, LoadSceneMode.Single);

	}


}
