using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    // hp hit points, maxHP = 100 punts de vida del personatge.
    float hp, maxHp = 100f;
    public Image health;
    public Hearts lifeCanvas;
    public static int lifes;

    // Use this for initialization
    void Start() {
        hp = maxHp;
        lifes = 3;
        lifeCanvas = GameObject.FindObjectOfType<Hearts>();
        lifeCanvas.ChangeLife(lifes);

}

    // Update is called once per frame
    void Update() {

    }
    public void TakeDamage(float amountDamage)
    {
        // Math.Clamp per arrodonir i assegurar que no entrem en valors de vida menors a zero o superiors a 100.
        hp = Mathf.Clamp(hp - amountDamage, 0f, maxHp);
        if (hp <= 0)
        {
            // vitalitat esgotada, restem una vida
            lifes = lifes - 1;
            
            if (lifes > 0)
            {
                // s'ha perdut una vida peo encara ens en queden. Restaurem la vitalitat.
                hp = maxHp;
                health.transform.localScale = new Vector2(hp / maxHp, 1);

                // actualitzem el marcador de vides.
               
                        lifeCanvas.ChangeLife(lifes);
                   
               

            }
            else
            {
                // numero de vides esgotat. Game Over.
                lifeCanvas.ChangeLife(lifes);
            }
        }
        else
        {
            hp = Mathf.Clamp(hp - amountDamage, 0f, maxHp);
        }
        health.transform.localScale = new Vector2(hp/maxHp, 1);
        

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una cor de vida extra augmentem amb el contador de vides i actualitzem el marcador de vides amb un tope de 4.


       
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            lifes = lifes + 1;

            if (lifes > 4)
            {
                lifes = 4;
            }
            lifeCanvas.ChangeLife(lifes);
           




        }
     }

}
