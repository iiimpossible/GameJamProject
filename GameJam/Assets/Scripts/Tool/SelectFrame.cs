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

    public Transform trans_leftUP;
    public Transform trans_rightUp;
    public Transform trans_rightButtom;
    public Transform trans_leftButtom;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Locate(SpriteRenderer renderer)
    {
        bounds = render.bounds;
        leftUp = bounds.center;
        Debug.Log("SelectFrame " + bounds.ToString());

    }
}
