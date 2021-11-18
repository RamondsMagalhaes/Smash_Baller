using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject particle;
    private AudioSource thisAudioSource;
    public AudioClip cmon, firework;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        thisAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particle, other.transform.position, particle.transform.rotation);
            if (other.gameObject.CompareTag("Enemy"))
            {
                gameManager.UpdateScore(5);
                thisAudioSource.PlayOneShot(firework);
            }
            else
            {
                thisAudioSource.PlayOneShot(cmon);
                gameManager.GameOver();
            }
            Destroy(other.gameObject);
        }
    }
}
