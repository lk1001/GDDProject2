using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveV2 : MonoBehaviour
{
    #region Editor Variables
    public float moveSpeed;
    public float jumpforce;

    private float dirX;
    Rigidbody2D playerRB;
    public bool feetContact;
    #endregion

    #region Initialization
    public void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Updates
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(dirX * moveSpeed, 0);
        movement = movement * Time.deltaTime;
        playerRB.AddForce(movement);

        if (Input.GetButtonDown("Jump") && canJump())
        {
            playerRB.AddForce(new Vector2(0, jumpforce));
        }
    }
    #endregion

    #region Movement Functions
    bool canJump()
    {
        return feetContact;

    }
    #endregion

    #region Collision Functions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
    #endregion
}
