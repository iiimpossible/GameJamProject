using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSquareIdle : ElementBehaviour<SquareElement>
{
    ActorController actor;
    SpriteRenderer renderer;
    private bool cur_enter = false;
    public BhvSquareIdle(Transform trans, SquareElement e) : base(trans, e)
    {
        actor = ControllerManager.instance.GetActor();
        renderer = element.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Vector3.Distance(actor.transform.position, transform.position) < element.idleCheckDistance) {
            if (!cur_enter) {
                renderer.color = Color.red;
                actor.SetHackableElement(element);
            }
            cur_enter = true;
        } else {
            if (cur_enter) {
                renderer.color = Color.white;
                actor.SetHackableElement(null);
            }
            cur_enter = false;
        }
    }
}
