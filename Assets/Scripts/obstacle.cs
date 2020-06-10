using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private GameObject main_camera;
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (main_camera.transform.position.z > transform.position.z){
            //计算感染值
            Debug.Log(this.gameObject.tag);
            switch(this.gameObject.tag){
                case "1": PlayerPrefs.SetInt("infection_1", PlayerPrefs.GetInt("infection_1")+1); break;
                case "2": PlayerPrefs.SetInt("infection_2", PlayerPrefs.GetInt("infection_2")+1); break;
                case "3": PlayerPrefs.SetInt("infection_3", PlayerPrefs.GetInt("infection_3")+1); break;
            }
            Destroy(this.gameObject);

        }
    }

}
