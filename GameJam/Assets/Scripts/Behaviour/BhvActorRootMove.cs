using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvActorRootMove : ElementBehaviour<ActorController>
{

    enum EAcotorMoveState
    {
        Jump,
        Run,
        Idl,
    }

    private Rigidbody2D rigidbody;
    private SpriteRenderer renderer;
    private bool m_ismoving;
    private bool m_isJumping;
    EAcotorMoveState moveState = EAcotorMoveState.Idl;

    public BhvActorRootMove(Transform trans, ActorController contorller) : base(trans, contorller)
    {
        rigidbody = element.GetComponent<Rigidbody2D>();
        renderer = element.GetComponent<SpriteRenderer>();
        rigidbody.mass = element.mass;
        rigidbody.gravityScale = element.gravity;
    }


    private void SwitchState(EAcotorMoveState state)
    {
        if (state == EAcotorMoveState.Idl) {
            moveState = state;
            element.actorAnimator.Play("hero idle", 0);
        } else if (state == EAcotorMoveState.Jump) {
            moveState = state;
            element.actorAnimator.Play("hero jump", 0);
        } else if (state == EAcotorMoveState.Run) {
            moveState = state;
            element.actorAnimator.Play("hero run", 0);
        }
    }


    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rigidbody.velocity.sqrMagnitude > 0.1f) {

            } else {
                rigidbody.AddForce(Vector2.up * element.jumpFactor);
                if (moveState == EAcotorMoveState.Idl || moveState == EAcotorMoveState.Run)
                    SwitchState(EAcotorMoveState.Jump);
                return;
            }
        }

        if (rigidbody.velocity.sqrMagnitude < 4f) {
            if (moveState == EAcotorMoveState.Jump) {
                SwitchState(EAcotorMoveState.Idl);
            }
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
            element.SetMoving(true);
        } else {
            element.SetMoving(false);
        }

        if (a > 0) {
            renderer.flipX = false;
        } else if (a < 0) {
            renderer.flipX = true;
        }


        if (moveState != EAcotorMoveState.Jump) {
            if (a != 0) {
                if (moveState == EAcotorMoveState.Idl) {
                    this.SwitchState(EAcotorMoveState.Run);
                }
            } else {
                if (moveState == EAcotorMoveState.Run) {
                    this.SwitchState(EAcotorMoveState.Idl);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.H)) {
            var e = element.GetElement();
            e?.OnNormalHacked();
        }

    }
}
