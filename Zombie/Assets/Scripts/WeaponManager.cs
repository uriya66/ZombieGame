using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponsCentralPointCam;
    [Header("Score Elements")]
    public float range = 100f;
    public float damage = 25f;
    public Animator playerAnimator;
    [Header("Sounds Elements")]
    public AudioClip shoothingSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
     
    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
            // If the left mouse button was clicked
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Player shooting
    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        // Play the shooting sound
        audioSource.PlayOneShot(shoothingSound);
        // Raycast Hit variable is a data struct that stores information about Ray’s collision
        RaycastHit hit;

        // out hit - what i have it
        if (Physics.Raycast(weaponsCentralPointCam.transform.position, transform.forward , out hit, range))
        {
            // If the thing that we hit has an EnemyManager assigned to it
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            // If enemyMangager is not null we hit an enemy
            if (enemyManager != null)
            {
                enemyManager.HitEnemy(damage);
            }
        }
    }
}
