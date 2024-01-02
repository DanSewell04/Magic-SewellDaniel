using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ShootProjectile : MonoBehaviour
{
    public float projectileSpeed = 5f;
    public float projectileLifetime = 2f; // Adjust this as needed
    public AudioClip fireSound;

    private float timer = 0f;
    private AudioSource audioSource;


    void Start()
    {
        
        Vector3 playerDirection = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        // Shoot the projectile in the player's facing direction
        GetComponent<Rigidbody2D>().velocity = playerDirection * projectileSpeed;

        //Grabs audio source component
        audioSource = GetComponent<AudioSource>();

        // Destroy the projectile after some time 
        Destroy(gameObject, projectileLifetime);

        // Play the fire sound if an audio clip is assigned
        if (fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
