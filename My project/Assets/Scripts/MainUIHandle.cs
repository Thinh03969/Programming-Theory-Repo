using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandle : MonoBehaviour
{
    public Text currentPlayer;
    public Text currentScoreText;
    public Text bestPlayer;
    public Text bestScoreText;
    public int currentScore;
    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer.text = MenuController.instance.playerName;
        currentScoreText.text = "Score: " + 0;

        MenuController.instance.LoadBestPlayer();
        bestPlayer.text = MenuController.instance.bestPlayerName;
        bestScore = MenuController.instance.bestScore;
        bestScoreText.text = "Score: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore += 1;
        currentScoreText.text = "Score: " + currentScore;
        if (currentScore > bestScore)
        {
            MenuController.instance.SaveBestPlayer(currentScore);
        }
    }
}
