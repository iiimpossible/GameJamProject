using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundType : MonoBehaviour
{
    public enum EGroundType
    {
        None,
        Normal,
        Wall,
        Ground,
    }


    public EGroundType groundType;
}
