using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAanimator;
    public float damage = 20f;
    public float enemyHealth = 100f;
    // Instance of the game manager
    public GameManager gameManager;
    public Slider slider;
    [Header("Sounds Elements")]
    public AudioClip[] sounds;
    private AudioSource audioSource;

    // When the enemy hit
    public void HitEnemy(float damage)
    {
        enemyHealth -= damage;
        slider.value = enemyHealth;
        PlayRandomSound();

        if (enemyHealth <= 0)
        {
            // Reducing the amount of enemies when they dead
            gameManager.enemiesAlive--;
            // Destroy the zombie
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Using the AudioSource inside the Game Manager
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy update evry single frame try to walk towards the player
        // Destination - set the destination of agent in world space
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        // Check if the speed of enemy from the navigation mesh more than 1 (is walking)
        // That mean if the speed it doesn't reach a certain magnitude
        // Magnitude return the length of the vector
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            // Set Walking to true
            enemyAanimator.SetBool("isWalking", true);
        }
        else
        {   
            enemyAanimator.SetBool("isWalking", false);
        }
    }

    //  Check if the collision of enemy hit the player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            // Call to hit method from player manager script
            player.GetComponent<PlayerManager>().HitPlayer(damage);
        }
    }

    // Play random sounds
    public void PlayRandomSound()
    {
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
