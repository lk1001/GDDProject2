using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetColliderV2 : MonoBehaviour
{

    // Returns whether the obj is a floor, platform, or wall
    bool isFloor(GameObject obj)
    {
        return obj.CompareTag("Platform") || obj.CompareTag("MovingPlatform");
    }

    // use coll.gameObject if you need a reference coll's GameObject
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<PlayerMoveV2>().feetContact = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        GetComponentInParent<PlayerMoveV2>().feetContact = false;
    }

}
