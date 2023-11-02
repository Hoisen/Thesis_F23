using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Input = UnityEngine.Windows.Input;

public class scenecolorController : MonoBehaviour
{
    //Scene1 Background Color
    public float duration = 5f;
    public Camera cam;

    Light lt;
    public GameObject directionLight;
    public GameObject spotLight;
    private Light spotLt;
    
    //New
    //[SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color myColor;
    private float lerpTime = 0.001f;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        lt = directionLight.GetComponent<Light>();
        spotLt = spotLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //pingpong white - black
        //8 steps, black out and turn on the spot light
        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //cam.backgroundColor = Color.Lerp(Color.white, Color.black, t);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            count += 1;
            lerpTime += 0.0001f;
            Debug.Log(lerpTime);
        }

        if (count >= 2)
        {
            cam.backgroundColor = Color.Lerp(cam.backgroundColor, myColor, lerpTime);
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, myColor, lerpTime);
            lt.color = Color.Lerp(lt.color, myColor, lerpTime);
            spotLt.intensity = Mathf.Lerp(1, 45, 1);
        }

        if (cam.backgroundColor == myColor)
        {
            lerpTime = 0;
            cam.backgroundColor = Color.black;
            RenderSettings.ambientLight = Color.black;
            lt.color = Color.black;
        }
        //cam.backgroundColor = Color.Lerp(cam.backgroundColor, myColor, 0.001f);
        //RenderSettings.ambientLight;
        //lt.color;

    }

    public void changeBackgroundcolor()
    {
        //cam.backgroundColor = Color.Lerp(Color.white, Color.black, .12f);
    }
}
