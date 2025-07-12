using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenController : MonoBehaviour
{

    public void OpenHomeScreen()
    {

    }

    //Called when play button is clicked
    public void OnPlayButtonClicked()
    {
        Singleton.instance.gameController.OpenGameScene();
    }

    //Called wehen settings button is clicked
    public void OnSettingsMenuClicked()
    {
        Singleton.instance.settingsMenuController.OpenSettingsMenu();
    }
}
