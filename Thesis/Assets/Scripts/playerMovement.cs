using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //PlayerController
    public CharacterController controller;
    public float speed = 12f;
    
    //Jump
    public float gravity = -9.81f;
    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public float jumpHeight = 3f;
    
    //Audio
    public AudioSource audio;

    //crouch
    public float Height
    {
        get => controller.height;
        set => controller.height = value;
    }

    public event Action OnBeforeMove;
    public event Action<bool> OnGroundStateChange;
    
    //this is also for the playerCrouch - move the cam
    //public Transform cameraTransform;
    
    //Try to move cam script to here
    [SerializeField] public Transform cameraTransform;
    private Vector2 look;

    [SerializeField] private float mouseSensitivity = 3f;
    
    //camera zoom in
    [SerializeField] public Camera cam;
    public float defaultFov = 90;
    public float zoomDuration = 2;
    public float zoomMultiplier = 2;
    
    
    //CallFunction
    //private scenecolorController bgChange;
    
    //Interactive - shadow world

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //playerMovement
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        
        //restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (velocity.y < -4f)
        {
            //falling
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        //cam
        look.x += Input.GetAxis("Mouse X");
        look.y += Input.GetAxis("Mouse Y");

        look.y = Mathf.Clamp(look.y, -89f, 89f);
        
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
        
        //cam zoom in
        if (Input.GetMouseButton(1))
        {
             zoomCam(defaultFov / zoomMultiplier);
        }
        else if(cam.fieldOfView != defaultFov)
        {
            zoomCam((defaultFov));
        }

    }

    void zoomCam(float target)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
