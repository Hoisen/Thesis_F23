using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class ObjectHit : MonoBehaviour
{
    public float speed = 1f;
    public GameObject targetObject;
    public GameObject targetCam;

    public bool RayHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HitByRay()
    {
        Debug.Log("HITBYRAY");
        moveToObject();
        RayHit = true;
        //if is hit, stay for 3 sec then move eye to one direction. if not stay still
    }

    void notHitByRay()
    {
        Debug.Log("NotHitByRay");
        RayHit = false;
    }

    void moveToObject()
    {
        transform.LookAt(targetObject.transform.position);
    }
    void moveToPlayer()
    {
        transform.LookAt(targetCam.transform.position);
    }
}
