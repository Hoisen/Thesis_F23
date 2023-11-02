using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private float timer = 6;

    private pathAudioController heartbeat;
    // Start is called before the first frame update
    void Start()
    {
        timer -= Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
