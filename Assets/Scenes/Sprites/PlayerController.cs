using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour {
    Vector3 target;
    public  Vector3 PosPlayer;
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
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
    public GameObject fireShot;
    public GameObject stopToIsland;
    public GameObject stopToEngland;
    public GameObject stopToFinland;
    public GameObject stopToHome;
    public GameObject thunder;
    public float arrowRotation = 0;
    public float fireRotation = 0;
    public Text shieldStatus;
    public Text swordStatus;
    public Text AxeStatus;
    public Text arrowsCounterText;
    private float arrowsCounterNum;
    public Text fireCounterText;
    private float fireCounterNum;



    //public float parallaxSpeed = 0.02f;
    public float parallaxSpeed = 1f;
    public RawImage background00, background01, background02;
    //public RawImage background03;
    public RawImage platform;


    // variables per fer compres d'articles.
    private float num;
    public Text coinsText;
    private int sumPositiveCoins;

    // variables per les pocions de vida.
    float hp, maxHp = 100f;
    public static int lifes;
    public Image health;
    //public Hearts lifeCanvas;
    public Text potions;
    public bool nextlevel;
    public Text levelText;

    // variables de so.
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip swordSound;
    public AudioClip fireBall;
    public AudioClip coinSound;
    public AudioClip potionSound;
    public AudioClip negativeCoinSound;
    public AudioClip shootingArrowSound;
    public AudioClip foodSound;
    public AudioClip itemShopSound;
    public AudioClip soundThunder;
    public AudioClip idolSound;
    public AudioClip NoitemShopSound;
    public AudioClip stoperSound;
    public GameObject shop;
   




    AudioSource soundSource;


    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        arrow = GameObject.Find("Arrow"); ;
        healthbar = GameObject.Find("Healthbar");
        //stopToIsland = GameObject.Find("StoperToIsland");
        anim.SetBool("SwordAtack", false);
        anim.SetBool("BowAtack", false);
        anim.SetBool("AxeAtack", false);
        anim.SetBool("ArrowsAmunition", false);
        anim.SetBool("ShieldAtack", false);
        anim.SetBool("NextLevel", false);
        //anim.SetBool("PlayerDead", false);
        //anim.SetBool("Level",1f);
        shieldStatus.text = "Desactivat";
        levelText.text = "1 Amèrica";
        

        arrowRotation = 0;
        nextlevel = false;

        // so.
        soundSource = GetComponent<AudioSource>();
;

        hp = maxHp;



        soundSource.clip = soundThunder;
        soundSource.Play();


        anim.SetBool("ThunderBool", true);
        anim.Play("Thunder");
    }

    public class SysGuardar : MonoBehaviour
    {


        public static void Guardar_Posicion(Vector3 Posicion)
        {
            PlayerPrefs.SetFloat("x", Posicion.x);
            PlayerPrefs.SetFloat("y", Posicion.y);
            PlayerPrefs.SetFloat("z", Posicion.z);
        }

        public static Vector3 Cargar_Posicion()
        {
            Vector3 Posicion;
            Posicion.x = PlayerPrefs.GetFloat("x");
            Posicion.y = PlayerPrefs.GetFloat("y");
            Posicion.z = PlayerPrefs.GetFloat("z");
            return Posicion;
        }
    }

    void Parallax(float h)
    {

        // per a cada fotograma es calcula la velocitat final del terra i els diferents backgrouns que conformen el parallax.
        // si h > 0 parallax dreta si h< parallax cap a l'esquerra.
        h = h * 1.5f;
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        //background00.uvRect = new Rect(background00.uvRect.x + finalSpeed * (h*2), 1f, 1f, 1f);
        // background01.uvRect = new Rect(background01.uvRect.x + finalSpeed * 0.1f, 1f, 1f, 1f);
        h = h * 1.5f;
        background01.uvRect = new Rect(background01.uvRect.x + finalSpeed * (h / 8), 1f, 1f, 1f);
        //background02.uvRect = new Rect(background02.uvRect.x + finalSpeed * (h /4), 1f, 1f, 1f);
        //background03.uvRect = new Rect(background03.uvRect.x + finalSpeed * (h /8), 1f, 1f, 1f);
        //platform velocity = background velocity * 4;
        //platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 0.50f, 0f, 1f, 1f);

    }

    // Update is called once per frame
    void Update() {
       


        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("SwordAtack", false);
        //anim.SetBool("AxeAtack", false);
        anim.SetBool("BowAtack", false);
        anim.SetBool("AxeAtack", false);
        

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // comprovem si tenim pocions.
            num = System.Int32.Parse(potions.text);

            if (num > 0)
            {
                // la posicó fa que la barra de vida estigui al máxim.
                hp = maxHp;
                health.transform.localScale = new Vector2(hp / maxHp, 1);

                // so de restauració de vida.
                soundSource.clip = potionSound;
                soundSource.Play();
                //restem una posió.
                num = num - 1;
                potions.text = (num).ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //swordAtack = true;
            anim.SetBool("SwordAtack", true);
            swordStatus.text = "Activat";
            //anim.SetBool("SwordAtack", false);
            //swordAtack = false;
            soundSource.clip = swordSound;
            soundSource.Play();
            
        }

       
        // atac amb fletxa.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            // comprovem si teneim fletxes.
            arrowsCounterNum = System.Int32.Parse(arrowsCounterText.text);
            //comprovar si tenim fletxes
            if (arrowsCounterNum > 0)
            {
                // desdativem l'escut per atacar amb fletxes.
                anim.SetBool("ShieldAtack", false);
                anim.SetBool("BowAtack", true);


                // quaternion.eduler ens permet aplicar la rotació de la fletxa.

                Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, arrowRotation));

                // restem una fletxa.
                arrowsCounterNum = System.Int32.Parse(arrowsCounterText.text);
                arrowsCounterText.text = (--arrowsCounterNum).ToString();
                soundSource.clip = shootingArrowSound;
                soundSource.Play();

            }
            else
            {
                // no tenim fletxes.
                anim.SetBool("BowAtack", false);
            }
        }

        // Escut.

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (shieldStatus.text == "Activat")
            {
                anim.SetBool("ShieldAtack", true);
                anim.Play("Player_Shield");
                anim.Play("Player_Shield");
                anim.Play("Player_Shield");
                anim.SetBool("ShieldAtack", false);
            }
        }

        // atac amb foc.
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            // comprovem si teneim foc.
            fireCounterNum = System.Int32.Parse(fireCounterText.text);
            //comprovar si tenim fletxes
            if (fireCounterNum > 0)
            {
                // desdativem l'escut per atacar amb fletxes.
                anim.SetBool("ShieldAtack", false);
                anim.SetBool("PlayerIdle", true);


                // quaternion.eduler ens permet aplicar la rotació del foc.

                //Instantiate(fireShot, transform.position, Quaternion.Euler(0, 0, arrowRotation));
                Instantiate(fireShot, transform.position, Quaternion.Euler(0, 0, arrowRotation));
                // restem un foc.
                fireCounterNum = System.Int32.Parse(fireCounterText.text);
                fireCounterText.text = (--fireCounterNum).ToString();
                soundSource.clip = fireBall;
                soundSource.Play();

            }
            else
            {
                // no tenim fletxes.
                anim.SetBool("BowAtack", false);
            }
        }

        //atack amb destral.
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            if (AxeStatus.text == "Activat")
            {
                anim.SetBool("AxeAtack", true);


                soundSource.clip = swordSound;
                soundSource.Play();
            }  


        }
        

        

       

        // saltem.
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            //shop.SetActive(false);
            if (grounded) {
                jump = true;
                doubleJump = true;
                soundSource.clip = jumpSound;
                soundSource.Play();
            } else if (doubleJump) {
                jump = true;
                doubleJump = false;
                soundSource.clip = jumpSound;
                soundSource.Play();
            }
        }

        // salvem.
        if (Input.GetKeyDown("g"))
        {
            PosPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
            SysGuardar.Guardar_Posicion(PosPlayer);
            soundSource.clip = soundThunder;
            soundSource.Play();
            anim.SetBool("ThunderBool", true);
            anim.Play("Thunder");
            //anim.Play("thunder");
            //anim.SetBool("thunderBool", false);
            // anim.SetBool("PlayerIdle", true);
            //anim.SetBool("thunderBool", false);
            //thunder.SetActive(true);
            //anim.SetBool("thunderBool", false);

            //anim.Play("thunder");
            //thunder.SetActive(false);
        }

        if (Input.GetKeyDown("c"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = SysGuardar.Cargar_Posicion();
            soundSource.clip = soundThunder;
            soundSource.Play();


            anim.SetBool("ThunderBool", true);
            anim.Play("Thunder");
        }
        //Debug.DrawLine(transform.position, target, Color.green);

    }

    void FixedUpdate() {

        //anim.SetBool("SwordAtack", false);

        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded) {
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        if (!movement)
        {
            h = 0;
            //shop.SetActive(false);
        }

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Parallax(h);
            //shop.SetActive(false);
        }

        if (h < -0.1f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Parallax(h);
        }

        if (jump) {
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

    void OnBecameInvisible() {
        transform.position = new Vector3(-1, 0, 0);
    }

    public void EnemyJump() {
        jump = true;
    }

    // Ens ha tocat un enemic.
    public void EnemyKnockBack(float enemyPosX) {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
        spr.color = color;

        // Restem vida enviant y¡un missage a la fució TakeDamage del scrot HealthBar.
        healthbar.SendMessage("TakeDamage", 15);


        soundSource.clip = damageSound;
        soundSource.Play();
    }

    void EnableMovement() {
        movement = true;
        spr.color = Color.white;

        //Parallax();
    }



    // compra del arc.
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "FallinDeath")
        {
            // so recollir moneda.
            soundSource.clip = negativeCoinSound;
            soundSource.Play();
            //Destroy(gameObject);
        }
        if (collider.tag == "PositiveCoin")
        {
            // so recollir moneda.
            soundSource.clip = coinSound;
            soundSource.Play();
        }
        if (collider.tag == "NegativeCoin")
        {
            // so recollir moneda falsa.
            soundSource.clip = negativeCoinSound;
            soundSource.Play();
        }
        if (collider.tag == "Food")
        {
            // so menjar.
            soundSource.clip = foodSound;
            soundSource.Play();
        }
        if (collider.tag == "ItemShop")
        {
            // so fer compra.
            soundSource.clip = itemShopSound;
            soundSource.Play();

        }
        if (collider.tag == "Idol")
        {
            // so recollir ídol.
            nextlevel = true;
            soundSource.clip = idolSound;
            soundSource.Play();
        }

       

        if (collider.tag == "ExtraLife")
        {
            // so recollir vida extra.
            soundSource.clip = idolSound;
            soundSource.Play();
        }

        if (collider.tag == "ShieldArticleShop" || collider.tag == "BowArticleShop" || collider.tag == "PotionArticleShop")
        {
            // comprovem si tenim com a minim 25 monedes.
            sumPositiveCoins = System.Int32.Parse(coinsText.text);
            if (sumPositiveCoins >= 25)
            {
                if (collider.tag == "ShieldArticleShop")
                {
                    //sumPositiveCoins = sumPositiveCoins - 5;
                    //coinsText.text = (sumPositiveCoins).ToString();
                    //Destroy(gameObject);
                    //activem l'arma arc.
                    //anim.SetBool("ShieldAtack", true);
                    shieldStatus.text = "Activat";
                    soundSource.clip = itemShopSound;
                    soundSource.Play();
                }

                if (collider.tag == "BowArticleShop")
                {
                    //sumPositiveCoins = sumPositiveCoins - 5;
                    //coinsText.text = (sumPositiveCoins).ToString();
                    //Destroy(gameObject);
                    //activem l'arma arc.
                    //anim.SetBool("ShieldAtack", true);
                    shieldStatus.text = "Activat";
                    soundSource.clip = itemShopSound;
                    soundSource.Play();
                }
                if (collider.tag == "PotionArticleShop")
                {
                    //sumPositiveCoins = sumPositiveCoins - 5;
                    //coinsText.text = (sumPositiveCoins).ToString();
                    //Destroy(gameObject);
                    //activem l'arma arc.
                    //anim.SetBool("ShieldAtack", true);
                    shieldStatus.text = "Activat";
                    soundSource.clip = itemShopSound;
                    soundSource.Play();
                }
            }
            else
            {
                soundSource.clip = NoitemShopSound;
                soundSource.Play();
            }
        }
        else
        {
            // no tenim prou monedes per comprar 10 fletxes.
            anim.SetBool("BowAtack", false);
            anim.SetBool("ArrowsAmunition", false);
        }


        // recollim el idol i permetem el pas al seguent nivell.
       

        if (collider.tag == "ToIsland")
        {
            soundSource.clip = stoperSound;
            soundSource.Play();
            // Tenim el idol, anem al següent nivell.
            if (nextlevel == true)
            {
                // Tenim el idol, anem al següent fase.
                soundSource.clip = itemShopSound;
                soundSource.Play();
                Destroy(stopToIsland);
                levelText.text="2 Islàndia";
                nextlevel = false;
            }
            else
            {
                // no hem trobat el idol, encara no podem passar de nivell.
                soundSource.clip = negativeCoinSound;
                soundSource.Play();
                //Destroy(stopToIsland);
            }
        }

        if (collider.tag == "ToEngland")
        {
            soundSource.clip = itemShopSound;
            soundSource.Play();
            // Tenim el idol, anem al següent nivell.
            if (nextlevel == true)
            {
                // Tenim el idol, anem al següent fase.
                soundSource.clip = stoperSound;
                soundSource.Play();
                Destroy(stopToEngland);
                nextlevel = false;
                levelText.text = "3 Anglaterra";
            }
            else
            {
                // no hem trobat el idol, encara no podem passar de nivell.
                soundSource.clip = negativeCoinSound;
                soundSource.Play();
                //Destroy(stopToIsland);
            }
        }

        if (collider.tag == "ToFinland")
        {
            soundSource.clip = itemShopSound;
            soundSource.Play();
            // Tenim el idol, anem al següent nivell.
            if (nextlevel == true)
            {
                // Tenim el idol, anem al següent fase.
                soundSource.clip = stoperSound;
                soundSource.Play();
                Destroy(stopToFinland);
                nextlevel = false;
                levelText.text = "4 Finlandia";
            }
            else
            {
                // no hem trobat el idol, encara no podem passar de nivell.
                soundSource.clip = negativeCoinSound;
                soundSource.Play();
                //Destroy(stopToIsland);
            }
        }

        if (collider.tag == "ToHome")
        {
            levelText.text = "5 Casa";
            soundSource.clip = stoperSound;
            soundSource.Play();
            // Tenim el idol, anem al següent nivell.
            //if (nextlevel == true)
           // {
                // Tenim el idol, anem al següent fase.
                soundSource.clip = stoperSound;
                soundSource.Play();
                Destroy(stopToHome);
            //nextlevel = false;
            //SceneManager.UnloadSceneAsync("MainMenu");
            //SceneManager.UnloadScene("Game");
            
                SceneManager.LoadScene("HappyEnding");
           // }
           // else
            //{
                // no hem trobat el idol, encara no podem passar de nivell.
            //    soundSource.clip = negativeCoinSound;
            //    soundSource.Play();
                //Destroy(stopToIsland);
           // }
        }

    }

    

    
}




