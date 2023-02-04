using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareElement : SpecialElement
{
    public enum ESquareState
    {
        Idle,
        Hacked_Unlock,
        Hacked_Controled,
    }


    public float idleCheckDistance;
    [SerializeField]
    public Vector2 moveDistance;

    private LiteFSM fsm = new LiteFSM();
    private BhvSquareRootMove m_rootMove;
    private BhvSquareNormalMove m_normalMove;
    private BhvSquareIdle m_idle;
    private void Awake()
    {
        fsm.SwitchSate(ESquareState.Idle);
        m_rootMove = new BhvSquareRootMove(transform, this);
        m_normalMove = new BhvSquareNormalMove(transform, this);
        m_idle = new BhvSquareIdle(transform, this);
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (fsm.IsEqualEnum(ESquareState.Idle)) {
            m_idle.Update();
        } else if (fsm.IsEqualEnum(ESquareState.Hacked_Unlock)) {
            m_normalMove.Update();
        } else if (fsm.IsEqualEnum(ESquareState.Hacked_Controled)) {
            m_rootMove.Update();
        }

    }

    public override void OnIdle()
    {
        base.OnIdle();
        this.fsm.SwitchSate(ESquareState.Idle);
    }

    public override void OnNormalHacked()
    {
        base.OnNormalHacked();
        this.fsm.SwitchSate(ESquareState.Hacked_Unlock);
    }

    public override void OnRootHacked()
    {
        base.OnRootHacked();
        this.fsm.SwitchSate(ESquareState.Hacked_Controled);
    }

    public override void OnQuitHack()
    {
        base.OnQuitHack();
        this.fsm.SwitchSate(ESquareState.Idle);
        Debug.Log("OnQuitHack");
    }
}
