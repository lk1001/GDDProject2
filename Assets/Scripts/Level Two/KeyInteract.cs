using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject door = GameObject.FindWithTag("Door");
            door.GetComponent<DoorInteraction>().canBeOpened = true;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }
}
