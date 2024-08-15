using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   private void Awake() 
   {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
   }

   private String highScoreKey  = "HighScore";

   public int HighScore
   {
        get 
        {
            return PlayerPrefs.GetInt(highScoreKey , 0);
        }

        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
   }

   private int _currentScore = 0;

   public int CurrentScore 
   {
        get
        {
            return _currentScore;
        }

        set 
        {
            _currentScore = value;
        }
   }

   public bool IsInitialized
   {
        get; set;
   }

   private void Init()
   {
        CurrentScore = 0;
        IsInitialized = false;
   }

    private const String _mainMenu = "MainMenu";
    private const String _gameplay = "Gameplay";

    public void GoToMainMenu() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenu);
    }

    public void GoToGameplay() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameplay);
    }
}
