using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public GameObject[] Obstacles;
    // public Transform player;
    List<int> Zindex = new List<int>(); // record existing obstacles

    private void Awake()
    {
        //player = GameObject.FindGameObjectsWithTag("player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        Create_Obstacle();
    }

    public void Create_Obstacle()
    {
        float MinLength = 3; // distance between two obstacles
        float MaxLength = 9;
        float StartLength = 1; // obstacle start position

        float startz = transform.position.z;
        float endz = startz + 200;
        float z = transform.position.z + StartLength;

        float x = transform.position.x;

       
        z += Random.Range(MinLength, MaxLength);

        if (z > endz)
        {
            //break;
        }
        else
        {
            int obsIndex = Random.Range(0, Obstacles.Length);
            //print(obsIndex);
         
            Vector3 position = GetPos(x,z,Zindex);
            //Debug.Log(position);
            GameObject obj = GameObject.Instantiate(Obstacles[obsIndex], position, Quaternion.identity);
            if (position.x == -4){
                obj.tag = "1";
            }
            else if (position.x == 0)
            {
                obj.tag = "2";
            }
            else
            {
                obj.tag = "3";
            }
            
        }
}

    Vector3 GetPos(float x, float z, List<int> Zindex)
    { 

        int Xindex = Random.Range(-1, 2) * 4;

        int z_int = (int) Mathf.Round(z);

        if (Zindex.Contains(z_int) == true)
        {
            z_int = 0;
            Debug.Log(z);
        }
        else
        {
            for (int i = (int)z_int - 3; i <= z_int + 3; i++)
            {
                Zindex.Add(z_int);
            }
            //Debug.Log("list_length = " + Zindex.ToArray().Length);
            Debug.Log(z_int);
        }

        return new Vector3(Xindex, 0, z_int);
    }
    // Update is called once per frame
    void Update()
    {
        Create_Obstacle();
    }
}
