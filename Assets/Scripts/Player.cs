using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	public Character character;


	Vector3 lastPos;
	Quaternion lastRot;


	// Use this for initialization
	void OnEnable () {
		character = gameObject.GetComponent<Character> ();
		CreateCharacter ();

	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Vector3.Distance(lastPos,Position)>.05f) {
			lastPos = Position;
			Debug.Log (Position);
		}
		if (!lastRot.Equals( Rotation)) {
			lastRot = Rotation;
			Debug.Log (Rotation);
		}
		*/
	}


	public void CreateCharacter(){
		

		character.Create (DataToBeSaved.Instance.pseudo, DataToBeSaved.Instance.color);

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
