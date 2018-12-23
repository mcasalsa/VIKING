using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    private Animator anim;
    //public bool IdolStatus;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
       //Idol.NextLevel=false;
        //IdolStatus = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}

