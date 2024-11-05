using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogic : MonoBehaviour
{
    public float minPosX = 0.0f;
    public float maxPosX = -823.0f;
    public float speed = 150.0f;
    public float maxTimer = 40.0f;
    public float maxTimer2 = 100.0f;
    private float timer = 0;
    private bool title = true;
    RectTransform picture;

    // Start is called before the first frame update
    void Start()
    {
        picture = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= maxTimer)
        {
            MovePicture();
        }
        if (timer <= maxTimer2)
        {
            movePictureBack();
            timer = 0;
        }
    }

    void MovePicture()
    {
        while (picture.anchoredPosition.x >= maxPosX)
        {
            picture.anchoredPosition = new Vector2(picture.anchoredPosition.x - speed * Time.deltaTime, picture.anchoredPosition.y); // Code
        }
        title = false;
    }
    void movePictureBack()
    {
        while (picture.anchoredPosition.x <= minPosX)
        {
            picture.anchoredPosition = new Vector2(picture.anchoredPosition.x + speed * Time.deltaTime, picture.anchoredPosition.y); // Code
        }
        title = true;
    }
}
