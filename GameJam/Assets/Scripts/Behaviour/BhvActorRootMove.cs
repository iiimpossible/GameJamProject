using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvActorRootMove : ElementBehaviour<ActorController>
{
    private Rigidbody2D rigidbody;
    public BhvActorRootMove(Transform trans, ActorController contorller) : base(trans, contorller)
    {
        rigidbody = element.GetComponent<Rigidbody2D>();
        rigidbody.mass = element.mass;
        rigidbody.gravityScale = element.gravity;
    }




    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rigidbody.velocity.sqrMagnitude > 0.1f) return;
            Debug.Log("Addforce ");
            rigidbody.AddForce(Vector2.up * element.jumpFactor);
        }



        float a = Input.GetAxis("Horizontal");

        if (a > 0) {
            if (!element.detectRight.stop) {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        } else if (a < 0) {
            if (!element.detectLeft.stop) {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            element.curHackableElemet?.OnNormalHacked();
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (element.curHackableElemet != null) {
                element.curHackableElemet?.OnRootHacked();
                ControllerManager.instance.EnterHack(element.curHackableElemet);
            }
        }
    }
}
