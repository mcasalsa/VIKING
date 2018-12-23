using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NegativeCoin: MonoBehaviour
{
    public Text coinsText;
    private int sumPositiveCoins;
    // Use this for initialization
    void Start()
    {
        //sumPositiveCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // recollim monedes positives

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una moneda incrementem el contafor de punts en 5.


        //if (GetComponent<Collider>().tag == "Player") {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            //sumPositiveCoins += sumPositiveCoins;

            //scoreTotal += scoreTotal;
            //System.Int32.Parse(pointsText.text);
            sumPositiveCoins = System.Int32.Parse(coinsText.text);
            if (sumPositiveCoins>0)
            {
                coinsText.text = (--sumPositiveCoins).ToString();
            }
}




    }
}

