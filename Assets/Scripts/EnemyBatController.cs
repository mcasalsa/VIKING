using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBatController : MonoBehaviour
{

    // Variables per gestionar ek radi de visió i la velocitat
    public float visionRadius=2500;
    public float speed;

    // Variable para guardar al jugador
    public GameObject player;

    // Variable para guardar la posición inicial
    Vector3 initialPosition;
    private int points = 0;
    public Text pointsText;
    public SpriteRenderer spr1;
    public SpriteRenderer spr50;


    void Start()
    {

        // Recuperem al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Desem la  posició inicial
        initialPosition = transform.position;
        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr50.color = color2;

    }

    void Update()
    {

        // Per defecte l'objectiu serà a la nostra posició inical.
        Vector3 target = initialPosition;

        // Pero si la distancia hasta el jugador es menor que el radio de visión el objetivo será él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;


        //Moure el ratpenat cap al player.
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        // sols per fer debugg.
        Debug.DrawLine(transform.position, target, Color.green);

    }

    //Dibuxem el radi de visió del ratpenat. Es veura en el inpector no en el joc.
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
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                // transform.localScale = new Vector3(-1f, 1f, 1f);
                IncreasePoints(50);
            }
            else
            {
                // transform.localScale = new Vector3(-1f, 1f, 1f);
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }

        if (col.gameObject.tag == "Arrow")
        {
            spr1.color = Color.white;

            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                // Enemic abatut.
                //transform.localScale = new Vector3(-1f, 1f, 1f);
                IncreasePoints(50);
            }
            else
            {
                // Enemic abatut.
                // transform.localScale = new Vector3(-1f, 1f, 1f);
                IncreasePoints(50);
                //StartCoroutine(TimeDelay());
            }
        }

        if (col.gameObject.tag == "Sword")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                // Enemic abatut.
                // transform.localScale = new Vector3(-1f, 1f, 1f);
                IncreasePoints(50);
                //StartCoroutine(TimeDelay());
            }
            else
            {
                //transform.localScale = new Vector3(-1f, 1f, 1f);
                IncreasePoints(50);
                //StartCoroutine(TimeDelay());
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
        if (collider.tag == "Arrow" || collider.tag == "Sword")
        {
            // pasem'avís de dany a transparent.
            Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
            spr50.color = Color.white;
            StartCoroutine(TimeDelay());
        }
    }
}
