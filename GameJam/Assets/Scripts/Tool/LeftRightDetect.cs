using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightDetect : MonoBehaviour
{
    string parentName;
    public bool left = false;

    public bool stop = false;

    public float detect = 1;
    private void Awake()
    {
        parentName = transform.parent.name;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = left ? Vector2.left : Vector2.right;
        var co = Physics2D.Raycast(transform.position, dir, detect);
        stop = co.collider != null;
        if (co.collider != null) {
            //Debug.Log(co.collider.name);
        }
    }
}
