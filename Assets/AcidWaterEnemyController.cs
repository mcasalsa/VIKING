﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidWaterEnemyController : MonoBehaviour
{

    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody2D rb2d;
    private int points = 0;
    public Text pointsText;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                //Destroy(gameObject);

                // Enemic abatut.

            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
                // Destroy(gameObject);
            }
        }

    }
}
