using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	[SerializeField] GameObject Mesh;

	int health;
	int armor;
	Vector3 position;
	Quaternion rotation;
	int ammo;
	int ammoInClip;
	int money;
	Animator anim;

	public string pseudo;
	public string color;
	public GameObject m_Character;
	public Dictionary<string,string> dict;

	/*
	public GameObject Create(Dictionary<string,string> client){
		dict = client;
		pseudo = client ["pseudo"];
		color = client ["color"];
		Transform spawn = GameObject.FindWithTag (client ["color"]).transform;
		if(m_Character == null)
		m_Character = GameObject.Instantiate (GameManager.Instance.CharacterModel, spawn.position, spawn.rotation);

		//Debug.Log (client ["pseudo"] + "  " + pseudo);
		return m_Character;
	}*/
	public void Create(Dictionary<string,string> client){
		dict = client;
		pseudo = client ["pseudo"];
		color = client ["color"];
		m_Character = gameObject;
		m_Character.name = pseudo;
	}



	int Find(string[] array,string word){
		int i;
		for(i=0;i<array.Length;i++) {
			if (array [i].Equals (word))
				return i;
		}
		return -1;
	}

	public void Create(string p, string c){
		dict = new Dictionary<string, string> ();
		dict ["pseudo"] = p;
		dict ["color"] = c;
		gameObject.name = p;
		pseudo = p;
		color = c;

		if (!color.Equals ("blue")) {
			
			GameManager.Instance.UpdateSkinCharacter (color,Mesh);
		}
	}



}
