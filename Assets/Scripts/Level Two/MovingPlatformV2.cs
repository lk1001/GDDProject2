using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformV2 : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The speed at which the platform moves")]
    private float platformSpeed;

    [SerializeField]
    [Tooltip("The distance the platform moves before switching directions")]
    private float moveDistance;

    [SerializeField]
    [Tooltip("Whether or not the platform moves horizontally")]
    private bool horizontalMovement;

    private float currentMoveDistance;
    private bool switchDirection;
    #endregion

    private void Awake()
    {
        currentMoveDistance = 0f;
        switchDirection = false;
    }

    private void Update()
    {
        if (currentMoveDistance >= moveDistance)
        { 
            switchDirection = !switchDirection;
            currentMoveDistance = 0f;
        } 
        if (switchDirection)
        {
            if (horizontalMovement)
            {
                transform.position = new Vector2(transform.position.x - platformSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - platformSpeed * Time.deltaTime);
            }
        }
        else
        { 
            if (horizontalMovement)
            {
                transform.position = new Vector2(transform.position.x + platformSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + platformSpeed * Time.deltaTime);
            }
        }
        currentMoveDistance += (platformSpeed * Time.deltaTime);
    }
}
