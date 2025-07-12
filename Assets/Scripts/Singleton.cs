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

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
