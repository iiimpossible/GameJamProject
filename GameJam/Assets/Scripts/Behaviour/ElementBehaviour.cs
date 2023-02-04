using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBehaviour<T> where T : SpecialElement
{
    public Transform transform;
    public T element;
    public ElementBehaviour(Transform trans, T e)
    {
        this.transform = trans;
        this.element = e;
    }


    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public enum ECheckWallType
    {
        None,
        All,
        Left,
        Right,
    }


    public ECheckWallType CheckWall(Transform actor, Vector3 start, float distance)
    {
        ECheckWallType value = ECheckWallType.None;
        var left = Physics2D.RaycastAll(start, Vector2.left, distance);
        var right = Physics2D.RaycastAll(start, Vector2.right, distance);

        foreach (var item in left) {
            if (item.collider.name != actor.name) {
                value = ECheckWallType.Left;
            }
        }
        foreach (var item in right) {
            if (item.collider.name != actor.name) {
                if (value == ECheckWallType.Left) {
                    value = ECheckWallType.All;
                } else {
                    value = ECheckWallType.Right;
                }

            }
        }
        //Debug.Log("CheckWall " + value);
        return value;
    }
}
