using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurminatorController : MonoBehaviour
{
    public enum ETurminatorState
    {
        Idle,
        Hacking,
    }

    public Vector2 detectSize;
    public Vector3 offset;
    public ETurminatorState state = ETurminatorState.Idle;
    private bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.state == ETurminatorState.Idle) {
            this.Idle();
        } else if (state == ETurminatorState.Hacking) {
            if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) {
                HackOperating();
            }
        }
    }

    private void OnDrawGizmos()
    {
        BhvActorIdle.DebugDrawBox(transform.position + offset, detectSize);
    }

    private void Idle()
    {
        if (BhvActorIdle.CheckBoxWithActor(transform, detectSize, offset)) {
            if (!isEnter) {
                Debug.Log("Press J to Hack");
            }
            isEnter = true;
        } else {
            if (isEnter) {
                Debug.Log("Exit region");
                ControllerManager.instance.QuitHackMode();
                state = ETurminatorState.Idle;
            }
            isEnter = false;
        }

        if (isEnter) {
            if (Input.GetKeyDown(KeyCode.J)) {
                ControllerManager.instance.EnterHackMode();
                state = ETurminatorState.Hacking;
            }
        }


    }
    private void HackOperating()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            ControllerManager.instance.LastHack();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            ControllerManager.instance.NextHack();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            ControllerManager.instance.QuitHackMode();
            state = ETurminatorState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (ControllerManager.instance.IsHacking()) return;
            var elemet = ControllerManager.instance.GetSelectedElement();
            if (elemet != null) {
                elemet.OnRootHacked();
                ControllerManager.instance.EnterHack(elemet);
                this.state = ETurminatorState.Idle;
            }

        }
    }

}
