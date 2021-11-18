using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundToGround : MonoBehaviour
{
    public float groundLevel = 6;

    private void LateUpdate()
    {
        if (transform.position.y > groundLevel)
        {
            transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
        }
    }
}
