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
        if (a != 0) {
            var value = CheckWall(transform, transform.position, element.wallDetectDistance);
            if (value == ElementBehaviour<ActorController>.ECheckWallType.All) {
            } else if (value == ElementBehaviour<ActorController>.ECheckWallType.Left) {
                if (a > 0) {
                    transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
                }
            } else if (value == ElementBehaviour<ActorController>.ECheckWallType.Right) {
                if (a < 0) {
                    transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
                }
            } else {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            ControllerManager.instance.curHackableElemet?.OnNormalHacked();
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (ControllerManager.instance.curHackableElemet != null) {
                ControllerManager.instance.curHackableElemet?.OnRootHacked();
                ControllerManager.instance.EnterHack(ControllerManager.instance.curHackableElemet);
            }
        }
    }
}
