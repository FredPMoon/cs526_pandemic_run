using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private GameObject main_camera;
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
        infectionCheck();
        Debug.Log(this.gameObject.tag);
    }

    void Update()
    {
        if (main_camera.transform.position.z > transform.position.z-5){
            //计算感染值
            //string tag = this.gameObject.tag;
            //Debug.Log(this.gameObject.tag);
            switch(this.gameObject.tag){
                case "1": Debug.Log("1++");PlayerPrefs.SetInt("infection_1", PlayerPrefs.GetInt("infection_1")+1); break;
                case "2": Debug.Log("2++");PlayerPrefs.SetInt("infection_2", PlayerPrefs.GetInt("infection_2")+1); break;
                case "3": Debug.Log("3++");PlayerPrefs.SetInt("infection_3", PlayerPrefs.GetInt("infection_3")+1); break;
            }

            Destroy(this.gameObject);

        }
    }

    void infectionCheck(){
        switch(this.gameObject.tag){
            case "1": int infectionRate_1 = PlayerPrefs.GetInt("infection_1"); 
                      randomCheck(infectionRate_1);
                      break;
            case "2": int infectionRate_2 = PlayerPrefs.GetInt("infection_2"); 
                      randomCheck(infectionRate_2);
                      break;
            case "3": int infectionRate_3 = PlayerPrefs.GetInt("infection_3"); 
                      randomCheck(infectionRate_3);
                      break;
        }
    }

    void randomCheck(int infectionRate){
        int randomNum = Random.Range(0,10);
        if(infectionRate>=5){
            if(randomNum>5){
                this.gameObject.tag = "positive";
            }
        }else{
            if(randomNum>8){
                this.gameObject.tag = "positive";
            }
        }
    }


}
