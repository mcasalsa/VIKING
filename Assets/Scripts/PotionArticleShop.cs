using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PotionArticleShop : MonoBehaviour
{

    public Text potionsCount;
    private float num;

    public Text coinsText;
    private int sumPositiveCoins;
    public AudioClip itemShopSound;
    public AudioClip NoitemShopSound;
    AudioSource soundSource;
    // Use this for initialization
    void Start()
    {
        // so.
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una 'carcaj' de fletxes hem de comrpbar si tenim 10 monedes per adquirirlo.


        sumPositiveCoins = System.Int32.Parse(coinsText.text);

        if (sumPositiveCoins >= 25)
        {
            if (collider.tag == "Player")
            {
                
                //Actualitzem el contador de monedes.

                num = System.Int32.Parse(coinsText.text);
                num = num - 25;
                coinsText.text = (num).ToString();

                //sumPositiveCoins = sumPositiveCoins - 6;
                //coinsText.text = (++sumPositiveCoins).ToString();

                // actualitzem contador posions.

                num = System.Int32.Parse(potionsCount.text);
                num = num +1;
                potionsCount.text = (num).ToString();
                Destroy(gameObject);
               
            }
        }
    }
}
