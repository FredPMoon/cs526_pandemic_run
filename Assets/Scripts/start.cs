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
    public float timer;
    public GameObject redLight, yellowLight, greenLight;

    public static bool is_first = true;
    public AudioSource AS;
    public AudioClip clip;
    public AudioClip startSound;
    public GameObject dead;
    public Button setting;

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
            //set the traffic to green
            greenLight.SetActive(false);

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
        setting.interactable = false;
        dead.GetComponent<ParticleSystem>().Pause();
        dead.SetActive(false);
        yield return new WaitForSecondsRealtime(timer);

        //levelText.text = "";
        AS.PlayOneShot(clip, 1);
        levelText1.text = "Avoid Virus";
        yield return new WaitForSecondsRealtime(timer);

        AS.PlayOneShot(clip, 1);
        levelText1.text = "";
        levelText2.text = "Collect Ingredients";
        redLight.SetActive(true);

        yield return new WaitForSecondsRealtime(timer);

        AS.PlayOneShot(clip, 1);
        levelText2.text = "";
        levelText3.text = "Complete Recipes";
        redLight.SetActive(false);
        yellowLight.SetActive(true);

        yield return new WaitForSecondsRealtime(timer);

        AS.PlayOneShot(startSound, 1);
        levelText3.text = "";
        levelText4.text = "Let's Go!!!";
        yellowLight.SetActive(false);
        greenLight.SetActive(true);

        yield return new WaitForSecondsRealtime(timer);

        levelText4.text = "";
        Time.timeScale = 1;
        is_first = false;
        setting.interactable = true;
    }
}
