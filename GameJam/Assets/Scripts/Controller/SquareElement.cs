using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareElement : SpecialElement
{


    public Vector2 actorDetectSize;
    public float idleCheckDistance;

    [SerializeField]
    public Vector2 moveDistance;
    [SerializeField]
    private LiteFSM fsm = new LiteFSM();
    private BhvSquareRootMove m_rootMove;
    private BhvSquareNormalMove m_normalMove;
    private BhvSquareIdle m_idle;
    public Rigidbody2D rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        fsm.SwitchSate(EHackType.Idle);
        m_rootMove = new BhvSquareRootMove(transform, this);
        m_normalMove = new BhvSquareNormalMove(transform, this);
        m_idle = new BhvSquareIdle(transform, this);
        base.Start();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) return;
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
        rig.bodyType = RigidbodyType2D.Static;
    }

    public override void OnNormalHacked()
    {
        base.OnNormalHacked();
        if (m_normalMove.reached) return;
        this.fsm.SwitchSate(EHackType.Hacked_Normal);
        rig.bodyType = RigidbodyType2D.Static;
    }

    public override void OnRootHacked()
    {
        base.OnRootHacked();

        this.fsm.SwitchSate(EHackType.Hacked_Root);
        rig.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void OnQuitHack()
    {
        base.OnQuitHack();
        this.fsm.SwitchSate(EHackType.Idle);
        rig.bodyType = RigidbodyType2D.Static;
        Debug.Log("OnQuitHack");
    }

    public override bool IsNormalHacked()
    {
        return m_normalMove.reached;
    }
}
