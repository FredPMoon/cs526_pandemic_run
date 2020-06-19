using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredient : MonoBehaviour
{
    private GameObject main_camera;
    public Text t;
    public GameObject cube;
    
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
        //t = gameObject.Find("text");
        //t = GameObject.Find("Canvas/Text").GetComponent<Text>();
        //randomInfectionCheck();
        t.text = (this.gameObject.tag).ToUpper();
        cube.tag = this.gameObject.tag;
        // if(cube.tag == "p"){
        //     cube.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
         if (main_camera.transform.position.z > transform.position.z-5){
             Destroy(this.gameObject);

        }
    }

    void randomInfectionCheck(){
        int randomNum = Random.Range(0,10);
        if(randomNum>5){
            this.gameObject.tag = "p";
        }
    }
}
