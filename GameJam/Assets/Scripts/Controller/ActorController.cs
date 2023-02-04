using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActorController : MonoBehaviour
{
    enum EMoveState
    {
        Jump,
        Idle,
    }

    private BoxCollider2D box;
    private Rigidbody2D rigidbody;
    [Range(100f, 1000f)]
    public float jumpFactor = 1;
    public float mass = 0.5f;
    public float gravity = 10;
    public float velocity = 1;
    [Range(0.01f, 100)]
    public float detect = 0.1f;
    public LeftRightDetect detectLeft;
    public LeftRightDetect detectRight;

    private LiteFSM fsm = new LiteFSM();

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        box = transform.GetComponent<BoxCollider2D>();
        rigidbody.mass = mass;
        rigidbody.gravityScale = gravity;
        fsm.SwitchSate(EMoveState.Idle);
        ControllerManager.instance.RigisterActor(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rigidbody.velocity.sqrMagnitude > 0.1f) return;
            Debug.Log("Addforce ");
            rigidbody.AddForce(Vector2.up * jumpFactor);
        }



        float a = Input.GetAxis("Horizontal");

        if (a > 0) {
            if (!detectRight.stop) {
                transform.Translate(Vector3.right * a * velocity * Time.deltaTime);
            }
        } else if (a < 0) {
            if (!detectLeft.stop) {
                transform.Translate(Vector3.right * a * velocity * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.right * 10);
        Debug.DrawLine(transform.position, transform.position + Vector3.left * 10);
    }


}
