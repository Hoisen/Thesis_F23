using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private float timer = 8;

    private SpriteRenderer sprite;

    private float scaleModifier = 0.01f;

    public Material DissovleMaterial;
    public string PropertyName;

    public float dissolveValue = 0;

    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //StartCoroutine(LerpFunction(2, 0));
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        DissovleMaterial.SetFloat(PropertyName, dissolveValue);
        
        if (timer <= 0)
        {
            dissolveValue += speed;
        }

        if (dissolveValue >= 0.8f)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        Debug.Log(dissolveValue);
        // if (timer >= -5 && timer <= 3)
        // {
        //     sprite.transform.localScale += new Vector3(.001f, .001f, .001f);
        // }
        // if (timer < 0)
        // {
        //     sprite.transform.localScale += new Vector3(.005f, .005f, .005f);
        //     
        // }
        //
        // if (sprite.transform.localScale.y >= 10)
        // {
        //     SceneManager.LoadScene("SampleScene");
        // }

    }
    
    // IEnumerator LerpFunction(float endValue, float duration)
    // {
    //     float time = 0;
    //     float startValue = scaleModifier;
    //     Vector3 startScale = transform.localScale;
    //     while (time < duration)
    //     {
    //         scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
    //         sprite.transform.localScale = startScale * scaleModifier;
    //         time += Time.deltaTime;
    //         yield return null;
    //     }
    //
    //     transform.localScale = startScale * endValue;
    //     scaleModifier = endValue;
    // }
}
