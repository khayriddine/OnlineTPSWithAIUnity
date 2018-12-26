using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {


	public int Health;
	public string color;
	public string pseudo;

	[SerializeField] GameObject playerMesh;


	public Vector3 Position{
		get{
			return transform.position;
		}
	}
	public Quaternion Rotation{
		get{
			return transform.rotation;
		}
	}

	Vector3 lastPos;
	Quaternion lastRot;

	[SerializeField] GameManager gameManager;

	// Use this for initialization
	void Start () {
		lastPos = transform.position;
		lastRot = transform.rotation;
		//LoginPlayer player = DataToBeSaved.Instance.player;
		color = DataToBeSaved.Instance.color;
		playerMesh.GetComponent<Renderer> ().material = gameManager.materials [Find (gameManager.colors, color)];
		//color = player.CharacterColor;
		pseudo = DataToBeSaved.Instance.name;
		Health = 100;

	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(lastPos,Position)>.05f) {
			lastPos = Position;
			Debug.Log (Position);
		}
		if (!lastRot.Equals( Rotation)) {
			lastRot = Rotation;
			Debug.Log (Rotation);
		}
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
