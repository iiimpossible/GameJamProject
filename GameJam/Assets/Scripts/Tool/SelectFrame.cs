using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFrame : MonoBehaviour
{
    public SpriteRenderer render;
    private Bounds bounds;
    private Vector3 leftUp;
    private Vector3 rightUp;
    private Vector3 rightButttom;
    private Vector3 leftBUttom;
    // Start is called before the first frame update
    void Start()
    {
        bounds = render.bounds;
        leftUp = bounds.center;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
