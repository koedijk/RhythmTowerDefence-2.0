using UnityEngine;
using System.Collections;

public class SpawnNewWave : MonoBehaviour {
	public GameObject[] obj;
	private float SpawnRateMin = 3;
	private float SpawnRateMax = 5;
	public float newSpawnRate;

	private int waveIndex = 0;
	private int spawnNew = 0;

	public void Spawn()
	{
		waveIndex+= 3;
		         

		for (int i = 0; i < waveIndex; i++) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], this.transform.position, Quaternion.identity);
			//spawnNew--;
		}
	//	Invoke("Spawn", newSpawnRate);
	}
}
