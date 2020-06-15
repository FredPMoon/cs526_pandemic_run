using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    //tag - 1/2/3 对应跑道位置
    //tag - positive 在player触碰后游戏结束
    public float moveSpeed = 10f;
    public GameObject failure;
    public GameObject main_camera;
    private int scoreNum = 0;
    public Text score;
    public GameObject canvas;
    int[] constraint_x = {-3, 3};

	public SwipeBehavior swipeBehavior;
	public bool keyPressed = false;
	public float midLanePositionX;
	public float leftLanePositionX;
	public float rightLanePositionX;
	public float groundPositionY;
	public float airPositionY;
	public int jumpFrames;

    void Start()
    {
        // swipeBehavior = FindObjectOfType<SwipeBehavior>();
		midLanePositionX = transform.position.x;
		leftLanePositionX = midLanePositionX - 1 * 140f * Time.deltaTime;
		rightLanePositionX = midLanePositionX + 1 * 140f * Time.deltaTime;
		groundPositionY = transform.position.y;
		airPositionY = groundPositionY + 80f * Time.deltaTime;
		jumpFrames = 0;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.forward * 5f*Time.deltaTime);

		if (transform.position.y == airPositionY)
		{
			if (jumpFrames < 60)
			{
				jumpFrames++;
			}
			else
			{
				Vector3 pos = transform.position;
				pos.y = groundPositionY;
				transform.position = pos;
				jumpFrames = 0;
			}
		}

        if (Input.GetKey(KeyCode.UpArrow))
		{
			if (!keyPressed)
			{
				if (transform.position.y == groundPositionY)
				{
					Vector3 pos = transform.position;
					pos.y = airPositionY;
					transform.position = pos;
				}
				keyPressed = true;
			}
		}

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-3)
		{
			if (!keyPressed)
			{
				if (transform.position.x == midLanePositionX)
				{
					Vector3 pos = transform.position;
					pos.x = leftLanePositionX;
					transform.position = pos;
				}
				else if (transform.position.x == rightLanePositionX)
				{
					Vector3 pos = transform.position;
					pos.x = midLanePositionX;
					transform.position = pos;
				}
				keyPressed = true;
			}
		}

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<3)
		{
			if (!keyPressed)
			{
				if (transform.position.x == midLanePositionX)
				{
					Vector3 pos = transform.position;
					pos.x = rightLanePositionX;
					transform.position = pos;
				}
				else if (transform.position.x == leftLanePositionX)
				{
					Vector3 pos = transform.position;
					pos.x = midLanePositionX;
					transform.position = pos;
				}
				keyPressed = true;
			}
		}

		if ((!Input.GetKey(KeyCode.LeftArrow)) && (!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.UpArrow)))
		{
			keyPressed = false;
		}
            
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
