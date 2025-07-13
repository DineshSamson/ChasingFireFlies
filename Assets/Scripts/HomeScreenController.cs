using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour
{

    public GameObject MainObject;

    public Slider VolumeSlider;

    public List<Image> LayoutButton = new List<Image>();
    public Color ButtonSelected;
    public Color ButtonNotSelected;

    public Animation playAnimation;

    public TMP_Text TotalScore;

    public GameObject ResumeMenu;
    private void Start()
    {
        //VolumeSlider.value = 1;
        //VolumeSlider.onValueChanged.AddListener(delegate { SoundManager.instance.AdjustVolume(VolumeSlider.value); });
    }

    public void OpenHomeScreen()
    {

    }

    //Called when play button is clicked
    public void OnPlayButtonClicked()
    {
        Singleton.instance.gameController.Init();
        Close();
    }

    //Called wehen settings button is clicked
    public void OnSettingsMenuClicked()
    {
        Singleton.instance.settingsMenuController.OpenSettingsMenu();
    }

    //Initializing the first menu 
    public void Init()
    {
        MainObject.SetActive(true);

        playAnimation.Play();


        if (!PlayerPrefs.HasKey("SelectedGrid"))
            SelectedLayout(0);
        else
        {
            SelectedLayout(PlayerPrefs.GetInt("SelectedGrid"));
        }

        if (!PlayerPrefs.HasKey("Volume"))
        {
            SoundManager.instance.AdjustVolume(1);
        }
        else
        {
            SoundManager.instance.AdjustVolume(PlayerPrefs.GetFloat("Volume"));
        }

        if (!PlayerPrefs.HasKey("TotalScore"))
        {
            PlayerPrefs.SetInt("TotalScore", 0);
            Singleton.instance.scoreController.totalScore.text = "" + PlayerPrefs.GetInt("TotalScore");
        }
        else
        {
            Singleton.instance.scoreController.totalScore.text = "" + PlayerPrefs.GetInt("TotalScore");
        }
    }

    ////This function will be called when Play button clicked
    //public void PlayGame()
    //{
    //    MainController.Instance.gameController.Init();
    //    Close();
    //}

    //Selecing the layout form settings menu
    public void SelectedLayout(int Index)
    {
        PlayerPrefs.SetInt("Layout", Index);
        if (Index == 0)
        {
            Singleton.instance.gameController.rowCount = 2;
            Singleton.instance.gameController.columnCount = 2;
        }
        else if (Index == 1)
        {
            Singleton.instance.gameController.rowCount = 2;
            Singleton.instance.gameController.columnCount = 3;
        }
        else if (Index == 2)
        {
            Singleton.instance.gameController.rowCount = 5;
            Singleton.instance.gameController.columnCount = 6;
        }

        //for (int i = 0; i < LayoutButton.Count; i++)
        //{
        //    LayoutButton[i].color = ButtonNotSelected;
        //}
        //LayoutButton[Index].color = ButtonSelected;
    }

    public void Close()
    {
        MainObject.SetActive(false);
    }

    public void CheckForResume()
    {
        if (PlayerPrefs.HasKey("SavedData"))
        {
            //Enable Resume menu         
            ResumeMenu.SetActive(true);
        }
        else
        {
            Init();
        }
    }

    public void DontLoadData()
    {
        PlayerPrefs.DeleteKey("SavedData");
        PlayerPrefs.Save();
        Init();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("SavedData"))
        {
            string jsonData = PlayerPrefs.GetString("SavedData");

            DetailsToSave data = JsonUtility.FromJson<DetailsToSave>(jsonData);

            Singleton.instance.gameController.rowCount = data.rowCount;
            Singleton.instance.gameController.columnCount = data.columnCount;
            Singleton.instance.gameController.TurnCounter = data.TurnCounter;
            Singleton.instance.gameController.Score = data.Score;
            Singleton.instance.gameController.GameEndCounter = data.GameEndCounter;
            Singleton.instance.gameController.ImageNameList = new List<string>(data.ImageNameList);

            Singleton.instance.gameController.OnResumePreviouseGame(data.rowCount, data.columnCount, data.TurnCounter, data.Score, data.GameEndCounter, data.ImageNameList);

            PlayerPrefs.DeleteKey("SavedData");
            PlayerPrefs.Save();
        }
    }
}
