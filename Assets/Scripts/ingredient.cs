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
        t.text = (this.gameObject.tag).ToUpper();
        cube.tag = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
         if (main_camera.transform.position.z > transform.position.z-5){
             Destroy(this.gameObject);

        }
    }
}
