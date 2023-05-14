using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // Array of collectable prefabs
    [SerializeField] GameObject[] Collectableprefab;

    // Time interval between asteroid spawns
    [SerializeField] float secondSpawn = 0.5f;

    // Minimum and maximum values for random asteroid positions
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        // Start the coroutine for asteroid spawning
        StartCoroutine(AsteroidsSpawn());
    }

    IEnumerator AsteroidsSpawn()
    {
        while (true)
        {
            // Generate a random x position within the specified range
            var wanted = Random.Range(minTras, maxTras);

            // Create a new position vector with the random x position and the current y position
            var position = new Vector3(wanted, transform.position.y);

            // Instantiate a random collectable prefab at the generated position with no rotation
            GameObject gameObject = Instantiate(Collectableprefab[Random.Range(0, Collectableprefab.Length)], position, Quaternion.identity);

            // Wait for the specified time interval
            yield return new WaitForSeconds(secondSpawn);

            // Destroy the spawned collectable after a certain time
            Destroy(gameObject, 7f);
        }
    }
}
