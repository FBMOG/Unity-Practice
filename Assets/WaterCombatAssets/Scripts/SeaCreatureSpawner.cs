using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeaCreatureSpawner : MonoBehaviour
{
    public GameObject[] seaCreatures; // Array of sea creatures to spawn
    public float spawnDelay = 5f; // Time delay between spawns
    public float spawnDistance = 10f; // Distance from edge of screen to spawn creature
    public float speed = 2f; // Speed at which creature moves across screen
    public float maxAngle = 10f; // Maximum angle at which creature moves
 
    private float minX, maxX, minY, maxY;
 
    // Start is called before the first frame update
    void Start()
    {
        // Get screen bounds
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2f, Camera.main.transform.position.z));
        minX = -screenBounds.x + spawnDistance;
        maxX = screenBounds.x - spawnDistance;
        minY = screenBounds.y;
        maxY = 5f;
 
        // Start spawning creatures
        InvokeRepeating("SpawnSeaCreature", spawnDelay, spawnDelay);
    }
 
    // Spawn a random sea creature at a random position on the left or right of the screen
    void SpawnSeaCreature()
{
    // Choose a random sea creature from the array
    GameObject seaCreaturePrefab = seaCreatures[Random.Range(0, seaCreatures.Length)];

    // Choose a random position on the left or right of the lower half of the screen
    float spawnY = Random.Range(minY, maxY / 2f);
    Vector3 spawnPosition = new Vector3(Random.Range(0f, 1f) < 0.5f ? minX : maxX, spawnY, 0f);

    // Instantiate the sea creature
    GameObject seaCreature = Instantiate(seaCreaturePrefab, spawnPosition, Quaternion.identity);

    // Flip the sprite if the creature is swimming from right to left
    if (spawnPosition.x > 0)
    {
        seaCreature.transform.localScale = new Vector3(-5f, 5f, 5f);
    }

    // Move the sea creature across the screen and destroy it when it goes offscreen
    Vector3 targetPosition = new Vector3(Random.Range(0f, 1f) < 0.5f ? maxX : minX, spawnY, 0f);
    float distance = Vector3.Distance(seaCreature.transform.position, targetPosition);
    float duration = distance / speed;
    LeanTween.move(seaCreature, targetPosition, duration).setOnComplete(() => Destroy(seaCreature));
}

}


