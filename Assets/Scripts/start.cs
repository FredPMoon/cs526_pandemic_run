using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Global
//{
//    public static bool is_first;
//} 

public class start : MonoBehaviour
{
    // Start is called before the first frame update

    //private Text levelText;
    private Text levelText1;
    private Text levelText2;
    private Text levelText3;
    private Text levelText4;

    public static bool is_first = true;

    void Start()
    {
        //levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText1 = GameObject.Find("levelText1").GetComponent<Text>();
        levelText2 = GameObject.Find("levelText2").GetComponent<Text>();
        levelText3 = GameObject.Find("levelText3").GetComponent<Text>();
        levelText4 = GameObject.Find("levelText4").GetComponent<Text>();

        //levelText.text = "Tutorial";
        levelText1.text = "";
        levelText2.text = "";
        levelText3.text = "";
        levelText4.text = "";

        if (is_first == true)
        {
            Time.timeScale = 0;
            StartCoroutine(disable());
            //is_first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        //StartCoroutine(disable());
    }

    public IEnumerator disable()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        //levelText.text = "";
        levelText1.text = "1. Avoid Virus.";

        yield return new WaitForSecondsRealtime(2.0f);

        levelText1.text = "";
        levelText2.text = "2. Collect gradients.";

        yield return new WaitForSecondsRealtime(2.0f);

        levelText2.text = "";
        levelText3.text = "3. Complete recipe.";

        yield return new WaitForSecondsRealtime(2.0f);

        levelText3.text = "";
        levelText4.text = "Let's Go!!!";

        yield return new WaitForSecondsRealtime(2.0f);

        levelText4.text = "";
        Time.timeScale = 1;
        is_first = false;
    }
}
