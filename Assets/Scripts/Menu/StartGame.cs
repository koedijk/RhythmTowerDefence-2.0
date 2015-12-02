using UnityEngine;
using System.Collections;

public class StartGame: MonoBehaviour {
	
	public void ChangeScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
