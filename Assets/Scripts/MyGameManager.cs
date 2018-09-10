using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {

    public static MyGameManager instancia;

    public static int blocksTotalNumber;
    public static int destructedBlocksCount;

    public GameOver gameOver;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        destructedBlocksCount = 0;
    }

    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        if (gameOver != null)
        {
            gameOver.finalScore = (float)destructedBlocksCount / blocksTotalNumber;
            gameOver.Show();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
