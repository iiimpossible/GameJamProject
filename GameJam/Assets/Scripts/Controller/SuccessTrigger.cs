using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTrigger : MonoBehaviour
{

    public Vector2 detectSize;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BhvActorIdle.CheckBoxWithActor(transform, detectSize, Vector3.zero, detectSize.y * distance)) {
            Debug.Log("´³¹Ø³É¹¦");
        }
    }



    private void OnDrawGizmos()
    {
        BhvActorIdle.DebugDrawBox(transform.position, detectSize);
    }
}
