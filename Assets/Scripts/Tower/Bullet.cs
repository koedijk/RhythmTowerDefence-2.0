using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	//snelheid van de kogel
	[SerializeField]
	private float bulletDamage;
	private float speed = 15;
	public float Speed{get{return speed;}set{speed = value;}}
	
	EnemyHealth enemyHealth;
	StatsOfObjects stats;
	
	
	
	void Start(){
		GameObject objUpgrades = GameObject.Find("StatsHolder");
		StatsOfObjects stats = objUpgrades.GetComponent<StatsOfObjects>();
		bulletDamage = stats.BulletDamage;
		Speed = stats.BulletSpeed;
	}
	
	void Update()
	{
		Vector3 movementVector = this.transform.right * (speed * Time.deltaTime);
		this.transform.position += movementVector;
		Invoke("killme", 5f);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{	
		enemyHealth = other.GetComponent<EnemyHealth>();
		if(other.gameObject.tag == "Enemy"){
			enemyHealth.enemyHealth -= bulletDamage;
			Destroy(this.gameObject);
			
		}
		else if(other.gameObject.tag == "Floor"){
			Destroy(this.gameObject);
		}
		
	}
	
	void killme()
	{
		Destroy(this.gameObject);
	}
	
}



