using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlashingColor : MonoBehaviour
{
    public Tilemap spriteRenderer { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<Tilemap>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StarpowerAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StarpowerAnimation()
    {
        float elapsed = 0f;
        float duration = 10f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                spriteRenderer.color = Random.ColorHSV(spriteRenderer.color.grayscale, spriteRenderer.color.grayscale, 1f, 1f, 1f, 1f);
            }

            yield return null;
        }

        spriteRenderer.color = Color.white;
    }
}
