using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Cameras{
	public class CameraEventHandler : MonoBehaviour {

		public delegate  void CameraAssignEventHandler(Transform Transform);

		public event CameraAssignEventHandler EventAssignCamera;

		public void CallEventAssignCamera(Transform tr){
			if (EventAssignCamera != null) {
				EventAssignCamera (tr);
			}
		}
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}
	}

}