using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //control variables
    [SerializeField]
    private int hp = 5;
    private float speed = 10f;
    [SerializeField]
    private float xlimit = 7.5f;
    [SerializeField]
    private float zlimit = 2;
    //components
    private Rigidbody playerRb;

    // Game Objects
    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // shoot a projectile
            gun.Shoot();
        }
        if (hp < 1)
        {
            Debug.Log("Game Over");
        }
    }

    //move player based on input
    void MovePlayer()
    {
        // get player input
        Vector3 movementInput = Vector3.zero;
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.z = Input.GetAxis("Vertical");
        // apply input to move the player
        transform.Translate(movementInput * speed * Time.deltaTime);
    }

    //constraint player movement
    void ConstraintMovement()
    {   
        //invinsible walls to constraint player movement

        //constraint horizontal movement
        if(transform.position.x > xlimit)
        {
            transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
        }  
        if(transform.position.x < -xlimit)
        {
            transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
        }

        // constraint on vertical movement
        if(transform.position.z > zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zlimit);
        }  
        if(transform.position.z < -zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zlimit);
        }
    }
    //collision detection
    void OnCollisionEnter(Collision collision)
    {
        // if the player hits an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ParticleSystem explosionRef = Instantiate(explosion, transform.position, explosion.transform.rotation);
            explosionRef.Play();
            Destroy(explosionRef, 2f);
            Debug.Log("Crashed on an enemy");
            GameManager.Instance.GameOver();
            // game over
        }
    }

    // trigger detection
    void OnTriggerEnter(Collider other)
    {
        // if the player hits a power up
        if (other.CompareTag("Power Up"))
        {
            // power up found
            Debug.Log("Power Up Got");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Projectile"))
        {
            Debug.Log("Hit By Bullet");
            hp--;
            if (hp <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
