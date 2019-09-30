using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ScoreManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The score needed to advance to the next level")]
    private int scoreNeeded;

    [SerializeField]
    [Tooltip("The text component that is displaying the score. The text value " +
       "of this component will change with the score.")]
    private Text m_UIText;
    #endregion

    #region Non-Editor Variables
    private int m_Score;
    #endregion

    #region Singletons
    private static ScoreManager st;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        st = this;
    }

    public void Start()
    {
        m_Score = 0;
        AddScore(0);
    }
    #endregion

    #region Accessors and Mutators
    public static ScoreManager Singleton
    {
        get { return st; }
    }
    #endregion

    #region Score Modification Methods
    public void AddScore(int add)
    {
        m_Score += add;

        if (m_Score >= scoreNeeded)
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().TransitionTwo();
        }
        else
        {
            m_UIText.text = "" + m_Score;
        }
    }
    #endregion


}
