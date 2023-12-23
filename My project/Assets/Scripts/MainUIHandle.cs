using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandle : MonoBehaviour
{
    public Text currentPlayer;
    public Text currentScoreText;
    public Text bestPlayer;
    public Text bestScoreText;
    public GameObject winTitle;
    public int currentScore=0;
    public int bestScore=0;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer.text = MenuController.instance.playerName;

        MenuController.instance.LoadBestPlayer();
        bestPlayer.text = MenuController.instance.bestPlayerName;
        bestScore = MenuController.instance.bestScore;
        bestScoreText.text = "Moves: " + bestScore;
        Debug.Log(bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = "Moves: " + currentScore;
    }

    public void WinGame()
    {
        if (currentScore < bestScore || bestScore == 0)
        {
            MenuController.instance.SaveBestPlayer(currentScore);
        }
        winTitle.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
