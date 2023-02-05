using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSquareNormalMove : ElementBehaviour<SquareElement>
{
    private ActorController actor;
    private Vector3 origin;
    private Vector3 target;
    [SerializeField]
    private float progress;
    [SerializeField]
    private float speed = 1;
    public bool reached { get; private set; }
    public BhvSquareNormalMove(Transform trans, SquareElement e) : base(trans, e)
    {
        origin = transform.position;
        target = transform.position + (Vector3)element.moveDistance;
        actor = ControllerManager.instance.GetActor();
    }



    // Update is called once per frame
    public override void Update()
    {
        NomarlyHacked();
    }

    private Vector3 lastPos;

    protected void NomarlyHacked()
    {
        if (reached) return;
        progress += Time.deltaTime * speed;
        if (progress >= 1) {
            reached = true;
            element.OnIdle();
        }
        lastPos = transform.position;


        //var go = CheckBoxWithElmentArray(transform, element.actorDetectSize, element.actorDetectSize.y / 2, Vector3.zero, "Actor", "Element");
        //Debug.Log("NomarlyHacked " + go.Length);
        //if (go.Length > 0) {
        //    float a = Input.GetAxis("Horizontal");
        //    Vector3 offset = transform.position - lastPos;
        //    foreach (var g in go) {
        //        Debug.Log(g.name);
        //        if (g.transform == transform) continue;
        //        if (a != 0) {
        //            if (a < 0 && offset.x < 0 || a > 0 && offset.x > 0) {
        //                g.transform.position += offset;
        //            }
        //        } else {
        //            g.transform.position += offset;
        //        }

        //        //if (g.GetComponent<SpecialElement>().IsMoving()) continue;

        //    }
        //}

        transform.position = Vector3.Lerp(origin, target, progress);
    }
}
