using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // control variables
    [SerializeField]
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // keep objects moving down
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
