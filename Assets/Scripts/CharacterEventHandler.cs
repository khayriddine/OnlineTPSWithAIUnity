using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventHandler : MonoBehaviour {


	public delegate void CharacterSkinEventHandler(string color,GameObject mesh);



	public event CharacterSkinEventHandler UpdateCharacterSkinEvent;


	public void CallUpdateCharacterSkinEvent(string color,GameObject mesh){
		if (UpdateCharacterSkinEvent != null) {
			UpdateCharacterSkinEvent (color,mesh);
		}
		else
			Debug.Log ("moch");
	}



}
