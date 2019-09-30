using System;
using System.Collections;
using UnityEngine;

public class PlayerMovementLevel1 : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Key used to activate the push")]
    private KeyCode key;

    [SerializeField]
    [Tooltip("Strength of push")]
    private float pushStrength;

    [SerializeField]
    [Tooltip("Apply force relative to axis of rotation")]
    private bool relativeAxis = true;

    [SerializeField]
    [Tooltip("Rotation speed")]
    private float rotationSpeed;
   
    private Vector2 pushDirection;
    private Vector2 pushVector;
    private Rigidbody2D playerRB;
    private bool keyPressed = false;

    private float spin;
    #endregion

    #region Initialization
    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        pushDirection = new Vector2(0, 1);
    }
    #endregion

    #region Updates
    void Update()
    {
        keyPressed = Input.GetKey(key);
        spin = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (keyPressed)
        {
            pushVector = pushDirection * pushStrength;

            if (relativeAxis)
            {
                playerRB.AddRelativeForce(pushVector);
            }
            else
            {
                playerRB.AddForce(pushVector);
            }
        }
        playerRB.AddTorque(-spin * rotationSpeed);
    }
    #endregion

}