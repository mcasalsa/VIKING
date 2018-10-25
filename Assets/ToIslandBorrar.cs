using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToIsland : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // cambi de escena.
void OnTriggerEnter2D(Collider2D collider)
    {
        //SceneManager.LoadScene("MainMenu");
        if (collider.tag == "Player")
        {
            // Tenim el idol, anem al següent nivell.

            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            //no hem trobat el idol, hem de seguir buscant.
           
        }

    }
}
