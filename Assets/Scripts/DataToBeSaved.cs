using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataToBeSaved : MonoBehaviour {

	public static DataToBeSaved Instance;

	LoginPlayer player{get{return MainScene_GameManager.Instance.transform.root.GetComponent<LoginPlayer> ();}}

	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if(Instance != this) {
			Destroy (gameObject);
		}
	}

}
