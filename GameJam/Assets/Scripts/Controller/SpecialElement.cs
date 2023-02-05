using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialElement : MonoBehaviour
{
    /// <summary>
    /// 检测是否碰到两边的墙的偏移
    /// </summary>
    [Range(0.01f, 1f)]
    public float wallDetectDistance = 0.5f;
    [Range(0.1f, 100f)]
    public float jumpFactor = 1;
    public float mass = 0.5f;
    public float gravity = 10;
    [Range(0.1f, 10f)]
    public float velocity = 1;
    protected bool m_isMoving;

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
        AudioManager.instance.PlayNormalHack();
    }

    public virtual void OnRootHacked()
    {
        AudioManager.instance.PlayRootHack();
    }

    public virtual void OnQuitHack()
    {

    }

    public virtual void OnDie()
    {

    }

    public bool IsMoving()
    {
        return m_isMoving;
    }

    public void SetMoving(bool move)
    {
        m_isMoving = move;
    }

}
