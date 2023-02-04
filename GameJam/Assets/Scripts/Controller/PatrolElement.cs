using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolElement : SpecialElement
{


    public Vector3 origin;
    public Vector3 end;
    public Vector2 detectSize;
    [Range(0.1f, 2f)]
    public float speed;

    private BhvPatrol m_patrolIdle;
    private BhvPatrolRoot m_patrolRoot;
    [SerializeField]
    private LiteFSM fSM = new LiteFSM();

    private bool isAwake = false;
    private void Awake()
    {
        origin = transform.position;
        end = origin + end;
        fSM.SwitchSate(EHackType.Idle);
        m_patrolIdle = new BhvPatrol(transform, this);
        m_patrolRoot = new BhvPatrolRoot(transform, this);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isAwake = true;
    }

    private void Update()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) return;
        if (fSM.IsEqualEnum(EHackType.Idle)) {
            m_patrolIdle.Update();
        } else if (fSM.IsEqualEnum(EHackType.Hacked_Root)) {
            m_patrolRoot.Update();
        }
    }

    public override void OnIdle()
    {
        base.OnIdle();
        fSM.SwitchSate(EHackType.Idle);
    }

    public override void OnNormalHacked()
    {
        base.OnNormalHacked();
    }

    public override void OnRootHacked()
    {
        base.OnRootHacked();
        fSM.SwitchSate(EHackType.Hacked_Root);
    }

    public override void OnQuitHack()
    {
        this.fSM.SwitchSate(EHackType.Idle);
        base.OnQuitHack();
    }


    private void OnDrawGizmos()
    {
        if (this.isAwake) {
            Debug.DrawLine(origin, end);
        } else {
            Debug.DrawLine(transform.position, transform.position + end);
        }

        BhvActorIdle.DebugDrawBox(transform.position, detectSize);
    }
}
