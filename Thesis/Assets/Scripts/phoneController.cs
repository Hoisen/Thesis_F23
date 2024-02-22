using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneController : MonoBehaviour
{
    public GameObject dot;
    public bool answerPhone = false;

    private AudioSource audio;

    public GameObject phonePortal;
    public GameObject phoneScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (answerPhone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //menu: E to interact
                Debug.Log("Phone!");
                phonePortal.SetActive(true);
                phoneScreen.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dot.SetActive(true);
            answerPhone = true;
            audio.Pause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dot.SetActive(false);
        }
    }
}
