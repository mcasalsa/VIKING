﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAtack : MonoBehaviour
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
            col.SendMessage("EnemyKnockBack", transform.position.x);
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
