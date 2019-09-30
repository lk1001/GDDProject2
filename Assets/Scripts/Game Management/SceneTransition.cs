using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text component displaying instructions for the next level")]
    private Text m_UIText;

    #region Scene Transition Functions
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<AudioSource>().Play();
        m_UIText.text = "Next Objective: Escape the cave";

        yield return new WaitForSeconds(3f);
        GameObject gm = GameObject.FindWithTag("GameController");
        gm.GetComponent<GameManager>().BeginLevelTwo();
    }
    public void Awake()
    {
        StartCoroutine(Transition());
    }
    #endregion
}
