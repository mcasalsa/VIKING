using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {
        speed = 15f;
    }


    void FixedUpdate()
    {

        transform.Translate(Vector2.right * (Time.deltaTime) * speed);
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" )
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }
}
