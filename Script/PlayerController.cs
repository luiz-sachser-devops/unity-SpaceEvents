using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed of the player
    [SerializeField] float speed;

    // Position limit for the player's movement
    [SerializeField] float limitPosition;

    // Prefab of the bullet object
    [SerializeField] GameObject bullet;

    // Transform for the cannon positions
    [SerializeField] Transform cannonPosition0, cannonPosition1, cannonPosition2;

    // Player's life
    [SerializeField] float life;

    // Delay between shots
    [SerializeField] float shootDelay;

    // Flag to check if player can shoot
    [SerializeField] bool canShoot;

    // SpriteRenderer component for color change
    [SerializeField] SpriteRenderer model;

    // Reference to the life bar script
    [SerializeField] LifeBar lifeBar;

    [SerializeField] AudioSource audioData;

    void Update()
    {
        // Handle player input
        if (Input.GetKey(KeyCode.A))
            MovePlayer(new Vector2(-1, 0));
        if (Input.GetKey(KeyCode.D))
            MovePlayer(new Vector2(1, 0));
        if (Input.GetKey(KeyCode.Space))
            if (canShoot)
                Shoot();
    }

    private IEnumerator DelayShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    void MovePlayer(Vector2 direction)
    {
        float removeSpeed = 1f;

        // Adjust speed based on player's remaining life
        if (life == 2)
            removeSpeed = 0.75f;
        else if (life == 1)
            removeSpeed = 0.5f;

        // Move the player based on direction, speed, and time
        transform.position = new Vector2(transform.position.x, transform.position.y) + (direction * (speed * removeSpeed) * Time.deltaTime);
    }

    void Shoot()
    {
        // Play sound
        audioData.Play();
        // Spawn bullets at the cannon positions
        Instantiate(bullet, cannonPosition0.position, cannonPosition0.rotation);
        Instantiate(bullet, cannonPosition1.position, cannonPosition1.rotation);
        Instantiate(bullet, cannonPosition2.position, cannonPosition2.rotation);

        // Disable shooting temporarily
        canShoot = false;
        StartCoroutine(DelayShoot(shootDelay));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with an asteroid
        if (collision.tag == "asteroid")
        {
            // Take damage, destroy the asteroid, and update UI
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage()
    {
        // Change player color temporarily
        StartCoroutine(ChangeColor(0.5f));

        // Decrease player's life and update the life bar UI
        life--;
        lifeBar.UpdateUI((int)life);

        // Check if the player's life is zero or below
        VerifyGameOver();
    }

    private IEnumerator ChangeColor(float waitTime)
    {
        // Change player color to red temporarily
        model.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        // Change player color back to white
        model.color = Color.white;
    }

    void VerifyGameOver()
    {
        // Check if the player's life is zero or below
        if (life <= 0)
            GameOver();
    }

    void GameOver()
    {
        // Restart the game
        Application.LoadLevel(0);
    }
}