using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Speed of the bullet
    [SerializeField] float speed;

    // Rigidbody component of the bullet
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    void Update()
    {
        // Move the bullet
        MoveBullet();
    }

    void MoveBullet()
    {
        // Set the velocity of the bullet to move it in the forward direction (up) based on the speed and time
        rb.velocity = transform.up * speed * Time.deltaTime;
    }
}
