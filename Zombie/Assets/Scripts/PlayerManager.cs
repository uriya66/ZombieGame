using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float playerHealth = 100;
    public Slider slider;

    public GameManager gameManager;

    // When the player hit
    public void HitPlayer(float damage)
    {
        playerHealth -= damage;
        slider.value = playerHealth;

        if(playerHealth <= 0)
        {
            gameManager.EndGame();
        }
    }
}
