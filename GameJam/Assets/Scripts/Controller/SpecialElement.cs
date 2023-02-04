using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialElement : MonoBehaviour
{
    /// <summary>
    /// 检测是否碰到两边的墙的偏移
    /// </summary>
    public float wallDetectDistance = 0.5f;
    [Range(100f, 1000f)]
    public float jumpFactor = 1;
    public float mass = 0.5f;
    public float gravity = 10;
    public float velocity = 1;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ControllerManager.instance.Rigister(this);
    }


    public virtual void OnIdle()
    {


    }

    public virtual void OnNormalHacked()
    {

    }

    public virtual void OnRootHacked()
    {

    }

    public virtual void OnQuitHack()
    {

    }

}
