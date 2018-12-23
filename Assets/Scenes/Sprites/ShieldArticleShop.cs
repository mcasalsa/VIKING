using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldArticleShop : MonoBehaviour {
    private float num;
    public Text coinsText;
    private int sumPositiveCoins;
    public Text shieldStatus;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            sumPositiveCoins = System.Int32.Parse(coinsText.text);

            if (sumPositiveCoins >= 25)
            {
                sumPositiveCoins = sumPositiveCoins - 25;
                coinsText.text = (sumPositiveCoins).ToString();
                shieldStatus.text = "Activat";
                Destroy(gameObject);
            }
        }
        
    }
}
