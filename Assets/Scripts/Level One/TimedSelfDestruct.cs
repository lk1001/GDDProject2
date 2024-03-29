﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Timed Self-Destruct")]
public class TimedSelfDestruct : MonoBehaviour
{

    // After this time, the object will be destroyed
    public float timeToDestruction;


    void Start()
    {
        Invoke("DestroyMe", timeToDestruction);
    }


    void DestroyMe()
    {
        Destroy(gameObject);

    }
}
