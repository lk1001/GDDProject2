using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("SEE PLAYER RUN NOW");
            GetComponentInParent<EnemyLevel1>().player = collision.transform;
            GetComponentInParent<EnemyLevel1>().enemySpotted = true;
        }

        if (collision.CompareTag("Platform"))
        {
            GetComponentInParent<EnemyLevel1>().wallProximity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("PLAYER GONE PLAYER GONE");
            GetComponentInParent<EnemyLevel1>().player = null;
            GetComponentInParent<EnemyLevel1>().enemySpotted = false;
        }

        if (collision.CompareTag("Platform"))
        {
            GetComponentInParent<EnemyLevel1>().enemySpotted = false;
        }
    }
}
