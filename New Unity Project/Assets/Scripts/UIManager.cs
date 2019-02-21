using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text gameOverText;
    public Text scoreText;
    public Text healthText;
    public Text victoryText;

    int score;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        float sw = Screen.width;
        float sh = Screen.height;

        victoryText.enabled = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.getScore();
        health = GameManager.instance.getHealth();
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }


    public void GameOver()
    {
        gameOverText.enabled = true;
    }

    public void winGame()
    {
        victoryText.enabled = true;
    }
}
