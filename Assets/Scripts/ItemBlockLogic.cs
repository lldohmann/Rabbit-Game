using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockLogic : MonoBehaviour
{
    public GameObject item;
    public AudioSource blockHit;
    //public AudioSource itemSound;
    public Sprite emptyBlock;
    public Sprite[] sprites;
    public int maxHits = -1;
    private bool animating; // Just when bouncing up and down. Not for flashing lights or sprite work
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateFlash), framerate, framerate);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void AnimateFlash()
    {
        if (maxHits == 0)
        {
            frame++;

            if (frame >= sprites.Length)
            {
                frame = 0;
            }

            if (frame >= 0 && frame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[frame];
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true; // show if hidden
        blockHit.Play();

        maxHits--;

        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
        }

        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            //itemSound.Play();
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

}
