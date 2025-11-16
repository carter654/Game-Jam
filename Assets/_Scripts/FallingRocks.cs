using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public static float bottomY = -20f;

    public float speed = 5f;
    
    void Update()
    {
        Vector3 pos = transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
        pos = rb.position;
        transform.position = pos;

        if (transform.position.y < bottomY){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Main.ResetPlayer();
            Debug.Log("Falling rock hit the player!");
            Destroy(this.gameObject);
        }
    }
}
