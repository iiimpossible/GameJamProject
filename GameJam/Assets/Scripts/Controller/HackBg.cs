using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackBg : MonoBehaviour
{
    public GameObject hackBg;
    public GameObject beforeHackLog;
    public GameObject hackingLog;

    // Start is called before the first frame update
    void Start()
    {
        hackBg.gameObject.SetActive(false);
        beforeHackLog.gameObject.SetActive(false);
        hackingLog.gameObject.SetActive(false);
    }



    public void ShowStartHack()
    {
        hackBg.gameObject.SetActive(true);
        beforeHackLog.gameObject.SetActive(true);
        hackingLog.gameObject.SetActive(false);
    }

    public void ShowHacking()
    {
        hackBg.gameObject.SetActive(true);
        beforeHackLog.gameObject.SetActive(false);
        hackingLog.gameObject.SetActive(true);
    }
    public void CloseHack()
    {
        hackBg.gameObject.SetActive(false);
        beforeHackLog.gameObject.SetActive(false);
        hackingLog.gameObject.SetActive(false);
    }
}
