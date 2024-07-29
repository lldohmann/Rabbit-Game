using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grenade : MonoBehaviour
{
    private Vector2 velocity;
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2f);

    public bool grounded { get; private set; }
    public bool boucing { get; private set; }
    public bool falling => velocity.y < 0f && !grounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
    }
    private void FixedUpdate()
    {
        // move mario based on his velocity
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        rigidbody.MovePosition(position);
        Debug.DrawRay(rigidbody.position, new Vector3(velocity.x, 0.0f), Color.red); // Draws X Velocity
        Debug.DrawRay(rigidbody.position, new Vector3(0.0f, velocity.y), Color.green); // Draws Y Velocity
    }
    private void ApplyGravity()
    {
        // check if falling
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // apply gravity and terminal velocity
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            // bounce off enemy head
            if (transform.DotTest(collision.transform, Vector2.down))
            {
                velocity.y = jumpForce / 2f;
                boucing = true;
            }
        }
    }
}
