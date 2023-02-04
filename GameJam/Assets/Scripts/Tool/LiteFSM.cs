using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiteFSM
{
    public Enum curState { get; private set; }

    public void SwitchSate(Enum state)
    {
        curState = state;

    }

    public bool IsEqualEnum(Enum e)
    {
        return curState.Equals(e);
    }
}
