using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab, wavePrefab;
    private GameManager gameManager;
    private float xBound, zBound, spawnInterval, spawnIntervalElapse;
    // Start is called before the first frame update
    void Start()
    {
        xBound = 7;
        zBound = 7;
        spawnInterval = 5;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIntervalElapse >= spawnInterval && gameManager.isGameActive)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-xBound, xBound),5.5f, Random.Range(-zBound, zBound));


            Instantiate(enemyPrefab, randomPosition, Quaternion.identity) ;
            Instantiate(wavePrefab, new Vector3 (randomPosition.x, 6, randomPosition.z), wavePrefab.transform.rotation);
            spawnIntervalElapse = 0;
            spawnInterval = Random.Range(3, 6);
        }
        else
        {
            spawnIntervalElapse += Time.deltaTime;
        }
    }

}
