using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    // Array of life objects
    [SerializeField] GameObject[] lifes = new GameObject[3];

    // Method to update the UI based on current life count
    public void UpdateUI(int currentLife)
    {
        // Iterate through the life objects
        for (int i = 0; i < lifes.Length; i++)
        {
            // Set the visibility of each life object based on the current life count
            lifes[i].gameObject.SetActive(currentLife >= i + 1);
        }
    }
}