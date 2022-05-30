using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : MonoBehaviour
{
    // control vars
    //private float followSpeed = 5f;
    private float fireRate = 1f;
    private float fireDelay = 0f;
    // game objects
    private GameObject playerRef;
    public Transform firePoint;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Player");
        InvokeRepeating(nameof(ShootProjectile), fireDelay, fireRate);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(playerRef.transform.position);
    }

    // shoot a projectile towards the player
    void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, transform.rotation);
    }
}
