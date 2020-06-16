using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public GameObject[] Obstacles;
    //public GameObject player;
    List<int> Zindex = new List<int>(); // record existing obstacles

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("player");
        Create_Obstacle();
    }

    public void Create_Obstacle()
    {
        float StartLength = 15; // obstacle start position 
        float z = transform.position.z + StartLength;

        int prob = Random.Range(0, 100);// Obstacles.Length
        int obsIndex = 0;

        if (prob <= 85)
        {
            obsIndex = 0;
        }
        else if (prob <= 90)
        {
            obsIndex = 1;
        }
        else if (prob <= 95)
        {
            obsIndex = 2;
        }
        else
        {
            obsIndex = 3;
        }

        Vector3 position = GetPos(z, Zindex);
        Debug.Log("position: " + position + "obsIndex: " + obsIndex);

        if (position.z != 0)
        {
            GameObject obj = GameObject.Instantiate(Obstacles[obsIndex], position, Quaternion.identity);
            if (obsIndex == 0)
            {
                if (position.x == -4)
                {
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
            else if (obsIndex == 1)
            {
                obj.tag = "4"; // meterial 1
            }
            else if (obsIndex == 2)
            {
                obj.tag = "5"; // meterial 2
            }
            else
            {
                obj.tag = "6"; // meterial 3
            }
        }
    }

    Vector3 GetPos(float z, List<int> Zindex)
    { 

        int Xindex = Random.Range(-1, 2) * 3; //-4，0，4： three tracks

        int z_int = (int) Mathf.Round(z);

        if (Zindex.Contains(z_int) == true)
        {
            z_int = 0;
            // Debug.Log("z: " + z);
        }
        else
        {
            for (int i = (int)z_int; i <= z_int + 3; i++)
            {
                Zindex.Add(i);
            }
            // Debug.Log("list_length = " + Zindex.ToArray().Length);
            // Debug.Log(z_int);
        }

        return new Vector3(Xindex, 1, z_int);
    }

    // Update is called once per frame
    void Update()
    {
        Create_Obstacle();
    }
}
