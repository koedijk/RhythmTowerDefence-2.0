using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : Lines
{
	//publics
	public Bullet bullet;
	public StatsOfObjects stats;
	public GameObject Gunpoint;
	//privates	
	//line	
	//enemy
	EnemyBehaviour closestEnemy;
	//time
	private float delay;
	void Start()
	{
		
		this.closestEnemy = this.findClosestEnemy();
		delay = stats.delayTime;
	}
	
	void FixedUpdate()
	{	
		//vind de dichts bij zijnde enemy
		this.closestEnemy = this.findClosestEnemy();
		//teken een lijn naar de closest enemy in rood
		//bereken de projetile trajectory
		Vector2 trajectory = calulateTrajectory();
		if (delay < 0)
		{
			delay = stats.delayTime;
			this.Shoot(trajectory);
			
		}
		else
		{
			delay -= Time.fixedDeltaTime;
		}
	}
	
	void Shoot(Vector2 towards)
	{
		//maak nieuwe kogel
		GameObject tempkogel = (GameObject)Instantiate(bullet.gameObject, Gunpoint.transform.position, Quaternion.identity);
		//reken de hoek uit
		float angle = VectorMath.CartesianToPolar(towards).x;
		//draai de kogel
		tempkogel.transform.eulerAngles = new Vector3(0, 0, angle);
	}
	Vector2 calulateTrajectory()
	{
		//haal de enemey positie op
		Vector2 enemypos = this.closestEnemy.transform.position;
		//reken de kogel snelheid uit
		float bulletSpeed = stats.BulletSpeed * Time.fixedDeltaTime + 100;
		//berekend de afstand van de enemy
		//dit is a*a+b*b=c(dus pythagoras)
		float enemyDist = Vector2.Distance(Gunpoint.transform.position, enemypos);
		//reken uit hoelang het duurt voor dat de kogel bij de enemy is
		//time=distance/speed
		float travelTime = enemyDist / bulletSpeed;
		//neem de enemy zijn bewegings vector en vermenigvuldig die met de kogel traveltime
		//positie + bewegings vector * travel time
		Vector2 pre = enemypos + this.closestEnemy.bewegingsVector * travelTime;
		
		//doe de zelfde berekening maar dan met de nieuwe positie
		enemyDist = Vector2.Distance(Gunpoint.transform.position, pre);
		//reken de nieuwe adstand uit
		travelTime = enemyDist / bulletSpeed;
		//reken de laaste keer de travel time uit en daar uit krijg je de positie waar je heen moet schieten
		pre = enemypos + this.closestEnemy.bewegingsVector * travelTime;
		
		//this.drawLineTo(this.aimLine, Gunpoint.transform.position, pre);
		return pre;
	}
	
	EnemyBehaviour findClosestEnemy()
	{
		//find alle enemy objecten in het spel
		var enemys = GameObject.FindObjectsOfType<EnemyBehaviour>();
		if (enemys.Length > 0)
		{
			//zet de begin distance op infinity
			float dist = Mathf.Infinity;
			//maak variable aan waar we de enemy gaan opslaan die het dichts bij is.
			EnemyBehaviour closest = null;
			//loop door de enemys heen
			for (int i = 0; i < enemys.Length; i++)
			{
				//reken de distance uit tussen dit object en de huidige enemy 
				float curDist = Vector2.Distance(enemys[i].transform.position, this.transform.position);
				//is die distance kleiner dan is de enemy dus ook dichter bij.
				if (curDist < dist)
				{
					//zet de closest enemy
					closest = enemys[i];
					//zet de nieuwe distance
					dist = curDist;
				}
			}
			//loop is klaar en return de enemy
			return closest;
		}
		//geen enemy gevonden
		return null;
	}
}
