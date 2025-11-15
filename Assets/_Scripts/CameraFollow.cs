using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float yOffset = 7f;

    void Update()
    {
        Vector3 playerPosition = player.transform.position;

        transform.position = new Vector3(transform.position.x, playerPosition.y + yOffset, transform.position.z);
    }
}
