using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySnakeController : MonoBehaviour {

	public float maxSpeed = 1f;
	public float speed = 1f;

	private Rigidbody2D rb2d;
    private int points = 0;
    public Text pointsText;
    public SpriteRenderer spr1;
    public SpriteRenderer spr50;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr50.color = color2;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		rb2d.AddForce(Vector2.right * speed);		
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){
			speed = -speed;
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}

		if (speed < 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (speed > 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

    IEnumerator TimeDelay()
    {
       
        Color color2 = new Color(255 / 255f, 255 / 255f, 0 / 255f, 0 / 255f);
        spr1.color = color2;
        spr50.color = Color.white; ;
        yield return new WaitForSeconds(0.25f);
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

        

        if ((col.gameObject.tag == "Arrow") || (col.gameObject.tag == "Sword") || (col.gameObject.tag == "Axe"))
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
