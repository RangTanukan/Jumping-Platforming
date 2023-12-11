using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 5f;
    public float speedMultiplier = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
        }
    }

    void ApplyPowerUp(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ApplySpeedBoost(speedMultiplier, powerUpDuration);
        }

        Destroy(gameObject);
    }
}


