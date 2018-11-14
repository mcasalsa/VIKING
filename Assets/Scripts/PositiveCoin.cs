using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PositiveCoin : MonoBehaviour
{
    public Text coinsText;
    private int sumPositiveCoins;
   

 

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    // recollim monedes positives

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una moneda incrementem el contador de monedes en 1.



        if (collider.tag == "Player")
        {
            

            sumPositiveCoins = System.Int32.Parse(coinsText.text);
            coinsText.text = (++sumPositiveCoins).ToString();

           
            
            Destroy(gameObject);
        }
    }
}

