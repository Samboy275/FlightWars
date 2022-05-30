using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    // control variables
    private float fireRate = 0.5f;
    private float horizontalSpeed = 10f;
    private float horizontalLimit = 4f;
    private float initialXpos;
    // game objects
    public GameObject projectilePrefab;
    // the fire point of the projectile
    [SerializeField]
    private Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
        // shoot projectiles in  a fixed rate
        InvokeRepeating(nameof(ShootProjectile), 0, fireRate);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > initialXpos + horizontalLimit)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        else if (transform.position.x < initialXpos - horizontalLimit)
        {
            horizontalSpeed = -horizontalSpeed;
        }

        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
    }

    // shoot a projectile
    private void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePosition.position, Quaternion.Euler(0, 180, 0));
    }
}
