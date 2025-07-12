using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Obj;

    public void OpenGameScene()
    {
        Obj.gameObject.SetActive(true);
    }
}
