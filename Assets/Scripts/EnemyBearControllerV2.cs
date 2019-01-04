using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBearControllerV2 : MonoBehaviour
{

    // Variables para gestionar el radio de visión y velocidad
    public float visionRadius = 25;
    public float speed;

    // Variable per guardar al jugador
    public GameObject player;

    // Variable per guardar la posició inicial
    Vector3 initialPosition;
    private int points = 0;
    public Text pointsText;
    private int bearPoints;

    //public GameObject bear;
    private SpriteRenderer spr;
    private float c1, c2;
    //private Color color;

    public SpriteRenderer spr1;
    public SpriteRenderer spr50;


    void Start()
    {
        c1 = 255;
        c2 = 255;
        Color color = new Color(255, 255, 255);
        // Recuperamos al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Guardamos nuestra posición inicial
        initialPosition = transform.position;
        bearPoints = 200;
        spr = GetComponent<SpriteRenderer>();
        //bear = GameObject.Find("EnemyBear");

        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr50.color = color2;
    }

    void Update()
    {

        // El os sempre tornarà a aquesta posició inical.
        Vector3 target = initialPosition;

        // Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;

        // Movem el os cap el jugador.
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // Per debugg.
        Debug.DrawLine(transform.position, target, Color.green);
        
    }


    void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

    }

    IEnumerator TimeDelay()
    {

        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr1.color = color2;
        spr50.color = Color.white; ;
        yield return new WaitForSeconds(0.25f);
        // Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                //col.SendMessage("EnemyJump");
                //Destroy(gameObject);

                // Enemic abatut.
                //IncreasePoints(50);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
                // Destroy(gameObject);
            }
        }

        if ((col.gameObject.tag == "Arrow") || (col.gameObject.tag == "Sword") || (col.gameObject.tag == "Axe"))
        {
            float yOffset = 0.4f;

            bearPoints = bearPoints - 50;
            c1 = c1 - 50;
            c2 = c2 - 50;
            Color color = new Color(255 / 255f, c1 / 255f, c2 / 255f);
            //Color color = new Color(255 / 255f, c1/1f, c2/ 1f);
            spr.color = color;


            if (bearPoints <= 0)
            {
                Destroy(gameObject);
                IncreasePoints(50);
            }
            else
            {
                //col.SendMessage("EnemyKnockBack", transform.position.x);
            }
            if (transform.position.y + yOffset < col.transform.position.y)
            {

                //bearPoints = bearPoints - 50;

                //bearPoints = bearPoints - 50;
                //c1 = c1 - 50;
                //c2 = c1 - 50;


            }
        }

    }

    public void IncreasePoints(int incrementPoints)
    {
        points = System.Int32.Parse(pointsText.text);
        pointsText.text = (points + incrementPoints).ToString();
        StartCoroutine(TimeDelay());
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Arrow") || (collider.gameObject.tag == "Sword") || (collider.gameObject.tag == "Axe"))
        {
            // pasem'avís de dany a transparent.
            Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
            spr50.color = Color.white;
            StartCoroutine(TimeDelay());
        }
    }
}



