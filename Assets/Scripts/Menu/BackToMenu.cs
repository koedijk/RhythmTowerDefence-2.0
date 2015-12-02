using UnityEngine;
using System.Collections;

public class BackToMenu: MonoBehaviour {
	
	public void ChangeScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
