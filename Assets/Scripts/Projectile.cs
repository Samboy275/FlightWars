using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // control variables
    [SerializeField]
    private float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.tag);
        if (other.CompareTag("Player"))
        {
            // Todo : spawn explosion effect
        }
    }
}
