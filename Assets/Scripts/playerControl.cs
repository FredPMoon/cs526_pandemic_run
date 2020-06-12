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
    public GameObject main_camera;
    private int scoreNum = 0;
    public Text score;
    public GameObject canvas;
    int[] constraint_x = {-3, 3};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&transform.position.z<(main_camera.transform.position.z+20))
            transform.Translate(Vector3.forward * moveSpeed*Time.deltaTime);
 
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
 
        if (Input.GetKey(KeyCode.LeftArrow)&&transform.position.x>-3)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //transform.Translate(Vector3.left * moveSpeed * 0.1f);
 
        if (Input.GetKey(KeyCode.RightArrow)&&transform.position.x<3)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //transform.Translate(Vector3.right * moveSpeed * 0.1f);
        
        if(transform.position.z<main_camera.transform.position.z){
            canvas.SetActive(false);
            failure.SetActive(true);
            stop();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag.Equals("1")||collider.gameObject.tag.Equals("2")||collider.gameObject.tag.Equals("3")){
            scoreNum += 1;
            score.text = "Score: " + scoreNum;
            Destroy(collider.gameObject);
            //PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+1);
        }
        if(collider.gameObject.tag.Equals("positive")){
            failure.SetActive(true);
            Destroy(collider.gameObject);
            stop();
        }
        //Debug.Log(collider.gameObject.tag);
        
    }

    public void stop(){
        follow other = (follow)main_camera.GetComponent(typeof(follow));
        other.stop();
    }
}
