using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SinMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        #if UNITY_EDITOR
        enabled = !EditorApplication.isPaused;
        #else
        enabled = true;
        #endif
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y = Mathf.Sin(Time.fixedDeltaTime + rigidbody.position.x);

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);


        Debug.DrawRay(rigidbody.position, new Vector3(velocity.x, 0.0f), Color.red); // Draws X Velocity
        Debug.DrawRay(rigidbody.position, new Vector3(0.0f, velocity.y), Color.green); // Draws Y Velocity
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();
            }
            else
            {
                player.Hit();
            }
        }
    }
    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        GameManager.Instance.AddScore(100);
        Destroy(gameObject, 3f);
    }
}
