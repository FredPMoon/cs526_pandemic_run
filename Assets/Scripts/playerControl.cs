using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed =10f;
    public GameObject failure;
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
        Debug.Log("do");
        if(collider.gameObject.tag.Equals("1")||collider.gameObject.tag.Equals("2")||collider.gameObject.tag.Equals("3")){
            //Debug.Log("2");
            //failure.SetActive(true);
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.tag.Equals("positive")){
            //Debug.Log("2");
            failure.SetActive(true);
            Destroy(collider.gameObject);
        }
        //Debug.Log(collider.gameObject.tag);
        
    }
}
