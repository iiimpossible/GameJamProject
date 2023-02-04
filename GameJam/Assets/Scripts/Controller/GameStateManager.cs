using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public List<string> levels = new List<string>();
    public static GameStateManager instance;
    [SerializeField]
    EGameStateType m_stateType = EGameStateType.None;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public EGameStateType GetGameStateType()
    {
        return m_stateType;
    }

    public void SwitchState(EGameStateType type)
    {
        this.m_stateType = type;
    }


    public void NextLevel()
    {

    }
}
