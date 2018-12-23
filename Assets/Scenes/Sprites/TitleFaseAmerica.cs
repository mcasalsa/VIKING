using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFaseAmerica : MonoBehaviour {
    private float startTime;
    public GameObject titleFase;
   // public AudioClip soundTitleFase;
   // AudioSource soundSource;
    // Use this for initialization
    void Start () {
        startTime = 0;
        titleFase = GameObject.Find("TitlePhaseA");
        //soundSource.clip = soundTitleFase;
        //soundSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        ++startTime;
        if (startTime > 200)
        {
            Destroy(titleFase);
        }
	}
}
