using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    //here are public variables that can be edited in the inspector for the players health.
    public int hearts = 6;
    //sound when he's hit
    public AudioClip hitSound;
    //death animation if he dies
    public GameObject deathAnim;
    //the 3 different heart textures that will be changed in the hearts at the top of the screen depending on his health.
    public Texture heartWhole;
    public Texture heartHalf;
    public Texture heartEmpty;
    //the sound if a heart is picked up
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

    //here we check to see if the we hit an enemy or spikes, but we won't get hurt if our color was changed because that was the indication that we were hurt not too long ago. like 0.25 seconds ago.
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
        //if its a heart though, we want health back instead of taken away.
        if (other.GetComponent<Collider>().tag == "heart")
        {
            Destroy(other.gameObject);
            addHealth();
        }
    }

    //this is the same as ontriggerstay, but for enemy's whose colliders aren't triggers.
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

    //here we checkhealth when a player is hit by an enemy.
    public IEnumerator checkHealth()
    {
        //here we update the hearts on the screen so that they show an accurate health amount
        updateHearts();
        // lifesNum = System.Int32.Parse(lifesGuiText.text);

        //lifesNum = lifesNum - 1;

        // if health is 0 then we're going to do all of this stuff once, which is why we check to see if dead was previously false.
        //it turns off a bunch of stuff like physics, renderers, scripts, then waits for 3 seconds before it reloads the scene again.	
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
            //incrementem 50 punts el marcador.

            //System.Int32.Parse(pointsText.text);
            //sumPositiveCoins = System.Int32.Parse(coinsText.text);

        }
    }

    //here we add health back.
    void addHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(heartSound);
        health += 2;
        //if the players health is more than 6, we want to make sure its 6 because thats the max we chose.
        if (health > 6)
        {
            health = 6;
        }
        //here we update the hearts on the screen so that they show an accurate health amount
        updateHearts();
    }

    void updateHearts()
    {
        //here we check how much health the player has, then apply the texture to the hearts in GUI/hearts accordingly
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


            // yield return new WaitForSeconds(3);
            string lvlName = Application.loadedLevelName;
            Application.LoadLevel(lvlName);

        }
    }
}
