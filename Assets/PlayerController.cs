using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour {
    Vector3 target;
    public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
    public bool disarmed;
    //public bool swordAtack = false;
    public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private SpriteRenderer spr;
	private bool jump;
	private bool doubleJump;
	private bool movement = true;
    private GameObject healthbar;
    public GameObject arrow;
    public float arrowRotation = 0;
    public Text shieldStatus;
    public Text swordStatus;
    public Text arrowsCounterText;
    public bool NextLevel;
    private float arrowsCounterNum;

    //public float parallaxSpeed = 0.02f;
    public float parallaxSpeed = 1f;
    public RawImage background00, background01, background02, background03;
    //public RawImage background03;
    public RawImage platform;



    //private int points = 0;
    //public Text pointsText;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
        arrow = GameObject.Find("Arrow"); 
        healthbar = GameObject.Find("Healthbar");
        anim.SetBool("SwordAtack", false);
        anim.SetBool("BowAtack", false);
        anim.SetBool("ShieldAtack", false);
        anim.SetBool("NextLevel", false);
        //anim.SetBool("Disarmed", true);
        arrowRotation = 0;
        shieldStatus.text = "Desactivat";
        anim.SetBool("NextStatus", false);
        NextLevel = false;


    }

    void Parallax(float h)
    {

        // per a cada fotograma es calcula la velocitat final del terra i els diferents backgrouns que conformen el parallax.
        // si h > 0 parallax dreta si h< parallax cap a l'esquerra.
        //h = h * 0.125f;
        float finalSpeed = parallaxSpeed * Time.deltaTime;
              background00.uvRect = new Rect(background00.uvRect.x + finalSpeed * (h * 2f), 1f, 1f, 1f);
               background01.uvRect = new Rect(background01.uvRect.x + finalSpeed * (h*3f), 1f, 1f, 1f);
        //h = h * 1.5f;
        //background01.uvRect = new Rect(background01.uvRect.x + finalSpeed * (h*1.5f), 1f, 1f, 1f);

        //ok
        //primera linea de boscos.
        background02.uvRect = new Rect(background02.uvRect.x + finalSpeed * (h * 0.5f), 1f, 1f, 1f);
        background03.uvRect = new Rect(background03.uvRect.x + finalSpeed * (h * 0.75f), 1f, 1f, 1f);
        //platform velocity = background velocity * 4;
        //platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 0.50f, 0f, 1f, 1f);

    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("SwordAtack", false);
        anim.SetBool("BowAtack", false);
        //anim.SetBool("Shield", false);
        //anim.SetBool("ShieldAtack", false);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //swordAtack = true;
            anim.SetBool("SwordAtack", true);
            swordStatus.text = "Activat";
            //anim.SetBool("SwordAtack", false);
            //swordAtack = false;
        }


        // atac amb fletxa.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            // comprovem si teneim fletxes.
            arrowsCounterNum = System.Int32.Parse(arrowsCounterText.text);
            if (arrowsCounterNum > 0 & shieldStatus.text == "Desactivat")
            {


                anim.SetBool("BowAtack", true);


                // quaternion.eduler ens permet aplicar la rotació de la fletxa.

                Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, arrowRotation));

                // restem una fletxa.
                arrowsCounterNum = System.Int32.Parse(arrowsCounterText.text);
                arrowsCounterText.text = (--arrowsCounterNum).ToString();

            }
            else
            {
                // no tenim fletxes.
            }



        }

        // Escut.
        if (Input.GetKeyDown("3"))
        {
            if (shieldStatus.text == "Desactivat")
            {
                anim.SetBool("ShieldAtack", true);
                anim.Play("Player_Shield");
                shieldStatus.text = "Activat";
            }
            else
            {
                shieldStatus.text = "Desactivat";
                anim.SetBool("ShieldAtack", false);
            }
        }




        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (grounded) {
                jump = true;
                doubleJump = true;

            } else if (doubleJump) {
                jump = true;
                doubleJump = false;
            }
        }



        //Debug.DrawLine(transform.position, target, Color.green);
       
    }

    void FixedUpdate(){

        //anim.SetBool("SwordAtack", false);

        Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if (grounded){
			rb2d.velocity = fixedVelocity;
		}

		float h = Input.GetAxis("Horizontal");
        if (!movement)
        {
            h = 0;

        }

		rb2d.AddForce(Vector2.right * speed * h);
        
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f) {
			transform.localScale = new Vector3(1f, 1f, 1f);
            Parallax(h);
        } 

		if (h < -0.1f){
			transform.localScale = new Vector3(-1f, 1f, 1f);
            Parallax(h);

        }

		if (jump){
			rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

        //Debug.Log(rb2d.velocity.x);
        // si apretem cap a la esquerra girem tambe el tir de fletxa.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowRotation = 0;


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowRotation = 180;
        }

       


    }

	void OnBecameInvisible(){
		transform.position = new Vector3(-1,0,0);
	}

	public void EnemyJump(){
		jump = true;
	}

    // Ens ha tocat un enemic.
	public void EnemyKnockBack(float enemyPosX){
		jump = true;

		float side = Mathf.Sign(enemyPosX - transform.position.x);
		rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

		movement = false;
		Invoke("EnableMovement", 0.7f);

		Color color = new Color(255/255f, 106/255f, 0/255f);
		spr.color = color;

        // Restem vida enviant y¡un missage a la fució TakeDamage del scrot HealthBar.
        healthbar.SendMessage("TakeDamage",15);
    }

	void EnableMovement(){
		movement = true;
		spr.color = Color.white;
        //Parallax();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una moneda incrementem el contador de monedes en 1.



        if (collider.tag == "Sword")
        {
            anim.SetBool("Disarmed", false);

        }

        if (collider.tag == "ToIsland")
        {
           
            if (NextLevel== true)
            {
                //Final de nivell i tenim el idol. Passem al següent nivell.
                SceneManager.LoadScene("MainMenu");
            }
            {
                // Final de nivell pero no tenim el idol. Hem de continuar buscant.
            }
                
            

        }

        if (collider.tag == "Idol")
        {

            NextLevel = true;
            

        }





    }
}
