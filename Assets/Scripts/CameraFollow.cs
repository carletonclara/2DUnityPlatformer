using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    public float offset;
    public float minX = 0f;
    public float maxX = 18f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.x += offset; 

        if (temp.x > minX && temp.x < maxX)
            transform.position = temp;
            

    }
}
