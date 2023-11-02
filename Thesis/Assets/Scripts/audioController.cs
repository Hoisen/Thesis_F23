using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    [Header("Footsteps")] 
    public List<AudioClip> concreteFS;

    enum FSMaterial
    {
        Concrete
    }

    private AudioSource footstepSource;
    // Start is called before the first frame update
    void Start()
    {
        footstepSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playFootsteps()
    {
        
    }
}
