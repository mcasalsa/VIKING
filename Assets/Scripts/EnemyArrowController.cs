using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyArrowController : MonoBehaviour
{

    // Variables para gestionar el radio de visión y velocidad
    public float visionRadius = 5;
    public float speed;

    // Variable para guardar al jugador
    public GameObject player;

    // Variable para guardar la posición inicial
    Vector3 initialPosition;
    private int points = 0;
    public Text pointsText;

    void Start()
    {

        // Recuperem al jugador gracies al tag player.
        player = GameObject.FindGameObjectWithTag("Player");

        // Desem la posició.
        initialPosition = transform.position;

    }

    void Update()
    {

        // L'objectiu del atac serà  la posició inicial
        Vector3 target = initialPosition;

        // Si la distancia amb el juagador es menor que el radi de visió de la fletxa llavors es produeix l'atac.
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;

        // La fletxa es mou cap el Player.
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // Y podemos debugearlo con una línea
        Debug.DrawLine(transform.position, target, Color.green);

    }

   // dibuix del radi de visió.
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
                col.SendMessage("EnemyJump");
                Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Shield")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void IncreasePoints(int incrementPoints)
    {
        points = System.Int32.Parse(pointsText.text);
        pointsText.text = (points + incrementPoints).ToString();
    }
}



