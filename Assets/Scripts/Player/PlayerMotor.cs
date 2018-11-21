using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity;
    private Rigidbody2D rb;

    [SerializeField]
    private float maxSpeed, maxSpeedJump, radiusCircle;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private LayerMask layer;

    private bool grounded;

    public bool Grounded { get { return grounded; } }

    // Use this for initialization
    void Start() {
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        RunAndJumpPerform();
    }

    public void RunAndJump(Vector2 _velocity){
        velocity = _velocity;
    }

    private void RunAndJumpPerform()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position,radiusCircle, layer);
        if(grounded)
        {
            rb.AddForce(new Vector2(0f, velocity.y) * Time.deltaTime * maxSpeedJump, ForceMode2D.Impulse);
        }


        rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime, rb.velocity.y);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.transform.position, radiusCircle);
    }

}
