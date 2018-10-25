using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowArticleShop : MonoBehaviour {
    // variables per fer compres d'articles.
    private float num;
    public Text coinsText;
    private int sumPositiveCoins;

    //private Animator anim;
    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // compra del arc.
    void OnTriggerEnter2D(Collider2D collider)
    {
        // comprovem si tenim prous monedes per comprar el arc.
        sumPositiveCoins = System.Int32.Parse(coinsText.text);

        if (sumPositiveCoins >= 5)
        {
            if (collider.tag == "Player")
            {
                sumPositiveCoins = sumPositiveCoins - 5;
               coinsText.text = (sumPositiveCoins).ToString();
               Destroy(gameObject);
                //activem l'arma arc.
                //anim.SetBool("BowAtack", true);
            }
        }
        else
        {
            // no tenim prou monedes per comprar 10 fletxes.
        }

    }
}
