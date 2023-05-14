using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    // Life of the asteroid
    [SerializeField] int life;

    // Speed of the asteroid
    [SerializeField] float speed;

    void Update()
    {
        // Move the asteroid
        MoveAsteroid();
    }

    void MoveAsteroid()
    {
        // Move the asteroid vertically based on the speed and time
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with a bullet
        if (collision.tag == "bullet")
        {
            // Take damage and destroy the bullet
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage()
    {
        // Decrease the asteroid's life
        life--;

        // Check if the asteroid's life is zero or below
        if (life <= 0)
            Destroy(this.gameObject);
    }
}
