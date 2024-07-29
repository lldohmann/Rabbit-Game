using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchToStartLogic : MonoBehaviour
{
    private float timer = 0.0f;
    public float flashSpeed = 1.0f;
    public bool selected;
    Image picture;
    // Start is called before the first frame update
    void Start()
    {
        picture = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || selected)
        {
            selected = true;

            timer += (flashSpeed * 50) * Time.deltaTime; // Magic number 50 controls flashSpeed. The higher the number, the faster the image flashes 
            if (timer >= flashSpeed)
            {
                picture.enabled = !picture.enabled;
                timer = 0.0f;
            }
        }
        else
        {
            timer += flashSpeed * Time.deltaTime;
            if (timer >= flashSpeed)
            {
                picture.enabled = !picture.enabled;
                timer = 0.0f;
            }
        }

    }
}
