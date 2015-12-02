using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : Lines
{
	//public
	public float Speed;
	public Vector2 bewegingsVector = Vector2.zero;
	private Animator animAttack;
	TowerHealth Tower;
	//privates
	private Waypoint targetWaypoint;
	private GameObject movementLine;
	private float EnemyDamage = 7;
	public float delayTime = 2f;
	private float delay;
	void Start()
	{
		animAttack = GetComponent<Animator>();
		Speed = Speed + (Random.value) + (Random.value);
		Tower = GameObject.FindObjectOfType<TowerHealth>();
		targetWaypoint = this.FindClosestWaypoint();
		this.movementLine = makeLine(Vector2.zero, Color.green);
		delay = delayTime;
	}
	
	void FixedUpdate()
	{
		this.MoveToWaypoint(targetWaypoint);
	}

	void MoveToWaypoint(Waypoint waypoint)
	{
		//als de waypoint afstand kleiner is als 0.1 dan haal nieuwe waypoint op
		if (Vector2.Distance(waypoint.gameObject.transform.position, this.transform.position) < 0.1)
		{
			animAttack.SetBool("Attack",true);
		}
		else
		{
			//reken de vector richting de waypoint uit
			Vector2 vectorRichtingWaypoint = waypoint.transform.position - this.transform.position;
			//normalize deze vector(dat betekend dat de lengte van de vector terug naar 1 gebracht word)
			vectorRichtingWaypoint.Normalize();
			//vermenigvuldig deze vector met de (speed*deltatime) die we willen hebben(dit betekend de lengte van de vector word nu zo groot als de speed*detltatime)
			vectorRichtingWaypoint *= Speed * Time.fixedDeltaTime;
			//voeg deze nieuwe vector aan onze positie en we bewegen richting de waypoint
			this.transform.position += new Vector3(vectorRichtingWaypoint.x, vectorRichtingWaypoint.y);
			
			//convert v3 naar v2
			Vector2 thispos = new Vector2(this.transform.position.x, this.transform.position.y);
			
			this.drawLineTo(this.movementLine, this.transform.position, thispos + vectorRichtingWaypoint.normalized * Speed);
			this.bewegingsVector = vectorRichtingWaypoint;
		}
	}
	
	Waypoint FindClosestWaypoint()
	{
		//find alle enemy objecten in het spel
		var enemys = GameObject.FindObjectsOfType<Waypoint>();
		if (enemys.Length > 0)
		{
			//zet de begin distance op infinity
			float dist = Mathf.Infinity;
			//maak variable aan waar we de enemy gaan opslaan die het dichts bij is.
			Waypoint closest = null;
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