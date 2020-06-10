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
            Destroy(this.gameObject);
        }
    }
    
    // void OnTriggerEnter(Collider col)
    // {
    //     Debug.Log("trigger");
    //     if(col.gameObject.name.Equals("player")){
    //         //判断是否感染,计算检测人数
    //         Destroy(this.gameObject);
    //     }
    // }
}
