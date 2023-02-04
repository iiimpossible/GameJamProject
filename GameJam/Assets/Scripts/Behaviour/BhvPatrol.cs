using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvPatrol : ElementBehaviour<PatrolElement>
{

    private float progress = 0;
    private bool originToEnd = true;
    private Vector3 origin;
    public BhvPatrol(Transform trans, PatrolElement element) : base(trans, element)
    {
        origin = trans.position;
    }


    public override void Update()
    {
        base.Update();



        if (originToEnd) {
            if (LerpMove(transform, ref element.origin, ref element.end, ref progress, ref element.speed)) {
                progress = 0;
                originToEnd = !originToEnd;

            }
        } else {
            if (LerpMove(transform, ref element.end, ref element.origin, ref progress, ref element.speed)) {
                progress = 0;
                originToEnd = !originToEnd;

            }
        }



        if (CheckBoxWithActor(transform, element.detectSize, Vector3.zero, element.detectSize.y / 2)) {
            Vector3 offset = transform.position - origin;
            var actor = ControllerManager.instance.GetActor();
            actor.transform.position += offset;
        }

        origin = transform.position;
    }

}
