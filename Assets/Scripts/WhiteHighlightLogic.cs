using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteHighlightLogic : MonoBehaviour
{
    public Image image;
    public Color afternoonSky = new Color(59f/255f, 153f/255f, 247f/255f);
    public Color twilightSky = new Color(255f/255f, 155f/255f, 241f/255f);
    public float duration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        image.color = Color.Lerp(afternoonSky, twilightSky, t);
    }
}
