using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornElement : SpecialElement
{

    public Vector2 deteckSize;
    private LiteFSM fsm = new LiteFSM();

    private BhvThornWarning m_warning;
    private BhvSquareRootMove m_root;
    private Rigidbody2D rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        fsm.SwitchSate(EHackType.Idle);
        m_warning = new BhvThornWarning(transform, this);
        m_root = new BhvSquareRootMove(transform, this);
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) return;
        if (fsm.IsEqualEnum(EHackType.Hacked_Root)) {
            m_root.Update();
        } else if (fsm.IsEqualEnum(EHackType.Idle)) {
            m_warning.Update();
        }

    }

    public override void OnIdle()
    {
        fsm.SwitchSate(EHackType.Idle);
        base.OnIdle();
        rig.bodyType = RigidbodyType2D.Static;
    }

    public override void OnRootHacked()
    {
        fsm.SwitchSate(EHackType.Hacked_Root);
        base.OnRootHacked();
        rig.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void OnNormalHacked()
    {
        base.OnNormalHacked();
    }

    public override void OnQuitHack()
    {
        base.OnQuitHack();
        this.fsm.SwitchSate(EHackType.Idle);
        rig.bodyType = RigidbodyType2D.Static;
    }

    private void OnDrawGizmos()
    {
        BhvThornWarning.DebugDrawBox(transform.position, deteckSize);
    }

}
