using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseAmerica : MonoBehaviour {
    private float tstart;
    private float tend;
	// Use this for initialization
	void Start () {
        tstart = 0f;
        tend = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        ++tstart;
        
	}
}