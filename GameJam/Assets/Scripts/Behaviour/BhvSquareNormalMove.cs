using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSquareNormalMove : ElementBehaviour<SquareElement>
{

    private Vector3 origin;
    private Vector3 target;
    [SerializeField]
    private float progress;
    [SerializeField]
    private float speed = 1;
    public BhvSquareNormalMove(Transform trans, SquareElement e) : base(trans, e)
    {
        origin = transform.position;
        target = transform.position + (Vector3)element.moveDistance;
    }


    // Update is called once per frame
    public override void Update()
    {
        NomarlyHacked();
    }



    protected void NomarlyHacked()
    {
        progress += Time.deltaTime * speed;
        if (progress >= 1) return;
        transform.position = Vector3.Lerp(origin, target, progress);
    }
}
