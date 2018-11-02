using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {
    //public float parallaxSpeed = 0.02f;
    // public RawImage background00, background01, background02;
    //public RawImage background03;
    // public RawImage platform;

   // public int currentPointsNum;
    public Text currentPointsText;
    private int currentPointsNum;
    public Text recordText;
    //public AudioClip recordSound;
    //AudioSource soundSource;


    // Use this for initialization
    void Start () {
        // inicialment guardarem record 0 al PlayerPrefs
        currentPointsNum = 0;
        recordText.text = GetMaxScore().ToString();
        //soundSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //Parallax();
        currentPointsNum = System.Int32.Parse(currentPointsText.text);
        if (currentPointsNum >= GetMaxScore());
        {
            // hem fet record i el desem.
            PlayerPrefs.SetInt("Max Points", currentPointsNum);
             // so.

            //soundSource.clip = recordSound;
            //soundSource.Play();
        }
        //PlayerPrefs.SetInt("Max Points", currentPointsNum);
        //coinsText.text = (++sumPositiveCoins).ToString();
        



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

    // funcions de record de puntuació.
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    //public void SaveScore()
    //{
    //    PlayerPrefs.SetInt("Max Points", currentPointsNum);
    //}


}
