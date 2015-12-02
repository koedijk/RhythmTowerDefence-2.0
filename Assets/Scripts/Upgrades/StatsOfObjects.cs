using UnityEngine;
using System.Collections;

public class StatsOfObjects : MonoBehaviour {

	private float currency;
	public float Currency{get{return currency;}set{currency = value;}}
	Upgrade upgrade;
	Bullet bullet;
	EnemyHealth newCurrency;
	private float bulletDamage = 10;
	public float BulletDamage{get{return bulletDamage;}set{bulletDamage = value;}}
	private float bulletspeed = 10;
	public float BulletSpeed{get{return bulletspeed;} set{bulletspeed = value;}}
	private float DelayTime = 1f;
	public float delayTime{get{return DelayTime;} set{DelayTime = value;}}

	//private float bulletShootRate = 15;
	//public float BulletSpeed{get{return bulletShootRate;}set{bulletShootRate = value;}}

	// Use this for initialization
	void Awake(){
		GameObject towerStats = GameObject.Find("TowerBase");
		TowerBehaviour stats = towerStats.GetComponent<TowerBehaviour>();
		currency = 1000000;
	}

	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
