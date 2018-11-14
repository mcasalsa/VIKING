using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeFood : MonoBehaviour {
    float hp, maxHp = 100f;
    public Image health;
    float amountFood = 15f;
    private GameObject healthbar;

    // Use this for initialization
    void Start () {
        healthbar = GameObject.Find("Healthbar");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        
        // Math.Clamp per arrodonir i assegurar que no entrem en valos de vida menors a zero o superiors a 100.
        // hp = Mathf.Clamp(hp + amountFood, 0f, maxHp);
        if (hp < 100)
        {
            // Augmentem la vitalitat.
            healthbar.SendMessage("TakeDamage", -15);
            // s'ha perdut una vida peo encara ens en queden. Restaurem la vitalitat.
           // hp = hp + amountFood;
                //health.transform.localScale = new Vector2(hp / maxHp, 1);

            }
         //health.transform.localScale = new Vector2(hp / maxHp, 1);


    }
}
