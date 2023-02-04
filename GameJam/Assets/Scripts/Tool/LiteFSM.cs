using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class LiteFSM
{

    public Enum curState { get { return m_curState; } }
    [SerializeField]
    public string state;
    private Enum m_curState;
    public void SwitchSate(Enum s)
    {
        m_curState = s;
        state = s.ToString();
    }

    public bool IsEqualEnum(Enum e)
    {
        return curState.Equals(e);
    }
}


public class Transition
{ }


