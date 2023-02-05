using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance;

    public List<string> m_scenes = new List<string>();

    private int index = 0;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(index);
        index++;
    }
}
