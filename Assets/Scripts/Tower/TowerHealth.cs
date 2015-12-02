using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerHealth : MonoBehaviour
{

	private int maxHealth = 1000;
	private float towerCurHealth = 1000;
	private float healthBarLenght;
	public GameObject healthbar;
	public Text HpText;
	public float Health
	{
		get
		{
			return towerCurHealth;
		}
		set
		{
			towerCurHealth = value;
		}
	}

	TowerBehaviour TowerBase;

	void Start(){
		towerCurHealth = maxHealth;
	}
	void FixedUpdate(){
		AdjustcurHealth();

	}

	public void AdjustcurHealth () {
		HpText.text = towerCurHealth + "/" + maxHealth;
		if(towerCurHealth >= 1){
			float calculateHealth = towerCurHealth / maxHealth;
			SetHealthBar(calculateHealth);

		}
		
	} 
	public void SetHealthBar(float myHealth){
		//myHealth value 0-1 , 
		healthbar.transform.localScale = new Vector3(myHealth,healthbar.transform.localScale.y,healthbar.transform.localScale.z);
	}

	     
}
