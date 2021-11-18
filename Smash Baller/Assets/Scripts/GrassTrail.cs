using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrail : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = new Vector3 (player.transform.position.x, 5, player.transform.position.z);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
