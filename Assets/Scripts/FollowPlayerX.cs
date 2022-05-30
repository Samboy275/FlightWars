using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    // control variables
    private float speed = 5f;
    // game objects

    private GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // follow player on the x axis
        Vector3 dirToPlayer = playerRef.transform.position - transform.position;
        dirToPlayer = new Vector3(dirToPlayer.x, 0, 0);
        transform.position += dirToPlayer * speed * Time.deltaTime;
    }
}
