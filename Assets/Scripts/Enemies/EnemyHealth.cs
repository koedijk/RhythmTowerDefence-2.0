using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private Animator animDie;
	[SerializeField]
	private float EnemyDamage = 7;
	[SerializeField]
	private float enemyCurHealth = 20;
	[SerializeField]
	private float maxHealth = 20;
	public float waitSeconds;
	public float gainCurrency;
	public float enemyHealth{
	
		get
		{
			return enemyCurHealth;
		}
		set
		{
			enemyCurHealth = value;
		}

	}

	public GameObject healthbar;



	// Use this for initialization
	void Start () {
		animDie = GetComponent<Animator>();
		enemyCurHealth = maxHealth;
		InvokeRepeating("Decreasehealth",1f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Decreasehealth();
	}



	void Decreasehealth(){
		if(enemyCurHealth >= 1){
		float calculateHealth = enemyCurHealth / maxHealth;
		SetHealthBar(calculateHealth);
		}
		else if(enemyCurHealth <= 1){
			Destroy(healthbar);
			Destroy(GetComponent<EnemyBehaviour>());
			Destroy(GetComponent<PolygonCollider2D>());
			animDie.SetBool("Die", true);
			StartCoroutine(Die());

			//Destroy();
		}


	}
	public void SetHealthBar(float myHealth){
		//myHealth value 0-1 , 
		healthbar.transform.localScale = new Vector3(myHealth,healthbar.transform.localScale.y,healthbar.transform.localScale.z);
	}
	IEnumerator Die(){
		yield return new WaitForSeconds(waitSeconds);
		GameObject Currency = GameObject.Find("StatsHolder");
		StatsOfObjects Currency_stats = Currency.GetComponent<StatsOfObjects>();
		Currency_stats.Currency += gainCurrency;
		Destroy(this.gameObject);
	}
	
}
