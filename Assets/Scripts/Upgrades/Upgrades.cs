using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {
	private float UpgradePriceDamage = 100;
	private float UpgradePriceShootRate = 150;

	private float LevelUpgradeDamage ;
	private float LevelShootRate ;
	
	TowerBehaviour ShootRate;
	void Awake(){
		LevelUpgradeDamage =+ 1;
		LevelShootRate =+ 1;
		GameObject Currency = GameObject.Find("StatsHolder");
		StatsOfObjects Currency_stats = Currency.GetComponent<StatsOfObjects>();
		UpgradePriceDamage *= LevelUpgradeDamage;
		UpgradePriceShootRate *= LevelShootRate;
		Debug.Log ("Prijs van Damage = " + (UpgradePriceDamage *= LevelUpgradeDamage));
		Debug.Log ("Prijs van Rate = " + (UpgradePriceShootRate *= LevelShootRate));
		Debug.Log ("Zoveel Geld heb ik " + (Currency_stats.Currency));
		Debug.Log (LevelUpgradeDamage);
	}
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnClickUpgradeDamage(){
		GameObject Currency = GameObject.Find("StatsHolder");
		StatsOfObjects Currency_stats = Currency.GetComponent<StatsOfObjects>();
		if(Currency_stats.Currency >= UpgradePriceDamage){
			Currency_stats.Currency -= UpgradePriceDamage;
			LevelUpgradeDamage += 1;
			UpgradePriceDamage *= LevelUpgradeDamage;
			Currency_stats.BulletDamage += 2.5f;
			Debug.Log(Currency_stats.Currency + " Zoveel heb je over");
			Debug.Log("Nieuwe upgrade prijs = " + UpgradePriceDamage);
		}
		else{
			Debug.Log("Transactie mislukt zoveel heb je nodig " + (UpgradePriceDamage - Currency_stats.Currency) + " En je hebt " + Currency_stats.Currency );
		}
	}
	public void onClickUpgradeRate(){
		GameObject Currency = GameObject.Find("StatsHolder");
		StatsOfObjects Currency_stats = Currency.GetComponent<StatsOfObjects>();
		if(Currency_stats.Currency >= UpgradePriceShootRate){
			Currency_stats.Currency -= UpgradePriceShootRate;
			LevelShootRate += 1;
			UpgradePriceShootRate *= LevelShootRate;
			Currency_stats.delayTime -= 0.1f;
			Debug.Log(Currency_stats.Currency + " Zoveel heb je over");
			Debug.Log (Currency_stats.delayTime);
		}
		else{
			Debug.Log("Transactie mislukt zoveel heb je nog nodig " + (UpgradePriceShootRate - Currency_stats.Currency) + " En je hebt " + Currency_stats.Currency  );
		}
	}


}
