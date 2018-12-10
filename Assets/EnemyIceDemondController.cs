﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIceDemondController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float speed = 10f;

    private Rigidbody2D rb2d;
    private int points = 0;
    public Text pointsText;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        maxSpeed = 10f;
        speed = 11f;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
                // Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Arrow")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                //col.SendMessage("EnemyJump");
                Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                //col.SendMessage("EnemyKnockBack", transform.position.x);
                Destroy(gameObject);
                IncreasePoints(50);
            }
        }

        if (col.gameObject.tag == "Sword")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                //col.SendMessage("EnemyJump");
                Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                //col.SendMessage("EnemyKnockBack", transform.position.x);
                Destroy(gameObject);
                IncreasePoints(50);
            }
        }
    }

    public void IncreasePoints(int incrementPoints)
    {
        //points = points + incrementPoints;
        //pointsText.text = points.ToString();


        points = System.Int32.Parse(pointsText.text);
        pointsText.text = (points + incrementPoints).ToString();
    }
}
