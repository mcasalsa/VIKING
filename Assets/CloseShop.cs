using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloseShop : MonoBehaviour
{
    public GameObject shop;
    public bool pauseGame;



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

        shop.SetActive(false);
        pauseGame = false;

        Time.timeScale = (pauseGame) ? 0f : 1f;


    }

    
}

