using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBillboard : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMesh textMesh;
    private Transform canvas;

    public static FocusBillboard current;
    void Start()
    {
        current = transform.GetComponent<FocusBillboard>();
        canvas = gameObject.transform.Find("Canvas");
        //textMesh = canvas.Find("Text").GetComponent<TextMesh>();
        HideBillboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowBillboard(Vector3 position, Vector3 rulerAngles, string text)
    {
        Debug.Log("bb position: " + position);
        canvas.gameObject.SetActive(true);
        transform.position = position;
        transform.eulerAngles = new Vector3(0, rulerAngles.y, 0);
    }

    public void HideBillboard()
    {
        canvas.gameObject.SetActive(false);
    }
}
