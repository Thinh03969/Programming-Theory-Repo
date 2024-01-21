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
    public TextMeshProUGUI moveLeftText;
    public GameObject winTitle;
    public TextMeshProUGUI winTitleText;
    public int currentScore=0;
    private int bestScore=0;
    public int moveLeft = 6;

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
        moveLeftText.text = "Moves Left: " + moveLeft;
    }

    public void WinGame()
    {
        if (currentScore < bestScore || bestScore == 0)
        {
            MenuController.instance.SaveBestPlayer(currentScore);
        }
        moveLeftText.gameObject.SetActive(false);
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

    public void GameOver()
    {
        winTitleText.text = "Game Over \n You are out of Moves";
        winTitle.SetActive(true);
    }

    //Overloading
    public void GameOver(string name)
    {
        winTitleText.text = "Game Over \n You were caught trying to get over the "+name;
        winTitle.SetActive(true);
    }
}
