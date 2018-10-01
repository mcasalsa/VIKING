using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PositiveCoin : MonoBehaviour
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
        // si piquem amb una moneda incrementem el contador de monedes en 1.



        if (collider.tag == "Player")
        {
            Destroy(gameObject);

            sumPositiveCoins = System.Int32.Parse(coinsText.text);
            coinsText.text = (++sumPositiveCoins).ToString();

        }
    }
}

