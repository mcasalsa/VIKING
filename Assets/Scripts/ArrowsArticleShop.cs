using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ArrowsArticleShop : MonoBehaviour
{
    public Text QuiverArrowText;
    private float num;
    public Text coinsText;
    private int sumPositiveCoins;


    AudioSource soundSource;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una 'carcaj' de fletxes hem de comrpbar si tenim 10 monedes per adquirirlo.
  
        if (collider.tag == "Player")
        {
           sumPositiveCoins = System.Int32.Parse(coinsText.text);
           if (sumPositiveCoins >= 25)
            {
                num = System.Int32.Parse(QuiverArrowText.text);
                num = num + 10;
                QuiverArrowText.text = (num).ToString();

                // hem comprat 10 fletxes restem 10 monedes.
                sumPositiveCoins = sumPositiveCoins - 25;
                coinsText.text = (++sumPositiveCoins).ToString();

                
                Destroy(gameObject);
            }
            
        }

    }
}