using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roadManage : MonoBehaviour
{
    public road road1;
    public road road2;
    public road road3;
    public road road4;
    public Text distance;
    private string roadColor;
    private int roadCount = 3;      //生成的第几个路径用于确定位置
    //public List<GameObject> roads = new List<GameObject>();
    //public GameObject[] roads;    //供随机生成的不同路径Prefabs;
    public GameObject road;
    //public GameObject r1;
    //public GameObject r2;
    
 
    public static roadManage _instance;
    // Start is called before the first frame update
    void Start()
    {
        //roads.Add(road);
        //roads.Add(r1);
        //roads.Add(r2);

        distance.text = "Distance: " + roadCount;
        _instance = this;
        PlayerPrefs.SetInt("infection_1", 0);
        PlayerPrefs.SetInt("infection_2", 0);
        PlayerPrefs.SetInt("infection_3", 0);
    }

    // Update is called once per frame
    void Update()
    {
        RoadPainting();
        GameObject[] patients = GameObject.FindGameObjectsWithTag("positive");
        foreach(GameObject patient in patients){
            patient.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        // GameObject[] patients = GameObject.FindGameObjectsWithTag("p");
        // foreach(GameObject patient in patients){
        //     GameObject c = patient.transform.Find("Cube").gameObject;
        //     c.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // }
        if(roadCount>=90){
            PlayerPrefs.SetInt("difficulty", 2);
        }else if(roadCount>=60){
            PlayerPrefs.SetInt("difficulty", 1);
        }else{
            PlayerPrefs.SetInt("difficulty", 0);
        }
    }

    public void RoadPainting(){
        int infection1 = PlayerPrefs.GetInt("infection_1");
        int infection2 = PlayerPrefs.GetInt("infection_2");
        int infection3 = PlayerPrefs.GetInt("infection_3");
        //path1
        if(infection1>=10){
            GameObject[] paths_1 = GameObject.FindGameObjectsWithTag("path1");
            foreach(GameObject path in paths_1){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("1");
            foreach(GameObject obstacle in obstacles){
                obstacle.tag = "positive";
                //obstacle.GetComponent<Renderer>().material.SetColor("_color", Color.magenta);
            }
        }else if(infection1>=5){
            GameObject[] paths_1 = GameObject.FindGameObjectsWithTag("path1");
            foreach(GameObject path in paths_1){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }else{
            GameObject[] paths_1 = GameObject.FindGameObjectsWithTag("path1");
            foreach(GameObject path in paths_1){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
        }
        //path2
        if(infection2>=10){
            GameObject[] paths_2 = GameObject.FindGameObjectsWithTag("path2");
            foreach(GameObject path in paths_2){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("2");
            foreach(GameObject obstacle in obstacles){
                obstacle.tag = "positive";
                //obstacle.GetComponent<Renderer>().material.SetColor("_color", Color.magenta);
            }
        }else if(infection2>=5){
            GameObject[] paths_2 = GameObject.FindGameObjectsWithTag("path2");
            foreach(GameObject path in paths_2){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }else{
            GameObject[] paths_2 = GameObject.FindGameObjectsWithTag("path2");
            foreach(GameObject path in paths_2){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
        }
        //path3
        if(infection3>=10){
            GameObject[] paths_3 = GameObject.FindGameObjectsWithTag("path3");
            foreach(GameObject path in paths_3){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("3");
            foreach(GameObject obstacle in obstacles){
                obstacle.tag = "positive";
                //obstacle.GetComponent<Renderer>().material.SetColor("_color", Color.magenta);
            }
        }else if(infection3>=5){
            GameObject[] paths_3 = GameObject.FindGameObjectsWithTag("path3");
            foreach(GameObject path in paths_3){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }else{
            GameObject[] paths_3 = GameObject.FindGameObjectsWithTag("path3");
            foreach(GameObject path in paths_3){
                path.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
        }
        
    }
    public void GenerateRoad()
    {
        roadCount++;
        distance.text = "Distance: " + roadCount;
        //int type = Random.Range(0, roads.Count);
        
        //GameObject newRoad = Instantiate(roads[type], new Vector3(3, 0, (roadCount*10)+2), Quaternion.identity) as GameObject;
        //Debug.Log(roadCount);
        GameObject newRoad = Instantiate(road, new Vector3(3, 0, (roadCount*10)+2), Quaternion.identity) as GameObject;
        road1 = road2;
        road2 = road3;
        road3 = road4;
        road4 = newRoad.GetComponent<road>();
        //RoadPainting();
    }
}
