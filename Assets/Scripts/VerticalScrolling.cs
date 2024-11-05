using UnityEngine;

[RequireComponent(typeof(Camera))]
public class VerticalScrolling : MonoBehaviour
{
    private new Camera camera;
    private Transform player;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // track the player moving to the right
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = Mathf.Min(cameraPosition.y, player.position.y);
        transform.position = cameraPosition;
    }

}
