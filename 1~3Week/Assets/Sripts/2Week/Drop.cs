using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void Start()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(0.5f, 1.4f);
        transform.localScale = new Vector3(size, size, size);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Game.I.GameOver();
        }
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
