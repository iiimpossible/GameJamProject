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
            if (item.collider.isTrigger) continue;
            if (item.collider.name != actor.name) {
                value = ECheckWallType.Left;
            }
        }
        foreach (var item in right) {
            if (item.collider.isTrigger) continue;
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

    public static void DebugDrawBox(Vector2 center, Vector2 size)
    {
        Vector2 left_up = new Vector2(center.x - size.x / 2, center.y + size.y / 2);
        Vector2 right_up = new Vector2(center.x + size.x / 2, center.y + size.y / 2);
        Vector2 left_buttom = new Vector2(center.x - size.x / 2, center.y - size.y / 2);
        Vector2 right_buttom = new Vector2(center.x + size.x / 2, center.y - size.y / 2);
        Debug.DrawLine(left_up, right_up);
        Debug.DrawLine(right_up, right_buttom);
        Debug.DrawLine(right_buttom, left_buttom);
        Debug.DrawLine(left_buttom, left_up);
    }

    public static bool CheckBoxWithActor(Transform trans, Vector2 size, Vector3 offset = default, float distance = 1)
    {
        var hits = Physics2D.BoxCastAll(trans.transform.position + offset, size, 0, Vector2.up, distance);
        foreach (var item in hits) {
            if (item.collider.name == ControllerManager.instance.GetActor().name) {
                return true;
            }
        }
        return false;
    }

    public static GameObject CheckBoxWithElment(Transform trans, Vector2 size, float distance, Vector3 offset = default, params string[] layers)
    {
        var hits = Physics2D.BoxCastAll(trans.transform.position + offset, size, 0, Vector2.up, size.y * distance);
        Debug.Log(hits.Length);
        foreach (var item in hits) {
            foreach (var l in layers) {

                if (item.collider.gameObject.layer == LayerMask.NameToLayer(l)) {
                    Debug.Log(item.collider.name);
                    return item.collider.gameObject;
                }
            }
        }
        return null;
    }

    public static GameObject[] CheckBoxWithElmentArray(Transform trans, Vector2 size, float distance, Vector3 offset = default, params string[] layers)
    {
        List<GameObject> temp = new List<GameObject>();
        var hits = Physics2D.BoxCastAll(trans.transform.position + offset, size, 0, Vector2.up, size.y * distance);
        Debug.Log(hits.Length);
        foreach (var item in hits) {
            foreach (var l in layers) {
                if (item.collider.gameObject.layer == LayerMask.NameToLayer(l)) {
                    temp.Add(item.collider.gameObject);
                }
            }
        }
        return temp.ToArray();
    }

    public static bool LerpMove(Transform trans, ref Vector3 origin, ref Vector3 target, ref float progress, ref float speed)
    {
        progress += Time.deltaTime * speed;
        if (progress >= 1) {
            return true;
        }
        trans.position = Vector3.Lerp(origin, target, progress);
        return false;
    }
}
