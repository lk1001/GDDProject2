using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    #region Editor Variables
    public bool canBeOpened;
    #endregion

    #region Initialization
    private void Awake()
    {
        canBeOpened = false;
    }
    #endregion

    #region Opening Variables
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canBeOpened)
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().WinGame();
        }
    }
    #endregion
}
