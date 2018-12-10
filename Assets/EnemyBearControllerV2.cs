using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBearControllerV2 : MonoBehaviour
{

    // Variables para gestionar el radio de visión y velocidad
    public float visionRadius = 25;
    public float speed;

    // Variable para guardar al jugador
    public GameObject player;

    // Variable para guardar la posición inicial
    Vector3 initialPosition;
    private int points = 0;
    public Text pointsText;
    private int bearPoints;

    //public GameObject bear;
    private SpriteRenderer spr;
    private float c1, c2;
    //private Color color;
    



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


    }

    void Update()
    {

        // Por defecto nuestro objetivo siempre será nuestra posición inicial
        Vector3 target = initialPosition;

        // Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;

        // Finalmente movemos al enemigo en dirección a su target
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // Y podemos debugearlo con una línea
        Debug.DrawLine(transform.position, target, Color.green);
        
    }

    // Podemos dibujar el radio de visión sobre la escena dibujando una esfera
    void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

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

        if (col.gameObject.tag == "Arrow")
        {
            float yOffset = 0.4f;
            bearPoints = bearPoints - 50;

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
                
              

            }
        }

        if (col.gameObject.tag == "Sword")
        {
            float yOffset = 0.4f;

            bearPoints = bearPoints - 50;
            c1 = c1 - 50;
            c2 = c2 - 50;
            Color color = new Color(255 / 255f, c1 / 255f, c2/ 255f);
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
        //points = points + incrementPoints;
        //pointsText.text = points.ToString();


        points = System.Int32.Parse(pointsText.text);
        pointsText.text = (points + incrementPoints).ToString();
    }
}



