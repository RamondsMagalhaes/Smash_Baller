using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody thisRigidbody;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.isGameActive && !gameManager.isPause)
        {
            float speedControler = 1;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (horizontalInput != 0 && verticalInput != 0)
            {
                speedControler = 1.25f;
            }
            thisRigidbody.AddForce(Vector3.forward * speed/speedControler * verticalInput);
            thisRigidbody.AddForce(Vector3.right * speed/speedControler * horizontalInput);
        }

    }

}
