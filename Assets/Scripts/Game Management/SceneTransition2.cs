using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneTransition2 : MonoBehaviour
{
    #region Scene Transition Functions
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(5f);
        GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManager>().BeginLevelOne();
    }
    public void Awake()
    {
        StartCoroutine(Transition());
    }
    #endregion
}
