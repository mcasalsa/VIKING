using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Sword : MonoBehaviour
{

    private Animator anim;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // si piquem amb una 'carcaj' de fletxes hem de comrpbar si tenim 10 monedes per adquirirlo.


        
            if (collider.tag == "Player")
            {
                Destroy(gameObject);
                //anim.SetBool("Disarmed", false);
            //anim.SetBool("ShieldAtack", true);
        }
           
        

    }
}
