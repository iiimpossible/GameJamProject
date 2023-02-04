using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSquareRootMove : ElementBehaviour<SpecialElement>
{

    private Rigidbody2D rigidbody;

    public BhvSquareRootMove(Transform trans, SpecialElement e) : base(trans, e)
    {
        this.rigidbody = element.GetComponent<Rigidbody2D>();
        rigidbody.mass = element.mass;
        rigidbody.gravityScale = element.gravity;
    }

    // Update is called once per frame
    // Update is called once per frame
    public override void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rigidbody.velocity.sqrMagnitude > 0.1f) return;
            rigidbody.AddForce(Vector2.up * element.jumpFactor);
        }

        float a = Input.GetAxis("Horizontal");
        if (a != 0) {
            var value = CheckWall(transform, transform.position, element.wallDetectDistance);
            if (value == ElementBehaviour<SpecialElement>.ECheckWallType.All) {
            } else if (value == ElementBehaviour<SpecialElement>.ECheckWallType.Left) {
                if (a > 0) {
                    transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
                }
            } else if (value == ElementBehaviour<SpecialElement>.ECheckWallType.Right) {
                if (a < 0) {
                    transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
                }
            } else {
                transform.Translate(Vector3.right * a * element.velocity * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            ControllerManager.instance.QuitHack();
        }
    }

}
