using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player;
    Rigidbody thisRigidbody;
    GameManager gameManager;
    AudioSource thisAudioSource;
    public float speed = 10;
    private float lookDirectionCooldownElapse, lookDirectionCooldown, playerImpactCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        thisRigidbody = GetComponent<Rigidbody>();
        playerImpactCooldown = 1.0f;
        lookDirectionCooldown = 0.25f;
        playerImpactCooldown -= lookDirectionCooldown;
        lookDirectionCooldownElapse = 0;
        gameManager = FindObjectOfType<GameManager>();
        thisAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player)
        {
            return;
        }
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        if (lookDirectionCooldownElapse >= lookDirectionCooldown && gameManager.isGameActive)
        {
            thisRigidbody.AddForce(lookDirection * speed, ForceMode.Impulse);
            lookDirectionCooldownElapse = 0;
        }
        else
        {
            lookDirectionCooldownElapse += Time.deltaTime;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 lookDirection = (transform.position - player.transform.position).normalized;
            thisRigidbody.AddForce(lookDirection * speed * 1.25f, ForceMode.Impulse);
            lookDirectionCooldownElapse = -playerImpactCooldown;
            gameManager.UpdateScore(1);
            thisAudioSource.Play();
        }
    }
}
