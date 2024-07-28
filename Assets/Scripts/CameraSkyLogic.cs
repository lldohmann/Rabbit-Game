using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSkyLogic : MonoBehaviour
{
    public Camera camera;
    public Color afternoonSky = new Color(59f/255f, 153f/255f, 247f/255f);
    public Color twilightSky = new Color(255f/255f, 155f/255f, 241f/255f);
    public float duration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        camera.backgroundColor = Color.Lerp(afternoonSky, twilightSky, t);
    }
}
