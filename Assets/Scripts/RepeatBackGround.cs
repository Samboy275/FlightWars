using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    float speed = 2;
    float repeatDistance = -30f;
    Vector3 startPos;
    float zStartPos = 45f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, -0.5f, zStartPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z < repeatDistance)
        {
            transform.position = startPos;
        }

        transform.position += -Vector3.forward * speed * Time.deltaTime;
    }
}
