using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolElement : SpecialElement
{


    public Vector3 origin;
    public Vector3 end;
    public Vector2 detectSize;
    public float detectHorizetal;
    public float detectVertical;

    [Range(0.1f, 2f)]
    public float speed;

    private BhvPatrol m_patrolIdle;
    private BhvPatrolRoot m_patrolRoot;

    [SerializeField]
    private LiteFSM fSM = new LiteFSM();
    private Vector3 endOffset;
    private bool isAwake = false;
    private void Awake()
    {
        origin = transform.position;
        endOffset = end;
        end = origin + end;

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        fSM.SwitchSate(EHackType.Idle);
        m_patrolIdle = new BhvPatrol(transform, this);
        m_patrolRoot = new BhvPatrolRoot(transform, this);
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

# if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (this.isAwake) {
            Debug.DrawLine(origin, end);
        } else {
            Debug.DrawLine(transform.position, transform.position + end);
        }
        //right
        Debug.DrawLine(transform.position, transform.position + new Vector3(detectHorizetal, 0, 0));
        //left
        Debug.DrawLine(transform.position, transform.position + new Vector3(-detectHorizetal, 0, 0));
        //up
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, detectVertical, 0));
        //button
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -detectVertical, 0));
    }
# endif
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
        this.end = origin + endOffset;
    }

}
