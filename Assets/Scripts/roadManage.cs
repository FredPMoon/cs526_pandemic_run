using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManage : MonoBehaviour
{
    public road road1;
    public road road2;
    public road road3;
    public road road4;
    private int roadCount = 3;      //生成的第几个路径用于确定位置
 
    public GameObject[] roads;    //供随机生成的不同路径Prefabs;

    public GameObject road;
 
    public static roadManage _instance;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRoad()
    {
        roadCount++;
        int type = Random.Range(0, roads.Length);
        //GameObject newRoad = Instantiate(roads[type], new Vector3(0, 0, roadCount), Quaternion.identity) as GameObject;
        Debug.Log(roadCount);
        GameObject newRoad = Instantiate(road, new Vector3(3, 0, (roadCount*10)+2), Quaternion.identity) as GameObject;
        road1 = road2;
        road2 = road3;
        road3 = road4;
        road4 = newRoad.GetComponent<road>();
    }
}
