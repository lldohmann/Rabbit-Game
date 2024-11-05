using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    public bool rotateRight = true;
    public float rotateSpeed = 10.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                
            }
            else
            {
                player.Hit();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateRight)
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotateSpeed));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z - rotateSpeed));
        }
    }
}
