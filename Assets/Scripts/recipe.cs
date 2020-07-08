using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipe : MonoBehaviour
{
    static string elements = "abcde";
    char[] ingredients = elements.ToCharArray();

    public GameObject recipe_1;
    public GameObject recipe_2;
    public GameObject recipe_3;
    string[] recipes00 = {"aacx", "bbax", "abbx", "abbx"};
    string[] recipes01 = {"abcy", "bacy", "caby", "acby"};
    string[] recipes02 = {"bbcaz", "cbaaz", "aacbz", "bccaz"};

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void powerUp_x()
    {
        //adding health
        Debug.Log("X");
    }

    void powerUp_y()
    {
        //slow the camera move speed
        Debug.Log("Y");
    }

    void powerUp_z()
    {
        //clear the infected, positive patients
        Debug.Log("Z");
    }
    
}
