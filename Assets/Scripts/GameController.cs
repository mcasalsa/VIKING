using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
    //public float parallaxSpeed = 0.02f;
   // public RawImage background00, background01, background02;
    //public RawImage background03;
   // public RawImage platform;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       //Parallax();
    }

    //void Parallax(){
       // per a cada fotograma es calcula la velocitat final del terra i els diferents backgrouns que conformen el parallax.
      // float finalSpeed = parallaxSpeed * Time.deltaTime;
      // background00.uvRect = new Rect(background00.uvRect.x+ 1f, 1f, 1f, 1f);
      // background01.uvRect = new Rect(background01.uvRect.x + finalSpeed * 0.1f, 1f, 1f, 1f);
      // background02.uvRect = new Rect(background02.uvRect.x + finalSpeed * 0.4f, 1f, 1f, 1f);
       //background03.uvRect = new Rect(background03.uvRect.x + finalSpeed * 0.4f, 1f, 1f, 1f);
       //platform velocity = background velocity * 4;
      // platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 0.50f, 0f, 1f, 1f);
    //}
}
