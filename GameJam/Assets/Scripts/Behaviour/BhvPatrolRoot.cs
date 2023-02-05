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


        var value = CheckWall(transform, transform.position, element.wallDetectDistance);

        if (Input.GetKey(KeyCode.A)) {
            //if (Physics2D.RaycastAll(transform.position, Vector2.left, element.detectVertical).Length <= 1) {

            //}
            transform.Translate(Vector3.left * Time.deltaTime * element.speed);
            element.SetOrigin(transform.position);

        }

        if (Input.GetKey(KeyCode.D)) {
            //if (Physics2D.RaycastAll(transform.position, Vector2.right, element.detectVertical).Length <= 1) {

            //}
            transform.Translate(Vector3.right * Time.deltaTime * element.speed);
            element.SetOrigin(transform.position);
        }

        if (Input.GetKey(KeyCode.W)) {
            //if (Physics2D.RaycastAll(transform.position, Vector2.up, element.detectVertical).Length <= 1) {

            //}
            transform.Translate(Vector3.up * Time.deltaTime * element.speed);
            element.SetOrigin(transform.position);
        }

        if (Input.GetKey(KeyCode.S)) {
            //if (Physics2D.RaycastAll(transform.position, Vector2.down, element.detectVertical).Length <= 1) {

            //}
            transform.Translate(Vector3.down * Time.deltaTime * element.speed);
            element.SetOrigin(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            ControllerManager.instance.QuitHack();
        }
    }
}
