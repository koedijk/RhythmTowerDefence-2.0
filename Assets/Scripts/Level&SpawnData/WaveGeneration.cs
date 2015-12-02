using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyType
{
	Crab,
	Snapper,
	Squid,
	Wheel,
	NoneType
}

public class WaveGeneration : MonoBehaviour {

	private int waveIndex;					//Op welke wave zitten we nu?
	private float enemyAmount;				//Hoeveel enemies komen er in deze wave?
	private float roundedEnemyAmount;		//Dit is de afgeronde enemyAmount
	private float enemyAmountBalanceMultiplier; //Dit is een multiplier die gebruikt wordt om het aantal enemies die moeten komen te berekenen
	private float enemyAmountBalanceAddition;	//Dit is een multiplier die gebruikt wordt om het aantal enemies die moeten komen te berekenen
	private int typeAmount;					//Hoeveel types mogen aan deze wave meedoen?
	private int[] typeParticipants;			//Welke types mogen aan deze wave meedoen?
	private float newWaveTimer;				//Timer die, als hij op 0 is, de nieuwe wave laat starten

	private int environmentState; 			//De Background veranderd na een bepaald aantal waves
	private bool crabUnlock = true;			//Is Crab unlocked(Is altijd unlocked)
	private bool snapperUnlock = false;		//Is Snapper unlocked?
	private bool squidUnlock = false;		//Is Squid unlocked?
	private bool wheelUnlock = false;		//Is Wheel unlocked?

	private float spawnList1;				//Hoeveel entities van de hele wave gaat Spawner 1 spawnen?
	private float spawnList2;				//Hoeveel entities van de hele wave gaat Spawner 2 spawnen?
	private float spawnList3;				//Hoeveel entities van de hele wave gaat Spawner 3 spawnen?

	private float spawnAsCrab;				//Hoeveel entities moeten als Crab gespawnd worden in de volgende wave?
	private float spawnAsSnapper;			//Hoeveel entities moeten als Snapper gespawnd worden in de volgende wave?
	private float spawnAsSquid;				//Hoeveel entities moeten als Squid gespawnd worden in de volgende wave?
	private float spawnAsWheel;				//Hoeveel entities moeten als Wheel gespawnd worden in de volgende wave?

	private float crabsToSpawnLeft;
	private float snapperToSpawnLeft;
	private float squidToSpawnLeft;
	private float wheelToSpawnLeft;

	List<GameObject> spawner1List = new List<GameObject>();		//Dit is de uiteindendelijke list die Spawner 1 meekrijgt
	List<GameObject> spawner2List = new List<GameObject>();		//Dit is de uiteindendelijke list die Spawner 2 meekrijgt
	List<GameObject> spawner3List = new List<GameObject>();		//Dit is de uiteindendelijke list die Spawner 3 meekrijgt
	
	
	void Start () {
		waveIndex = 1;
		typeAmount = 0;
		environmentState = 1;
		enemyAmountBalanceMultiplier = 3;
		enemyAmountBalanceAddition = 0.6f;
		newWaveTimer = 5;

		//Deze functies hieronder zijn tijdelijk en alleen voor testen, VERWIJDEREN
		CheckUnlocks ();
		GenerateEnemyAmount ();
		//GenerateTypeAmount ();
		SelectEnemyTypes ();
		DivideWave ();
		DivideListOver4 ();
		//FillWaveLists ();
	}
	

	void Update () {

	}

	private void NewWaveGeneration(){
		CheckUnlocks ();		//Checkt of er een EnemyType unlocked moet worden
		GenerateEnemyAmount();	//Op basis van wave nummer
		//GenerateTypeAmount();	//Hoeveel van de types aan de wave mee mogen doen
		SelectEnemyTypes();		//Welke van de types aan de wave mee mogen doen
		DivideWave();			//Kies voor elke spawner een list
		//FillWaveLists();		//Fill hoeveelheid lists gelijk aan hoeveelheid spawners met de parameters
		//PassOnWaveData();		//Geef elke spawner 1 van de gemaakte lists
		//WaitForListConfirm();	//Wacht tot alle spawners een signaal teruggeven dat ze een list hebben

		newWaveTimer -= Time.deltaTime;
		if (newWaveTimer < 0) {
		//	EnvironmentChange();	//Verandert het speelveld indien bepaalde voorwaardes gehaald zijn
		//	StartNextWave(); 		//Geef Signaal naar alle spawners dat ze hun lijst uit mogen voeren
		}
	}

	private void WaveOver(){
		//ResetParameters ();
		NewWaveGeneration ();
	}

	private void CheckUnlocks(){
		if (waveIndex == 1 || waveIndex >= 1) {
			typeAmount = 1;
			crabUnlock = true;
		}

		if (waveIndex == 3 || waveIndex >= 3) {
			typeAmount++;
			snapperUnlock = true;
		}

		if (waveIndex == 5 || waveIndex >= 5) {
			environmentState = 2; //Stage gaat naar 2e "stage"
		}

		if (waveIndex == 6 || waveIndex >= 6) {
			typeAmount++;
			squidUnlock = true;
		}

		if (waveIndex == 9 || waveIndex >= 9) {
			typeAmount++;
			wheelUnlock = true;
		}

		if (waveIndex == 10 || waveIndex >= 10) {
			environmentState = 3;
		}
		Debug.Log (typeAmount + " Hoeveel types zijn er geunlocked?");
		Debug.Log (environmentState + " Welke state is de environment in?");
	}

	private void GenerateEnemyAmount(){
		enemyAmount = (waveIndex + enemyAmountBalanceAddition) * enemyAmountBalanceMultiplier;
		//Enemy Amount = (X + 0.6) * 3, is de huidige berekening. (1 + 0.6 = 1.6 * 3 = 4.8 enemies(Dit afronden)

		roundedEnemyAmount = Mathf.Ceil(enemyAmount);

		Debug.Log (roundedEnemyAmount + " Rounded Enemy Amount for next wave");

	}
	/*
	private void GenerateTypeAmount(){
		if (crabUnlock == true) {
			//typeAmount++;
		}
		if (snapperUnlock == true) {
			typeAmount++;
		}
		if (squidUnlock == true) {
			typeAmount++;
		}
		if (wheelUnlock == true) {
			typeAmount++;
		}

		Debug.Log (typeAmount + " Hoeveel types zijn er geunlocked?");
	}*/

	//Deze doet pas mee na Wave 10
	private void SelectEnemyTypes(){
		//Deze functie doet niks tot na Wave 10
		if (waveIndex > 10 || waveIndex == 10) {
			Debug.Log(" Je bent Hoger dan Wave 10");
		}
		else{
			Debug.Log(" I'm not participating yet");
		}
	}

	private void DivideWave(){
		spawnList1 = (Mathf.Ceil(enemyAmount / 3));
		Debug.Log(spawnList1 + " SpawnList 1 amount");
		spawnList2 = (Mathf.Ceil(enemyAmount / 3));
		Debug.Log(spawnList2 + " SpawnList 2 amount");
		spawnList3 = (Mathf.Floor(enemyAmount / 3));
		Debug.Log(spawnList3 + " SpawnList 3 amount");
	

		if (typeAmount == 1) {
		//	DivideListOver1();
		}
		if (typeAmount == 2) {
		//	DivideListOver2();
		}
		if (typeAmount == 3) {
		//	DivideListOver3();
		}
		if (typeAmount == 4) {
			//DivideListOver4();
		}


	}

	private void DivideListOver1(){
		spawnAsCrab = 		Mathf.Ceil ((roundedEnemyAmount / 100) * 35); //Spawn alles als crab
		crabsToSpawnLeft = spawnAsCrab;
	}
	private void DivideListOver2(){
		spawnAsCrab =		Mathf.Ceil ((roundedEnemyAmount / 100) * 65); //Spawnt 65% van alle enemyAmount als Crab
		spawnAsSnapper = 	Mathf.Ceil ((roundedEnemyAmount / 100) * 35); // SPawnt 35% van alle enemyAmount als Snapper
	}
	private void DivideListOver3(){
		spawnAsCrab = 		Mathf.Ceil ((roundedEnemyAmount / 100) * 63); //Spawnt 63% van alle enemyAmount als Crab
		spawnAsSnapper = 	Mathf.Ceil ((roundedEnemyAmount / 100) * 27); //Spawnt 27% van alle enemyAmount als Snapper
		spawnAsSquid = 		Mathf.Ceil ((roundedEnemyAmount / 100) * 10); //Spawnt 10% van alle enemyAmount als Squid
	}
	private void DivideListOver4(){
		spawnAsCrab = 		Mathf.Ceil ((roundedEnemyAmount / 100) * 50); //Spawnt 50% van alle enemyAmount als Crab
		spawnAsSnapper = 	Mathf.Ceil ((roundedEnemyAmount / 100) * 30); //Spawnt 30% van alle enemyAmount als Snapper
		spawnAsSquid = 		Mathf.Ceil ((roundedEnemyAmount / 100) * 8);  //Spawnt 8% van alle enemyAmount als Squid
		spawnAsWheel =	    Mathf.Floor ((roundedEnemyAmount / 100) * 12); //Spawnt 12% van alle enemyAmount als Wheel

		Debug.Log (spawnAsCrab + "Hoeveel procent wordt als Crab gespawnd"); 
		Debug.Log (spawnAsSnapper + "Hoeveel procent wordt als Snapper gespawnd");
		Debug.Log (spawnAsSquid + "Hoeveel procent wordt als Squid gespawnd");
		Debug.Log (spawnAsWheel + "Hoeveel procent wordt als Wheel gespawnd");
	}
	/*
	private void FillWaveLists(){
		float totalSpawnAmount = spawnAsCrab + spawnAsSnapper + spawnAsSquid + spawnAsWheel;
		List<EnemyType>[] spawnLists = new List<EnemyType>[3];

		for (int i = 0; i < totalSpawnAmount; i++) 
		{
			EnemyType type = GenerateRandomEnemy ();
			spawnLists[i%3].Add(type);
		}
	}*/

	/* 
	private EnemyType GenerateRandomEnemy()
	{
		EnemyType type = EnemyType.NoneType;
		while (type == EnemyType.NoneType)
		{
			int randomNumber = Random.Range(0, 5);
			switch(randomNumber)
			{
				case 0:
					if (crabsToSpawnLeft > 0)
					{
						crabsToSpawnLeft--;
						type = EnemyType.Crab;
					}
					break;
				case 1:
					if (snapperToSpawnLeft > 0)
					{
						snapperToSpawnLeft--;
						type = EnemyType.Snapper;
					}
					break;
				case 2:
					if (squidToSpawnLeft > 0)
					{
						squidToSpawnLeft--;
						type = EnemyType.Squid;
					}
					break;
				case 3:
					if(wheelToSpawnLeft > 0)
					{
						wheelToSpawnLeft--;
						type = EnemyType.Wheel;
					}
					break;
			}
		}
		return type;
	}*/

	private void PassOnWaveData(){

	}

	private void WaitForListConfirm(){

	}

	private void ResetParameters(){

	}

	private void EnvironmentChange(){
		if (waveIndex == 5 || waveIndex <= 5) {
			//Change Environment state to 2nd state
		}
		if (waveIndex == 10 || waveIndex <= 10) {
			//Change Environment state to 3rd state
		}
	}

	private void StartNextWave(){

	}
}