using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // control variables
    [SerializeField]
    private float speed = 10;
    // player Refrenece
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
