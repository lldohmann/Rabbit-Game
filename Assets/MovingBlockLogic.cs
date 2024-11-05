using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockLogic : MonoBehaviour
{
    [SerializeField]
    private Transform position1, position2; // pos1 is the min, pos2 to the max
    [SerializeField]
    private float _speed = 3.0f;
    private bool _switch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        //if (_switch == false)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, position1.position,
        //        _speed * Time.deltaTime);
        //}
        //else if (_switch == true)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, position2.position,
        //        _speed * Time.deltaTime);
        //}

        //if (transform.position == position1.position)
        //{
        //    _switch = true;
        //}
        //else if (transform.position == position2.position)
        //{
        //    _switch = false;
        //}
    }

    public void Fall()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -5, transform.position.z), 50);
    }

    // Keeps the player moving on the platform
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
            Invoke(nameof(Fall), 2);
        }
    }
}
