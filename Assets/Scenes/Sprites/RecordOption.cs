using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class RecordOption : MonoBehaviour
{
    public Text rText;
    public Text sText;

    // Use this for initialization
    void Start()
    {
        // recuperem el record des de PlayerPrefs

        //rText.text = GetMaxRecord().ToString();
        rText.text = GetMaxRecord().ToString();
        //sText.text = GetCurScore().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // funcions de record de puntuació.
    public int GetMaxRecord()
    {
        return PlayerPrefs.GetInt("Max Points",0);
    }

    public int GetCurScore()
    {
        return PlayerPrefs.GetInt("Cur Points", 0);
    }

    //public void SaveScore()
    //{
    //    PlayerPrefs.SetInt("Max Points", currentPointsNum);
    //}


}
