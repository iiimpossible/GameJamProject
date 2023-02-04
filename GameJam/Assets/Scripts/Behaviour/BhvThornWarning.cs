using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvThornWarning : ElementBehaviour<ThornElement>
{

    public BhvThornWarning(Transform trans, ThornElement e) : base(trans, e)
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        if (!ControllerManager.instance.GetActor().gameObject.activeSelf) return;
        var hits = Physics2D.BoxCastAll(transform.position, element.deteckSize, 0, Vector2.up, element.deteckSize.y / 2);
        foreach (var item in hits) {
            if (item.collider.name == ControllerManager.instance.GetActor().name) {
                ControllerManager.instance.GetActor().OnDie();
            }
        }
    }
}
