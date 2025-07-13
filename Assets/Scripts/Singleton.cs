using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    public HomeScreenController homeScreenController;
    public ScoreController scoreController;
    public SettingsMenuController settingsMenuController;
    public GameController gameController;
    public JsonData jsonData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        homeScreenController.CheckForResume();
        gameController.Close();
    }

    public void FreezeGAme()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void UnFreezeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
