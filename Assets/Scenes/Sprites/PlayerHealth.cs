using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{


    public int hearts = 6;

    public AudioClip hitSound;
    //animació de mort
    public GameObject deathAnim;
    //3 textures en forma de cor per les vides
    public Texture heartWhole;
    public Texture heartHalf;
    public Texture heartEmpty;
    
    public AudioClip heartSound;

    private bool dead = false;
    private bool canGetHurt = true;
    private SpriteRenderer rend;
    private GUITexture[] heartsGUI;
    private int health;
    //private GUIText points;
    public GUIText lifesGuiText;
    public int lifesnum;

    void Start()
    {
        health = hearts * 2;
        GameObject getHearts = GameObject.Find("GUI/hearts");
        getHearts.SendMessage("addHearts", hearts, SendMessageOptions.DontRequireReceiver);
        GUITexture[] allChildren = getHearts.GetComponentsInChildren<GUITexture>();
        heartsGUI = new GUITexture[allChildren.Length];
        health = allChildren.Length * 2;
        for (int i = 0; i < allChildren.Length; i++)
        {
            heartsGUI[i] = allChildren[i] as GUITexture;
        }
        rend = GetComponent<SpriteRenderer>();
        lifesnum = 3;
    }

    void takeDamage(int amount)
    {
        if (canGetHurt && !dead)
        {
            canGetHurt = false;
            GetComponent<AudioSource>().PlayOneShot(hitSound);
            health -= amount;
            StartCoroutine(checkHealth());
            StartCoroutine(resetCanHurt());
        }
    }

    //piquem contra un enemic. hem de comprovar que  fa 0.25 segons que no ho fem per contabilitzar el dany.
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy" || other.tag == "spikes")
        {
            if (canGetHurt && !dead)
            {
                canGetHurt = false;
                GetComponent<AudioSource>().PlayOneShot(hitSound);
                health -= 1;
                StartCoroutine(checkHealth());
                StartCoroutine(resetCanHurt());
            }
        }
        //Gaunyem una vida.
        if (other.GetComponent<Collider>().tag == "heart")
        {
            Destroy(other.gameObject);
            addHealth();
        }
    }

    //piquem amb enemics amb collider am triggers.
    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "enemy" || other.collider.tag == "spikes")
        {
            if (canGetHurt && !dead)
            {
                canGetHurt = false;
                GetComponent<AudioSource>().PlayOneShot(hitSound);
                health -= 1;
                StartCoroutine(checkHealth());
                StartCoroutine(resetCanHurt());
            }
        }
    }

    public IEnumerator resetCanHurt()
    {
        rend.color = new Vector4(1.0f, 0.25f, 0.25f, 1.0f);
        yield return new WaitForSeconds(0.25f);
        rend.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        canGetHurt = true;
    }

    //testeig de la vitalitat quan ens ha atacat un enemic
    public IEnumerator checkHealth()
    {
        //aquí actualitzem els cors a la pantalla perquè mostrin un import segur de salut
        updateHearts();

       // Si la salut és 0, farem tot això una vegada, per la qual cosa comprovem si la mort era anteriorment falsa.
        // es desactiva un munt de coses com la física, els representants, les seqüències d'ordres i, a continuació, espera 3 segons abans de tornar a carregar l'escena.
        if (health <= 0 && dead == false)
        {
            dead = true;
            Instantiate(deathAnim, transform.position, Quaternion.Euler(0, 180, 0));
            BroadcastMessage("died", SendMessageOptions.DontRequireReceiver);
            var rend = GetComponent<SpriteRenderer>();
            rend.enabled = false;



            lifesnum = PlayerPrefs.GetInt("lifesNum");
            lifesnum = lifesnum - 1;

            PlayerPrefs.SetInt("lifesNum", lifesnum);


            yield return new WaitForSeconds(3);
            string lvlName = Application.loadedLevelName;
            Application.LoadLevel(lvlName);
       }
    }

    //afegim vitalitat
    void addHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(heartSound);
        health += 2;
        // máxim 6 de salut.
        if (health > 6)
        {
            health = 6;
        }
        //actualitzar el contador de marcadors.
        updateHearts();
    }

    void updateHearts()
    {
        //aquí comprovem quanta salut tenim el jugador i, a continuació, apliqueu la textura als cors en GUI / hearts en conseqüència
        for (int i = 0; i < heartsGUI.Length; i++)
        {
            int check = (i + 1) * 2;
            if (check < health + 1)
            {
                heartsGUI[i].texture = heartWhole;
            }
            if (check == health + 1)
            {
                heartsGUI[i].texture = heartHalf;
            }
            if (check > health + 1)
            {
                heartsGUI[i].texture = heartEmpty;
            }
        }
    }

    void Update()
    {
        lifesGuiText.text = lifesnum.ToString();
        if (dead == true)
        {

            lifesGuiText.text = lifesnum.ToString();

            lifesnum = lifesnum - 1;
            lifesnum = PlayerPrefs.GetInt("lifesNum");

            lifesGuiText.text = lifesnum.ToString();
            PlayerPrefs.SetInt("lifesNum", lifesnum);



            string lvlName = Application.loadedLevelName;
            Application.LoadLevel(lvlName);

        }
    }
}
