using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
using System.Threading;

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

        //long tick = System.DateTime.Now.Ticks;
        //System.Random rd = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        System.Random rd = new System.Random();
        int prob = rd.Next(0, 100);

        int obsIndex = 0;

        if (prob <= 64)
        {
            obsIndex = 0;
        }
        else if (prob <= 76)
        {
            obsIndex = 1;
        }
        else if (prob <= 88)
        {
            obsIndex = 2;
        }
        else
        {
            obsIndex = 3;
        }

        Vector3 position = GetPos(z, Zindex);
        //Debug.Log("position: " + position + "obsIndex: " + obsIndex);

        if (position.z != 0)
        {
            GameObject obj = GameObject.Instantiate(Obstacles[obsIndex], position, Quaternion.identity);
            if (obsIndex == 0)
            {
                // if (position.x == -4)
                // {
                //     obj.tag = "1";
                // }
                // else if (position.x == 0)
                // {
                //     obj.tag = "2";
                // }
                // else
                // {
                //     obj.tag = "3";
                // }
                obj.tag = "p";
            }
            else if (obsIndex == 1)
            {
                obj.tag = "a"; // meterial 1
            }
            else if (obsIndex == 2)
            {
                obj.tag = "b"; // meterial 2
            }
            else
            {
                obj.tag = "c"; // meterial 3
            }
        }
    }

    Vector3 GetPos(float z, List<int> Zindex)
    {

        int z_int = (int)Mathf.Round(z);

        int iSeed = z_int;
        System.Random rd = new System.Random(iSeed);

        //int iSeed = System.Guid.NewGuid().GetHashCode();
        //System.Random rd = new System.Random(iSeed);

        //long tick = System.DateTime.Now.Ticks;
        //System.Random rd = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

        //System.Random rd = new System.Random();

        int Xindex = rd.Next(-1, 2) * 3; //-4，0，4： three tracks

        if (Zindex.Contains(z_int) == true)
        {
            z_int = 0;
            // Debug.Log("z: " + z);
        }
        else
        {
            for (int i = (int)z_int; i <= z_int + 2; i++)
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
