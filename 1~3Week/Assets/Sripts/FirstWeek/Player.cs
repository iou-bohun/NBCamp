using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float dir = 0.02f;
    private float toward = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            dir *= -1;
            toward *= -1;
        }
        if(transform.position.x > 2.25)
        {
            dir *= -1;
            toward *= -1;
        }
        if(transform.position.x <-2.25)
        {
            dir *= -1;
            toward *= -1;
        }
        transform.localScale = new Vector3(toward, 1, 1);
        transform.position += new Vector3(dir, 0, 0);
    }
}
