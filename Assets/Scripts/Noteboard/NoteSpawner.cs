using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

	public GameObject[] obj;
	[SerializeField]
	private float BPM1 = 180; //BPM nummer 1
	[SerializeField]
	private float BPM2 = 200; //BPM nummer 2

	[SerializeField]
	private float BPS1; 
	[SerializeField]
	private float BPS2; 

	// Use this for initialization
	void Start () {
		Spawn (); //Voert functie Spawn uit
		BPS1 = BPM1 / 60 / 5; //Rekent het BPS uit voor BPS1, 180 / 60 = 3 / 5 = 0.6 in dit geval, Er worden dus minimaal 0.6 Notes per seconde gespawnd
		BPS2 = BPM2 / 60 / 5; //Rekent het BPS uit voor BPS2, 200 / 60 = 3.333... / 5 = 0.6 in dit geval, Er worden dus maximaal 0.666... Notes per seconde gespawnd 
	}
	
	void Spawn()
	{
		Instantiate(obj[Random.Range (0, obj.GetLength(0))], this.transform.position, Quaternion.identity); //Spawnt 1 van de objecten in de array "obj" op de plaats van de spawner

		Invoke ("Spawn", Random.Range (BPS1, BPS2)); //Voert deze functie opnieuw uit met de gegeven parameters, in dit geval blijven die altijd hetzelfde.
		//BPS1 is minimum random BPS, BPS2 is maximum random BPS, deze moet nog omgebouwd worden naar 1 constante snelheid afhankelijk van welk punt in het nummer wordt afgespeeld
	}
}
