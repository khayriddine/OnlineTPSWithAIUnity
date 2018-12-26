using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class MainScene_GameManager : MonoBehaviour {

	public static MainScene_GameManager Instance;
	[SerializeField] MainSceneEventHandler MainEventHandler;
	[SerializeField] GameObject characterIcon;
	[SerializeField] Material[] characterMaterials;
	[SerializeField] Sprite[] characterIcons;
	[SerializeField] Sprite[] mapImages;
	[SerializeField] GameObject MapImage;//currentMap
	[SerializeField] GameObject CurrentMapName;
	[SerializeField] GameObject currentMap;
	[SerializeField] GameObject[] mapsModel;
	[SerializeField] Transform[] cameraTransforms;
	[SerializeField] Vector3[] CharacterPlaces;
	[SerializeField] GameObject CharacterPlaceHolder;
	[SerializeField] GameObject MainCam;

	public Animator NameAnimator;
	public Animator PassAnimator;
	public string[] characters = new string[]{"blue","red","yellow","green","white","purple"};
	public string[] maps = new string[]{"Dust 2","Nuke","Italy"};

	void Awake(){
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this)
			Destroy (gameObject);
	}
	void OnEnable(){
		MainEventHandler.CharacterColorChangedEvent += ChangeCharacterIcon;//
		MainEventHandler.CharacterColorChangedEvent += ChangeCharacterModel;

		MainEventHandler.MapChangedEvent += ChangeMapImage;//
		MainEventHandler.MapChangedEvent += ChangeMapModel;
	}

	void OnDisable(){
		MainEventHandler.CharacterColorChangedEvent -= ChangeCharacterIcon;
		MainEventHandler.CharacterColorChangedEvent -= ChangeCharacterModel;

		MainEventHandler.MapChangedEvent += ChangeMapImage;//
		MainEventHandler.MapChangedEvent += ChangeMapModel;
	}
	// Use this for initialization
	void Start () {
		currentMap = mapsModel [0];
		// disable all maps model except for dust 2
		for (int i = 1; i < mapsModel.Length; i++)
			mapsModel [i].SetActive (false);
		currentMap.SetActive (true);
		CharacterPlaceHolder.transform.position = CharacterPlaces [0];
		MainCam.transform.SetPositionAndRotation(cameraTransforms [0].position,cameraTransforms [0].rotation);
		MapImage.GetComponent<Image> ().sprite = mapImages [0];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	int Find(string[] array,string word){
		int i;
		for(i=0;i<array.Length;i++) {
			if (array [i].Equals (word))
				return i;
		}
		return -1;
	}
	public void ChangeCharacterIcon(string characterColor){
		int index = Find (characters, characterColor);
		try{
			
			characterIcon.GetComponent<Image> ().sprite = characterIcons [index];

		}
		catch(Exception e){
			Debug.LogError ("Make sure you placed an exisiting color - ("+index +") "+ e);
		}
			
	}
	public void ChangeCharacterModel(string characterColor){
		int index = Find (characters, characterColor);
		try{

			CharacterPlaceHolder.GetComponentInChildren<Renderer>().material = characterMaterials [index];
		}
		catch(Exception e){
			Debug.LogError ("Texture prob - ("+index +") "+ e);
		}

	}
	public void ChangeMapImage(string mapName){
		int index = Find (maps, mapName);
		try{
			MapImage.GetComponent<Image> ().sprite = mapImages [index];
			CurrentMapName.GetComponent<Text>().text = maps[index];
		}
		catch(Exception e){
			Debug.LogError ("Make sure you placed an exisiting map name - ("+index +") "+ e);
		}

	}
	public void ChangeMapModel(string mapName){
		int index = Find (maps, mapName);
		try{
			currentMap.SetActive(false);
			currentMap = mapsModel[index];
			currentMap.SetActive(true);
			MainCam.transform.SetPositionAndRotation(cameraTransforms [index].position,cameraTransforms [index].rotation);
			CharacterPlaceHolder.transform.position = CharacterPlaces[index];

		}
		catch(Exception e){
			Debug.LogError ("Texture prob - ("+index +") "+ e);
		}

	}


}
