using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    int score;
    int status;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        status = Random.Range(0, 4);
        float scale = Random.Range(0.5f, 1f);
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 4, 0);
        transform.localScale = new Vector3(scale,scale,scale);

        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
       switch (status)
        {
            case 0:
                score = 1;
                break;
                case 1:
                score = 2; break;
                case 2:
                score = 3; break;   
                case 3:
                score = -5;
                spriteRenderer.color = 
                    new Color(255 /255.0f, 100/255.0f, 255 / 255.0f);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("player");
            Destroy(this.gameObject);
            DataAManager.Instance.Score += score;
        }
        Destroy(this.gameObject);
    }


}
