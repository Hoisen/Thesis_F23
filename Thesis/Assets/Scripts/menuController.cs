using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public TMP_Text start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float x = mousePos.x;
        float y = mousePos.y;
        Debug.Log(x + "," + y);

        Vector3 startPos = new Vector3(820, 80, 0);
        
        Vector3 distance;
        distance = mousePos - startPos;
    }

    public void clickStart()
    {
        SceneManager.LoadScene("startScene");
    }
}
