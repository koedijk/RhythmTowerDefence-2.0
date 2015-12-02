using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	
	private SpriteRenderer spriteRenderer;
	private int tempCoins;
	private Camera camera;
	public bool open = false;
	public GameObject panel;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown()
	{
			Debug.Log("hey");
			if (!open)
			{
				panel.SetActive(true);
				open = true;
			}
			else { 
				if (open) 
				{
					panel.SetActive(false);
					open = false;
				} 
			}
	}
}
