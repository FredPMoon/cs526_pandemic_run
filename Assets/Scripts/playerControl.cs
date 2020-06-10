using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    //tag - 1/2/3 对应跑道位置
    //tag - positive 在player触碰后游戏结束
    public float moveSpeed =10f;
    public GameObject failure;
    public GameObject camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed*Time.deltaTime);
 
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag.Equals("1")||collider.gameObject.tag.Equals("2")||collider.gameObject.tag.Equals("3")){
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag.Equals("positive")){
            failure.SetActive(true);
            Destroy(collider.gameObject);
            stop();
        }
        //Debug.Log(collider.gameObject.tag);
        
    }

    public void stop(){
        follow other = (follow)camera.GetComponent(typeof(follow));
        other.stop();
    }
}
