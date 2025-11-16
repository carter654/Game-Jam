using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public static float bottomY = -20f;

    public float speed = 1f;
    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < bottomY){
            Destroy(this.gameObject);
        }
    }
}
