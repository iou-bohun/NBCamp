using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float speed = 0.5f;
    private void Update()
    {
        transform.position += Vector3.up*speed;

        if(transform.position.y > 26f)
        {
            Destroy(gameObject);
        }
    }
}
