using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMovement))]
public class playerCrouch : MonoBehaviour
{
    [SerializeField] float crouchHeight = 1f;
    [SerializeField] private float crouchTransitionSpeed;
    
    playerMovement player;

    private Vector3 initialCameraPos;
    
    //adding smooth to Crouching
    private float currentHeight;
    float standingHeight;
    
    //determine if there's ceiling on top of player
    private bool isCrouching => standingHeight - currentHeight > .1f;
    
    void Awake()
    {
        player = GetComponent<playerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        initialCameraPos = player.cameraTransform.localPosition;
        standingHeight = currentHeight = player.Height;
    }

    void OnEnable() => player.OnBeforeMove += OnBeforeMove;
    void OnDisable() => player.OnBeforeMove -=OnBeforeMove;

    void OnBeforeMove()
    {
        var isTringToCrouch = Input.GetKey(KeyCode.C);
        var heightTarget = isTringToCrouch ? crouchHeight : standingHeight;

        if (isCrouching && !isTringToCrouch)
        {
            var castOrigin = transform.position + new Vector3(0, currentHeight / 2, 0);
            if (Physics.Raycast(castOrigin, Vector3.up, out RaycastHit hit, 0.2f))
            {
                var distanceToCeiling = hit.point.y - castOrigin.y;
                heightTarget = Mathf.Max
                (
                    currentHeight + distanceToCeiling - 0.1f,
                    crouchHeight
                );
            }
        }

        if (!Mathf.Approximately(heightTarget, currentHeight))
        {
            var crouchDelta = Time.deltaTime * crouchTransitionSpeed;
            currentHeight = Mathf.Lerp(currentHeight, heightTarget, crouchDelta);

            var halHeightDifference = new Vector3(0, (standingHeight - currentHeight) / 2, 0);
            var newCamPos = initialCameraPos - halHeightDifference;

            player.cameraTransform.localPosition = newCamPos;
            player.Height = currentHeight;
        }

        if (isCrouching)
        {
            player.speed = 2f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        OnBeforeMove();
        //Debug.Log(player.speed);
    }
}
