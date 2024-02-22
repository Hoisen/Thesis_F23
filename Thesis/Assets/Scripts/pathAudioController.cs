using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class pathAudioController : MonoBehaviour
{ 
    public AudioSource audio;
    public float timer = 6f;

    //image
    private SpriteRenderer sprite;
    //public AudioClip clock;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0f;
        StartCoroutine(LerpFunction(1f, 10));
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
        //Debug.Log("heartbeat" + timer);

        // if (Input.anyKeyDown)
        // {
        //     audio.Stop();
        // }
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = audio.volume;
        while (time < duration)
        {
            audio.pitch = Mathf.Lerp(startValue, endValue, time / duration);
            audio.volume = Mathf.Lerp(startValue, endValue, time / duration);
            sprite.transform.localScale = Vector3.Lerp(sprite.transform.localScale, sprite.transform.localScale*10f, time / duration);
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
