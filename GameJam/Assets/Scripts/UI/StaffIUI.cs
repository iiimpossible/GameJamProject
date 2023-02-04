using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaffIUI : MonoBehaviour
{

    public ScrollRect scrollRect;
    public float velocity = 1;
    private bool move = true;

    private void Start()
    {
        Debug.Log("scrollRect " + scrollRect.verticalNormalizedPosition);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(scrollRect.verticalNormalizedPosition);
    //    // if (!move) return;
    //    // if (scrollRect.verticalNormalizedPosition >= 1) move = false;

    //    scrollRect.verticalNormalizedPosition -= Time.deltaTime * 1;
    //}



}
