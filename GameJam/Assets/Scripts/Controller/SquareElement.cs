using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareElement : SpecialElement
{



    public float idleCheckDistance;
    [SerializeField]
    public Vector2 moveDistance;
    [SerializeField]
    private LiteFSM fsm = new LiteFSM();
    private BhvSquareRootMove m_rootMove;
    private BhvSquareNormalMove m_normalMove;
    private BhvSquareIdle m_idle;
    private void Awake()
    {
        fsm.SwitchSate(EHackType.Idle);
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
        if (fsm.IsEqualEnum(EHackType.Idle)) {
            m_idle.Update();
        } else if (fsm.IsEqualEnum(EHackType.Hacked_Normal)) {
            m_normalMove.Update();
        } else if (fsm.IsEqualEnum(EHackType.Hacked_Root)) {
            m_rootMove.Update();
        }

    }

    public override void OnIdle()
    {
        base.OnIdle();
        this.fsm.SwitchSate(EHackType.Idle);
    }

    public override void OnNormalHacked()
    {
        base.OnNormalHacked();
        if (m_normalMove.reached) return;
        this.fsm.SwitchSate(EHackType.Hacked_Normal);
    }

    public override void OnRootHacked()
    {
        base.OnRootHacked();

        this.fsm.SwitchSate(EHackType.Hacked_Root);
    }

    public override void OnQuitHack()
    {
        base.OnQuitHack();
        this.fsm.SwitchSate(EHackType.Idle);
        Debug.Log("OnQuitHack");
    }
}
