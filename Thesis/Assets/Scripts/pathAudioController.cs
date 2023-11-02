using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class pathAudioController : MonoBehaviour
{ 
    public AudioSource audio;
    public float timer = 6f;

    //public AudioClip clock;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(LerpFunction(.5f, 5));
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("heartbeat" + timer);

        if (Input.anyKeyDown)
        {
            audio.Stop();
        }
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = audio.volume;
        while (time < duration)
        {
            audio.volume = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        audio.volume = endValue;
    }
    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
