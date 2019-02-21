using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Pooler StagPool;
    Pooler TokenPool;

    public int playerHealth;
    private int playerScore;

    public GameObject ui;

    public static GameManager instance = null;


    // Start is called before the first frame update
    void Start()
    {
        StagPool = GameObject.Find("Stag Pool").GetComponent<Pooler>();
        TokenPool = GameObject.Find("TokenPool").GetComponent<Pooler>();
        ui = GameObject.Find("UIManager");

        playerScore = 0;

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public int getScore()
    {
        return playerScore;
    }

    public void increaseScore(int amt)
    {
        playerScore += amt;
        if(playerScore >= 7500)
        {
            winGame();
        }
    }

    public void takeDamage()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        Time.timeScale = 0;
        ui.GetComponent<UIManager>().GameOver();
        Application.Quit();

    }

    public void winGame()
    {
        Time.timeScale = 0;
        ui.GetComponent<UIManager>().winGame();
        Application.Quit();
    }
}
