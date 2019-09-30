using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Game Manager Variables
    public static GameManager instance = null;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene Transitions
    public void StartGame()
    {
        SceneManager.LoadScene("TransitionSceneOne");
    }

    public void BeginLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void TransitionTwo()
    {
        SceneManager.LoadScene("TransitionSceneTwo");
    }

    public void BeginLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
