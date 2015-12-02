using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] obj;
	[SerializeField]
	public float SpawnRateMin = 2; //Minimaal aantal seconden die de spawner moet wachten voordat er een nieuw object wordt gespawnd
	[SerializeField]
	public float SpawnRateMax = 2; //Maximaal aantal seconden die de spawner moet wachten voordat er een nieuw object wordt gespawnd

	// Use this for initialization
	void Start () {
		Spawn (); //Voert functie Spawn uit
	}
	
	void Spawn()
	{
		Instantiate(obj[Random.Range (0, obj.GetLength(0))], this.transform.position, Quaternion.identity); //Spawnt 1 van de objecten in de array "obj" op de plaats van de spawner

		Invoke ("Spawn", Random.Range (SpawnRateMin, SpawnRateMax)); //Voert deze functie opnieuw uit met de gegeven parameters, in dit geval blijven die altijd hetzelfde.
		//BPS1 is minimum random BPS, BPS2 is maximum random BPS, deze moet nog omgebouwd worden naar 1 constante snelheid afhankelijk van welk punt in het nummer wordt afgespeeld
	}
}
