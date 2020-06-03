using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    private GameObject main_camera;
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
        //Debug.Log(main_camera.transform.position.z);
    }

    void Update()
    {
        //Debug.Log(main_camera.transform.position.z);
        if (main_camera.transform.position.z > transform.position.z){
            //Debug.Log("pass"+transform.position.z);
            roadManage._instance.GenerateRoad();
            Destroy(this.gameObject);
        }

    }
}
