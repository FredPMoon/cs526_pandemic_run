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
    //private int scoreNum = 0;
    public Text score;
    public Text collection;
    private string package;
    public GameObject canvas;
    public GameObject shield;
    int[] constraint_x = {-3, 3};
    public Text recipe_1;
    public Text recipe_2;
    public Text recipe_3;
    public bool isShield;
    private string menu_1;
    private string menu_2;
    private string menu_3;
    

    public GameObject frame00; public GameObject frame01; public GameObject frame02; public GameObject frame03; public GameObject frame04;
    public GameObject frame10; public GameObject frame11; public GameObject frame12; public GameObject frame13; public GameObject frame14;
    public GameObject frame20; public GameObject frame21; public GameObject frame22; public GameObject frame23; public GameObject frame24;

    public List<GameObject> frames = new List<GameObject>();

    string[] recipes00 = {"aacx", "bbax", "abbx", "abbx"};
    string[] recipes01 = {"abcy", "bacy", "caby", "acby"};
    string[] recipes02 = {"bbcaz", "cbaaz", "aacbz", "bccaz"};

	public SwipeBehavior swipeBehavior;
	public bool keyPressed = false;
	public float midLanePositionX;
	public float leftLanePositionX;
	public float rightLanePositionX;
	public float groundPositionY;
	public float airPositionY;
	public int jumpFrames;
    public bool shakeTF = false;
    public float playerSpeed;
    public int playerMoveStatus; // 0 means no movement; 1 means left; 2 means right; 3 means jump
    public float laneSwitchStartTime;
    //Vector3 leftLanePlayerPos;
    //Vector3 rightLanePlayerPos;
    //Vector3 midLanePlayerPos;
    float laneSwitchEndX;
    float playerJumpSpeed;
    float gravityForce;
    float playerJumpTime;
    float simulatedY;

    void Start()
    {
		menu_1 = recipes00[0];
        menu_2 = recipes01[0];
        menu_3 = recipes02[0];
        recipe_1.text = format(menu_1);
        recipe_2.text = format(menu_2);
        recipe_3.text = format(menu_3);
        frame00.SetActive(true);
        frame10.SetActive(true);
        frame20.SetActive(true);
        frames.Add(frame00);
        frames.Add(frame01);
        frames.Add(frame02);
        frames.Add(frame03);
        frames.Add(frame04);
        frames.Add(frame10);
        frames.Add(frame11);
        frames.Add(frame12);
        frames.Add(frame13);
        frames.Add(frame14);
        frames.Add(frame20);
        frames.Add(frame21);
        frames.Add(frame22);
        frames.Add(frame23);
        frames.Add(frame24);

        // swipeBehavior = FindObjectOfType<SwipeBehavior>();
		midLanePositionX = transform.position.x;
		//leftLanePositionX = midLanePositionX - 1 * 140f * Time.deltaTime;
		//rightLanePositionX = midLanePositionX + 1 * 140f * Time.deltaTime;
        leftLanePositionX = midLanePositionX - 1 * 140f * 0.02f;
        rightLanePositionX = midLanePositionX + 1 * 140f * 0.02f;
        groundPositionY = transform.position.y;
		airPositionY = 2.5f;
		jumpFrames = 0;
        playerSpeed = 20.0f;
        playerMoveStatus = 0;
        laneSwitchEndX = 1000f;
        //midLanePlayerPos = transform.position;
        //leftLanePlayerPos = new Vector3(leftLanePositionX, transform.position.y, transform.position.z);
        //rightLanePlayerPos = new Vector3(rightLanePositionX, transform.position.y, transform.position.z);
        playerJumpSpeed = 25f;
        gravityForce = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 runPos = transform.position;
		runPos.z = main_camera.transform.position.z + 10;
		transform.position = runPos;

		// if (Input.GetKey(KeyCode.DownArrow))
        //     transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

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
			if (!keyPressed && playerMoveStatus == 0)
			{
				if (transform.position.y == groundPositionY)
				{
					//Vector3 pos = transform.position;
					//pos.y = airPositionY;
					//transform.position = pos;
                    playerMoveStatus = 3;
                    playerJumpTime = Time.time;
                }
				keyPressed = true;
			}
		}

        if (playerMoveStatus != 0) {
            if (playerMoveStatus == 1)
            {
                if (laneSwitchEndX != 1000f)
                {
                    if (transform.position.x == laneSwitchEndX)
                    {
                        playerMoveStatus = 0;
                        laneSwitchEndX = 1000f;
                    }
                    else if (laneSwitchEndX == midLanePositionX)
                    {
                        laneSwitch(rightLanePositionX, midLanePositionX);
                    }
                    else if (laneSwitchEndX == leftLanePositionX)
                    {
                        laneSwitch(midLanePositionX, leftLanePositionX);
                    }
                }
                else if (transform.position.x == rightLanePositionX)
                {
                    laneSwitchEndX = midLanePositionX;
                }
                else if (transform.position.x == midLanePositionX)
                {
                    laneSwitchEndX = leftLanePositionX;
                }
            }

            else if (playerMoveStatus == 2)
            {
                if (laneSwitchEndX != 1000f)
                {
                    if (transform.position.x == laneSwitchEndX)
                    {
                        playerMoveStatus = 0;
                        laneSwitchEndX = 1000f;
                    }
                    else if (laneSwitchEndX == rightLanePositionX)
                    {
                        laneSwitch(midLanePositionX, rightLanePositionX);
                    }
                    else if (laneSwitchEndX == midLanePositionX)
                    {
                        laneSwitch(leftLanePositionX, midLanePositionX);
                    }
                }
                else if (transform.position.x == leftLanePositionX)
                {
                    laneSwitchEndX = midLanePositionX;
                }
                else if (transform.position.x == midLanePositionX)
                {
                    laneSwitchEndX = rightLanePositionX;
                }

            }

            else if (playerMoveStatus == 3) {
                float time = Time.time - playerJumpTime;
                Vector3 pos = transform.position;
                float JumpSpeed = playerJumpSpeed/(main_camera.GetComponent<follow>().speed/5f);
                //simulatedY = groundPositionY + time * JumpSpeed - (0.5f * gravityForce * Mathf.Pow(time, 2));
                float yPos = groundPositionY + time * JumpSpeed - (0.5f * gravityForce * Mathf.Pow(time, 2));
                if (yPos < groundPositionY) {
                    playerMoveStatus = 0;
                    pos.y = groundPositionY;
                    transform.position = pos;
                }
                else {
                    if(yPos<7.0f){
                        pos.y = yPos;
                    }else{
                        pos.y = 7.0f;
                    }
                    transform.position = pos;
                }
            }
        }

        if (playerMoveStatus == 0 && Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-3)
		{
			if (!keyPressed && transform.position.y == groundPositionY)
			{
                //if (transform.position.x == midLanePositionX)
                //{
                //	Vector3 pos = transform.position;
                //	pos.x = leftLanePositionX;
                //	transform.position = pos;
                //}
                //else if (transform.position.x == rightLanePositionX)
                //{
                //	Vector3 pos = transform.position;
                //	pos.x = midLanePositionX;
                //	transform.position = pos;
                //}

                playerMoveStatus = 1;
                laneSwitchStartTime = Time.time;

				keyPressed = true;
			}
		}

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<3)
		{
			if (!keyPressed && transform.position.y == groundPositionY)
			{
                //if (transform.position.x == midLanePositionX)
                //{
                //	Vector3 pos = transform.position;
                //	pos.x = rightLanePositionX;
                //	transform.position = pos;
                //}
                //else if (transform.position.x == leftLanePositionX)
                //{
                //	Vector3 pos = transform.position;
                //	pos.x = midLanePositionX;
                //	transform.position = pos;
                //}

                playerMoveStatus = 2;
                laneSwitchStartTime = Time.time;
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

        if (shakeTF == true){
        StartCoroutine(Shake(0.5f, 0.075f));
        shakeTF = false;
        }
    }

    void laneSwitch(float startX, float endX)
    {
        float y = transform.position.y;
        float z = transform.position.z;
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - laneSwitchStartTime) * playerSpeed;
        float fractionOfJourney = distCovered / (midLanePositionX - leftLanePositionX);
        transform.position = Vector3.Lerp(new Vector3(startX, y, z), new Vector3(endX, y, z), fractionOfJourney);

    }


    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        // if(collider.gameObject.tag.Equals("1")||collider.gameObject.tag.Equals("2")||collider.gameObject.tag.Equals("3")){
        //     scoreNum += 1;
        //     score.text = "Score: " + scoreNum;
        //     Destroy(collider.gameObject);
        //     //PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+1);
        // }
        if(tag.Equals("a")||tag.Equals("b")||tag.Equals("c")||tag.Equals("d")||tag.Equals("e")){
            package = package + tag;
            package = compare(package, menu_1, menu_2, menu_3);
            collection.text = package;
            Destroy(collider.gameObject);
            recipeCheck(package);
        }
        if(collider.gameObject.tag.Equals("positive")){
            failure.SetActive(true);
            Destroy(collider.gameObject);
            stop();
        }
        if(collider.gameObject.tag.Equals("p")){
            shakeTF = true;
            if(isShield==false){
                failure.SetActive(true);
                stop();
            }else{
                isShield = false;
                shield.SetActive(false);
            }
            Destroy(collider.gameObject);
        }
        //Debug.Log(collider.gameObject.tag);
        
    }

    public void stop(){
        follow other = (follow)main_camera.GetComponent(typeof(follow));
        other.stop();
    }

    //实现配方提示
    void recipeCheck(string collected)
    {
      int l = collected.Length;
      if(l==0){
          frames[menu_1.Length-2].SetActive(false);
          frame00.SetActive(true);
          frames[menu_2.Length+3].SetActive(false);
          frame10.SetActive(true);
          frames[menu_3.Length+8].SetActive(false);
          frame20.SetActive(true);
      }else{
          if(collected.Equals(menu_1.Substring(0, l))){
              frames[l].SetActive(true);
              frames[l-1].SetActive(false);
          }else{
              for(int i = 0; i < 5; i++){
                  frames[i].SetActive(false);
              }
          }
          if(collected.Equals(menu_2.Substring(0, l))){
            frames[l+5].SetActive(true);
            frames[l+4].SetActive(false);
          }else{
              for(int i = 5; i < 10; i++){
                  frames[i].SetActive(false);
              }
          }
          if(collected.Equals(menu_3.Substring(0, l))){
            frames[l+10].SetActive(true);
            frames[l+9].SetActive(false);
          }else{
              for(int i = 10; i < 15; i++){
                  frames[i].SetActive(false);
              }
          }
      } 

    }

     void powerUp_x()
    {
        //实现屏幕震动
        //shakeTF = true;
        //添加保护层
        isShield = true;
        shield.SetActive(true);
        Debug.Log("X");
    }

    void powerUp_y()
    {
        //shakeTF = true;
        //slow the camera move speed
        main_camera.GetComponent<follow>().speed -= 2f;
        Debug.Log("Y");
    }

    void powerUp_z()
    {
        //clear the infected, positive patients
        GameObject[] patients = GameObject.FindGameObjectsWithTag("p");
        foreach(GameObject patient in patients){
            Destroy(patient);
        }
        Debug.Log("Z");
    }

    //与所有配方一一比对
    // collected = package + ingredient
    string compare(string collected, string recipe1, string recipe2, string recipe3)
    {
        int length = collected.Length;
        string subRecipe1 = recipe1.Substring(0, length);
        string subRecipe2 = recipe2.Substring(0, length);
        string subRecipe3 = recipe3.Substring(0, length);
        if(collected.Equals(subRecipe1)){
            if(length == recipe1.Length - 1){
                switch(recipe1[recipe1.Length-1]){
                    case 'x': powerUp_x(); updateRecipe(); return "";
                    case 'y': powerUp_y(); updateRecipe(); return "";
                    case 'z': powerUp_z(); updateRecipe(); return "";

                }
            }else if (length < recipe1.Length - 1){
                return collected;
            }
        }else if(collected.Equals(subRecipe2)){
            if(length == recipe2.Length - 1){
                switch(recipe2[recipe2.Length-1]){
                    case 'x': powerUp_x(); updateRecipe(); return "";
                    case 'y': powerUp_y(); updateRecipe(); return "";
                    case 'z': powerUp_z(); updateRecipe(); return "";

                }
            }else if (length < recipe2.Length - 1){
                return collected;
            }
        }else if(collected.Equals(subRecipe3)){
            if(length == recipe3.Length - 1){
                switch(recipe3[recipe3.Length-1]){
                    case 'x': powerUp_x(); updateRecipe(); return "";
                    case 'y': powerUp_y(); updateRecipe(); return "";
                    case 'z': powerUp_z(); updateRecipe(); return "";

                }
            }else if (length < recipe3.Length - 1){
                return collected;
            }
        }else {
            return collected.Substring(0, length-1);
        }
        Debug.Log("unexpected");
        return "";
    }

    string format(string str){
        string newStr = "";
        foreach(char c in str.Substring(0, str.Length-2)){
            newStr = newStr + c + " - ";
        }
        return (newStr+str[str.Length - 2]).ToUpper();
    }
    void updateRecipe()
    {

    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = main_camera.transform.position;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            main_camera.transform.position = new Vector3(x, y+main_camera.transform.position.y, main_camera.transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        main_camera.transform.position = orignalPosition;
    }

}
