using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuideController : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip guideSound01;
    public AudioClip guideSound02;
    private Vector3 playerPos;

    private bool pass;

    public GameObject light;

    public GameObject hiddenPlatform;
    private bool keyP = false;

    private MeshRenderer mesh;
    public AudioClip[] guideSounds;
    // Start is called before the first frame update
    void Start()
    {
        pass = false;
        light.SetActive(false);
        
        mesh = hiddenPlatform.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        
        audio = GetComponent<AudioSource>();
        // Invoke("playSounds", 5f);
        // Invoke("playSound02", 10f);
        if (pass == false)
        {
            InvokeRepeating("playAllSounds", 0.001f, 10f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //play sound every few seconds? && if distance >= xx
        if (pass == true)
        {
            audio.Pause();
            light.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            //mesh.enabled = true;
            keyP = !keyP;
        }

        if (keyP == false)
        {
            mesh.enabled = false;
        }

        if (keyP == true)
        {
            mesh.enabled = true;
        }
    }

    void playSounds()
    {
        audio.clip = guideSound01;
        audio.Play();
    }

    void playSound02()
    {
        audio.clip = guideSound02;
        audio.Play();
    }

    void playAllSounds()
    {
        audio.clip = guideSounds[Random.Range(0, 2)];
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Weepee");
            pass = true;
        }
        
        
    }
}
