using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonClasses : MonoBehaviour {


	[Serializable]
	public class ClientJSON
	{
		public string pseudo;
		public string color;
		public float[] position;
		public float[] rotation;
		public int health;
		/*
		public static ClientJSON CreateFromJSON(string pseudo,string color,List<GameObject>ms)
		{
			ClientJSON c = JsonUtility.FromJson<ClientJSON>(data);
			if (!c.name.Equals(cpn))
			{
				foreach(GameObject m in ms){
					if (m.transform.transform.name.ToString().Equals(c.modelKey)) {
						c.player = GameObject.Instantiate(m, new Vector3(c.position[0],c.position[1],c.position[2]), Quaternion.identity);
						break;
					}
				}

			}
			return c;
		}*/
		public static ClientJSON CreateFromJSON(string data)
		{
			return JsonUtility.FromJson<ClientJSON>(data);
		}
	}
}
