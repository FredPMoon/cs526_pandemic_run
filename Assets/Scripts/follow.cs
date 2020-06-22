using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float timer = 2.0f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        
        if(speed > 0f && speed < 5f){
            timer -= Time.deltaTime;
            if(timer <= 0){
                speedUp();
                timer = 2.0f;
            }
        }
    }

    public void stop(){
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        speed = 0f;
    }

    public void speedUp(){
        speed += 1.0f;
    }
}
