using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public StartUI startUI;
    public StaffIUI staffUI;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    public void CloseAll()
    {

    }
}
