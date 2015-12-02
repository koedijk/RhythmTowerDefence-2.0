using UnityEngine;
using System.Collections;

public class NoteBehaviour : MonoBehaviour {
	public float scrollSpeed;
	private bool Detected = false;
	// Update is called once per frame
	void Update () {
		//Beweging aan de hand van "scrollSpeed"
		transform.position -= new Vector3 (scrollSpeed * Time.deltaTime, 0.0f, 0.0f);

		//Als dit object buiten het scherm is wordt deze verwijderd
		if (this.transform.position.x <= -3) {
		 Destroy(this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D noteDetect){
		if(noteDetect.gameObject.tag == "Note")
		{	
			if(Input.GetKeyDown(KeyCode.Space)){
				Destroy(this.gameObject);
			}
		
		}
		else{
			Detected = false;
		}

	
	}


}
