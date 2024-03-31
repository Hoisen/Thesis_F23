using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    //Ray ray;
    //RaycastHit hit;
    float maxDistance = 20;
    public LayerMask layersToHit;
    RaycastHit hit;
    public GameObject eye01;

    public bool hitbyray = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //ray = new Ray(transform.position, transform.forward);
        //CheckForColliders();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckForColliders();
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layersToHit))
        {
            hitbyray = true;
            Debug.DrawRay(transform.position, transform.forward * 20, Color.black);
            Debug.Log(hit.collider.gameObject.name + "was hitted!");
            hit.transform.SendMessage("HitByRay");
            //Debug.Log("!!!");
        }
        else
        {
            Debug.Log("noooo");
            transform.SendMessage("notHitByRay");
            hitbyray = false;
        }
    }

    void FixedUpdate()
    {

    }

    void CheckForColliders()
    {

    }
}
