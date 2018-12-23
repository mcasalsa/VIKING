using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FalligDeathController : MonoBehaviour {
    private GameObject healthbar;
    // Use this for initialization
    void Start () {
        healthbar = GameObject.Find("Healthbar");
    }
	
	// Update is called once per frame
	void Update () {
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


    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player")
        {
           healthbar.SendMessage("TakeDamage", 101);
           GameObject.FindGameObjectWithTag("Player").transform.position = SysGuardar.Cargar_Posicion();
        }
    }







}
