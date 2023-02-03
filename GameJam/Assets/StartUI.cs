using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public Button btn_start;
    public Button btn_quit;



    private void Awake()
    {
        btn_start.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });

        btn_quit.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
