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
    //private int infection_1 = 0;
    //private int infection_2 = 0;
    //private int infection_3 = 0;
    public Text distance;
    private string roadColor;
    private int roadCount = 3;      //生成的第几个路径用于确定位置
 
    public GameObject[] roads;    //供随机生成的不同路径Prefabs;

    public GameObject road;
 
    public static roadManage _instance;
    // Start is called before the first frame update
    void Start()
    {
        distance.text = "Distance: " + roadCount;
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        RoadPainting();
    }

    public void RoadPainting(){
        GameObject[] paths_1 = GameObject.FindGameObjectsWithTag("path1");
        foreach(GameObject path in paths_1){
            path.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        // GameObject[] obstacles = GameObject.FindGameObjectsWithTag("1");
        // foreach(GameObject obstacle in obstacles){
        //     obstacle.tag = "positive";
        //     obstacle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // }
        GameObject[] paths_2 = GameObject.FindGameObjectsWithTag("path2");
        foreach(GameObject path in paths_2){
            path.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        GameObject[] paths_3 = GameObject.FindGameObjectsWithTag("path3");
        foreach(GameObject path in paths_3){
            path.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
    }
    public void GenerateRoad()
    {
        roadCount++;
        distance.text = "Distance: " + roadCount;
        int type = Random.Range(0, roads.Length);
        //GameObject newRoad = Instantiate(roads[type], new Vector3(0, 0, roadCount), Quaternion.identity) as GameObject;
        //Debug.Log(roadCount);
        GameObject newRoad = Instantiate(road, new Vector3(3, 0, (roadCount*10)+2), Quaternion.identity) as GameObject;
        road1 = road2;
        road2 = road3;
        road3 = road4;
        road4 = newRoad.GetComponent<road>();
        //RoadPainting();
    }
}
