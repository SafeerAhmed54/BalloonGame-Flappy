using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cubes;           // Prefab to instantiate
    public Vector3 spawnTransform;     // Base position for spawning
    public float startDelay = 1f;      // Initial delay before the first spawn
    public float spawnDelay = 2f;      // Delay between subsequent spawns

    [SerializeField] private GameManager gameManager;   // GameManager 
    //[SerializeField] private PlayerMove player;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        // Repeatedly invoke the SpawnCube method starting after startDelay, then every spawnDelay seconds
        InvokeRepeating("SpawnCube", startDelay, spawnDelay);
    }

    void SpawnCube()
    {
        // Get a random Y position within the specified range
        float randomSpawnY = Random.Range(5, 10.39f);

        // Create a new Vector3 for the spawn position
        Vector3 spawnPosition = new Vector3(spawnTransform.x, randomSpawnY, spawnTransform.z);

        // Instantiate the cube at the spawn position with the prefab's rotation
        Instantiate(cubes, spawnPosition, cubes.transform.rotation);
    }
}
