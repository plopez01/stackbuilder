using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static StackLevel currentLevel;

    public UnityEvent gameWonEvent;
    public UnityEvent<string> gameLostEvent;
    
    private bool gameOver = false;

    private void Awake()
    {
        if (Manager.instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    public void TriggerWinGame()
    {
        gameOver = true;
        gameWonEvent.Invoke();
    }

    public void TriggerLoseGame(string reason)
    {
        gameOver = true;
        gameLostEvent.Invoke(reason);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
