using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForAnimations : MonoBehaviour {

	public void DisableErrorNotification(){
		MainScene_GameManager.Instance.NameAnimator.SetBool ("Error", false);
		MainScene_GameManager.Instance.PassAnimator.SetBool ("Error", false);
	}
}
