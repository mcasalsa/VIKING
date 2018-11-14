using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
   // heart sprites.
    public Sprite[] hearts;

    // Use this for initialization
    void Start()
    {
       ChangeLife(3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ChangeLife(int pos)
    {
        this.GetComponent<Image>().sprite = hearts[pos];
    }
}
