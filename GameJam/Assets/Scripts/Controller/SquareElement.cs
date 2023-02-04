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

    public enum EMoveDirection
    {
        Up,
        Left,
        Right,
        Down,
    }


    [SerializeField]
    private EMoveDirection direction;
    [SerializeField]
    public Vector2 moveDistance;

    private LiteFSM fsm = new LiteFSM();

    private void Awake()
    {
        fsm.SwitchSate(ESquareState.Idle);
        origin = transform.position;
        target = transform.position + (Vector3)moveDistance;

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (fsm.IsEqualEnum(ESquareState.Idle)) {
            this.Idle();
        } else if (fsm.IsEqualEnum(ESquareState.Hacked_Unlock)) {
            this.NomarlyHacked();
        } else if (fsm.IsEqualEnum(ESquareState.Hacked_Controled)) {
            this.RootHacked();
        }

    }


    protected override void OnOverlayActor()
    {
        base.OnOverlayActor();
    }

    protected override void Idle()
    {
    }


    private Vector3 origin;
    private Vector3 target;
    [SerializeField]
    private float progress;
    [SerializeField]
    private float speed = 1;
    protected override void NomarlyHacked()
    {
        progress += Time.deltaTime * speed;
        if (progress >= 1) return;
        if (this.direction == EMoveDirection.Left) {
            transform.position = Vector3.Lerp(origin, target, progress);// (Vector3.right, )
        }

    }

    protected override void RootHacked()
    {
        base.RootHacked();
    }
}
