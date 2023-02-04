using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvPatrol : ElementBehaviour<PatrolElement>
{

    private float progress = 0;
    private bool originToEnd = true;
    private Vector3 origin;
    private string actorLayer = "Actor";
    private string elementLayer = "Element";
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
        float a = Input.GetAxis("Horizontal");
        var go = CheckBoxWithElmentArray(transform, element.detectSize, element.detectSize.y / 2, Vector3.zero, actorLayer, elementLayer);
        if (go.Length > 0) {
            Vector3 offset = transform.position - origin;
            foreach (var g in go) {
                if (g.transform == transform) continue;
                if (a != 0) {
                    if (a < 0 && offset.x < 0 || a > 0 && offset.x > 0) {
                        g.transform.position += offset;
                    }
                } else {
                    g.transform.position += offset;
                }

                //if (g.GetComponent<SpecialElement>().IsMoving()) continue;

            }
        }

        origin = transform.position;
    }

}
