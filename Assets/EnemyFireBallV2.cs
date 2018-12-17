using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBallV2 : MonoBehaviour
{

    public float fallDelay = 1f;
    public float respawnDelay = 5f;
    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    private Vector3 start;



    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            rb2d.isKinematic = false;
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;

        //pc2d.isTrigger = true;
        pc2d.isTrigger = false;
    }

    void Respawn()
    {
        transform.position = start;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        pc2d.isTrigger = true;

    }
}
