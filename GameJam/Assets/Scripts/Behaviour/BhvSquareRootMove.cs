using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSquareRootMove : ElementBehaviour<SpecialElement>
{
    private ActorController actor;
    private Rigidbody2D rigidbody;

    public BhvSquareRootMove(Transform trans, SquareElement e) : base(trans, e)
    {
        this.rigidbody = element.GetComponent<Rigidbody2D>();
        actor = ControllerManager.instance.GetActor();
        rigidbody.mass = element.mass;
        rigidbody.gravityScale = element.gravity;
    }

    // Update is called once per frame
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
            var value = CheckWall(actor.transform, actor.transform.position, element.wallDetectDistance);
            if (value != ElementBehaviour<SpecialElement>.ECheckWallType.Right
                || value != ElementBehaviour<SpecialElement>.ECheckWallType.All) {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        } else if (a < 0) {
            var value = CheckWall(actor.transform, actor.transform.position, element.wallDetectDistance);
            if (value != ElementBehaviour<SpecialElement>.ECheckWallType.Left
                || value != ElementBehaviour<SpecialElement>.ECheckWallType.All) {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            ControllerManager.instance.QuitHack();
        }
    }

}
