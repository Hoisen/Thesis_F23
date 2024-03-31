using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    [Header("Footsteps")]
    [Header("AmbientAudio")]
    public bool isAmbientAudioOn = true;
    AudioSource audio;

    public List<AudioClip> concreteFS;
    float vSpeed = 0.001f;

    enum FSMaterial
    {
        Concrete
    }

    private AudioSource footstepSource;
    // Start is called before the first frame update
    void Start()
    {
        //footstepSource = GetComponent<AudioSource>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.touchedShadow == false)
        {
            StartCoroutine(LerpFunction(0, 0.3f, 5));
        }
        if(GameData.touchedShadow == true)
        {
            ambientAudioOff();
        }
        Debug.Log("shadowisTouched"+GameData.touchedShadow);
        
    }

    void playFootsteps()
    {
        
    }

    void ambientAudioOn()
    {
        // if(isAmbientAudioOn)
        // {
        //     StartCoroutine(LerpFunction(0, 0.5f, 5));
        // }
    }

    void ambientAudioOff()
    {
        audio.volume -= 0.05f;
        // if(isAmbientAudioOn == false)
        // {
            
        // }
    }

    IEnumerator LerpFunction(float startValue, float endValue, int duration)
    {
        float lerpValue = 0;

        for(float f = 0; f < duration; f+= Time.deltaTime)
        {
            lerpValue = Mathf.Lerp(startValue, endValue, f/duration);
            audio.volume = lerpValue;
            yield return null;
        }
        
    }
}
