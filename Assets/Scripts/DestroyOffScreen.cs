using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField]
    private float zRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroy gameobjects that goes offscreen
        if(transform.position.z > zRange || transform.position.z < -zRange)
        {
            Destroy(gameObject);
        }
    }
}
