using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneEventHandler : MonoBehaviour {

	public delegate void PlayerLoginEventHandler(string choice);
	public event PlayerLoginEventHandler CharacterColorChangedEvent;
	public event PlayerLoginEventHandler MapChangedEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CallMyCharacterColorChanged(string color){
		if (CharacterColorChangedEvent != null) {
			CharacterColorChangedEvent (color);
		}
	}
	public void CallMyMapChanged(string map){
		if (MapChangedEvent != null) {
			MapChangedEvent (map);
		}
	}
}
