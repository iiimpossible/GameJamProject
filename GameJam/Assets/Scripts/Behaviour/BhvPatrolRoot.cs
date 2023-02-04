using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvPatrolRoot : ElementBehaviour<PatrolElement>
{


    public BhvPatrolRoot(Transform trans, PatrolElement e) : base(trans, e)
    {

    }


    public override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * element.speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * element.speed);
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * Time.deltaTime * element.speed);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * Time.deltaTime * element.speed);
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            ControllerManager.instance.QuitHack();
        }
    }
}
