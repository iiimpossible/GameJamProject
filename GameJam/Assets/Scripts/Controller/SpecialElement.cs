using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialElement : MonoBehaviour
{
    public GameObject actor;
    public float distance;
    private bool enter;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ControllerManager.instance.Rigister(this);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log(Vector3.Distance(actor.transform.position, transform.position));
        if (Vector3.Distance(actor.transform.position, transform.position) < distance) {

            OnOverlayActor();
        }
    }


    protected virtual void OnOverlayActor()
    {
        Debug.Log("Actor");
    }

    protected virtual void Idle()
    {

    }

    protected virtual void NomarlyHacked()
    {

    }

    protected virtual void RootHacked()
    {

    }
}
