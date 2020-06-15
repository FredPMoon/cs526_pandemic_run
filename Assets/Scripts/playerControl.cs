using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public float moveSpeed =10f;
    public GameObject failure;
    public GameObject main_camera;
    private int scoreNum = 0;
    public Text score;
    public string package;
    public GameObject canvas;
    int[] constraint_x = {-3, 3};
    public GameObject recipe_1;
    public GameObject recipe_2;
    public GameObject recipe_3;
    private string menu_1;
    private string menu_2;
    private string menu_3;

    string[] recipes00 = {"aacx", "bbax", "abbx", "abbx"};
    string[] recipes01 = {"abcy", "bacy", "caby", "acby"};
    string[] recipes02 = {"bbcaz", "cbaaz", "aacbz", "bccaz"};
    void Start()
    {
        menu_1 = recipes00[0];
        menu_2 = recipes01[0];
        menu_3 = recipes02[0];
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
        // if(collider.gameObject.tag.Equals("1")||collider.gameObject.tag.Equals("2")||collider.gameObject.tag.Equals("3")){
        //     scoreNum += 1;
        //     score.text = "Score: " + scoreNum;
        //     Destroy(collider.gameObject);
        //     //PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+1);
        // }
        string ingredient = collider.gameObject.tag;
        // switch(ingredient){
        //     case "a": break;
        //     case "b": break;
        //     case "c": break;
        //     case "d": break;
        //     case "e": break;
        // }
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

    void recipeCheck()
    {
        int old = package.Length;

    }

     void powerUp_x()
    {
        //实现屏幕震动
        //adding health
        Debug.Log("X");
    }

    void powerUp_y()
    {
        //slow the camera move speed
        Debug.Log("Y");
    }

    void powerUp_z()
    {
        //clear the infected, positive patients
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


    void updateRecipe()
    {

    }
}
