using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {
    public Text currentPointsText;
    private int currentPointsNum;
    public Text recordText;
    


    // Use this for initialization
    void Start () {
        // inicialment guardarem record 0 al PlayerPrefs
        currentPointsNum = 0;
        recordText.text = GetMaxScore().ToString();

    }
	
	// Update is called once per frame
	void Update () {
        //Parallax();
        currentPointsNum = System.Int32.Parse(currentPointsText.text);
        PlayerPrefs.SetInt("Cur Points", currentPointsNum);
        if (currentPointsNum >= GetMaxScore())
        {
            // hem fet record i el desem.
            PlayerPrefs.SetInt("Max Points", currentPointsNum);
            
       }

        



    }

    
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }
    public int GetCurScore()
    {
        return PlayerPrefs.GetInt("Cur Points", 0);
    }

    


}
