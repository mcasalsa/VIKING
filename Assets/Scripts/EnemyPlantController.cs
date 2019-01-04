using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlantController : MonoBehaviour
{

    

    private Rigidbody2D rb2d;
    private int points = 0;
    public Text pointsText;

    public SpriteRenderer spr1p;
    public SpriteRenderer spr50p;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr50p.color = color2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }


    IEnumerator TimeDelay()
    {

        Color color3 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr1p.color = color3;
        spr50p.color = Color.white; 
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
                //Destroy(gameObject);

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
                //Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                //col.SendMessage("EnemyKnockBack", transform.position.x);
               // Destroy(gameObject);
                IncreasePoints(50);
            }
        }

        if (col.gameObject.tag == "Sword")
        {
            float yOffset = 0.4f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                //col.SendMessage("EnemyJump");
                //Destroy(gameObject);

                // Enemic abatut.
                IncreasePoints(50);
            }
            else
            {
                //col.SendMessage("EnemyKnockBack", transform.position.x);
               // Destroy(gameObject);
                IncreasePoints(50);
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
            spr1p.color = color2;
            spr50p.color = Color.white;
            StartCoroutine(TimeDelay());
        }
    }

}
