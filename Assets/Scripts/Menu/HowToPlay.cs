using UnityEngine;
using System.Collections;

public class HowToPlay: MonoBehaviour {
	
	public void ChangeScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}