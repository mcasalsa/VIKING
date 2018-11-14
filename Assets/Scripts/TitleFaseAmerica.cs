using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFaseAmerica : MonoBehaviour {
    private float startTime;
    public GameObject titleFase;
    // Use this for initialization
    void Start () {
        startTime = 0;
        titleFase = GameObject.Find("Fase-1-America");
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
