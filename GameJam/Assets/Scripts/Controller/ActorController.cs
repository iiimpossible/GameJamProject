using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActorController : SpecialElement
{
    enum EMoveState
    {
        Jump,
        Idle,
    }

    public Animator actorAnimator;
    [Range(0.01f, 100)]
    public float detect = 0.1f;
    [SerializeField]
    private LiteFSM fsm = new LiteFSM();
    //public SpecialElement curHackableElemet;

    private BhvActorRootMove m_rootMove;
    private BhvActorIdle m_idle;
    [SerializeField]
    private SpecialElement m_curHackableElement;

    private void Awake()
    {

        //ControllerManager.instance.RigisterActor(this);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        m_idle = new BhvActorIdle(transform, this);
        m_rootMove = new BhvActorRootMove(transform, this);
        fsm.SwitchSate(EHackType.Hacked_Root);
        // base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) return;
        if (fsm.IsEqualEnum(EHackType.Idle)) {
            this.m_idle.Update();
        } else if (fsm.IsEqualEnum(EHackType.Hacked_Root)) {
            this.m_rootMove.Update();
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
        this.fsm.SwitchSate(EHackType.Hacked_Normal);
    }

    public override void OnRootHacked()
    {
        base.OnRootHacked();
        //this.curHackableElemet = null;
        this.fsm.SwitchSate(EHackType.Hacked_Root);
    }

    public override void OnDie()
    {
        base.OnDie();
        // gameObject.SetActive(false);
        ControllerManager.instance.ActorToStart();
    }

    public void SetHackableElement(SpecialElement element)
    {
        m_curHackableElement = element;
    }

    public SpecialElement GetElement()
    {
        return m_curHackableElement;
    }

    public bool IsIdle()
    {
        return fsm.IsEqualEnum(EHackType.Idle);
    }

}
