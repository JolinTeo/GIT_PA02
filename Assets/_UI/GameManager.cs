using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState {  GameOver, GameStart, GameIdle};
    public static GameState CurrentState = GameState.GameIdle;

    public static int Lives = 3;
    public static int Score = 0;

    private HUD hud;

    void Start()
    {
        Lives = 3;
        Score = 0;
        Time.timeScale = 0;
        CurrentState = GameState.GameIdle;
        hud = FindObjectOfType<HUD>();
    }
    
    void Update()
    {
        if(CurrentState == GameState.GameIdle && Input.GetKeyDown(KeyCode.Return))
        {            
            CurrentState = GameState.GameStart;
            Time.timeScale = 1;
            HUD.HUDManager.DismissMessage();
        }

        else if(CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
        else if (CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }

        else if (Lives == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void TakeDamage(int dmg)
    {
        Lives -= dmg;
        hud.UpdateLives();
    }

    public void AddScore(int score)
    {
        Score += score;
        hud.UpdateScore();
    }

}
