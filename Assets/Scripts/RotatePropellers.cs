using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellers : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed);
    }
}
