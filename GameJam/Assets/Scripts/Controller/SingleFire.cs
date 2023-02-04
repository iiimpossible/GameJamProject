using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFire : MonoBehaviour
{
    public Vector2 detectSize;
    public Vector3 offset;
    public string actorLayer = "Actor";
    public string elemetLayer = "Element";
    public float distance = 0.5f;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var go = BhvActorIdle.CheckBoxWithElment(transform, detectSize, distance, offset, actorLayer, elemetLayer);
        if (go != null) {
            if (go.layer == LayerMask.NameToLayer(actorLayer) && render.enabled) {
                var e = go.GetComponent<SpecialElement>();
                e?.OnDie();
            }
            if (go.layer == LayerMask.NameToLayer(elemetLayer)) {
                render.enabled = false;
            }

        } else {
            if (render.enabled == false) {
                render.enabled = true;
            }
        }
    }


    private void OnDrawGizmos()
    {
        BhvActorIdle.DebugDrawBox(transform.position + offset, detectSize);

    }

}
