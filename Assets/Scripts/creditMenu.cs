using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditMenuUI;
    private bool isOpened;


    void Start()
    {
        isOpened = false;    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isOpened) {
                DeactiveMenu();
            }
        }

    }

    public void ActiveMenu() {
        isOpened = true;
        creditMenuUI.SetActive(true);
    }

    public void DeactiveMenu() {
        isOpened = false;
        creditMenuUI.SetActive(false);
    }
}
