using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab of the enemy with Rigidbody2D
    public Transform player;        // Reference to the player
    public Transform[] spawnPoints; // Array of spawn locations
    public float initialSpawnInterval = 2f; // Initial time interval between spawns
    public float minSpawnInterval = 0.5f;   // Minimum time interval between spawns
    public float decreaseRate = 0.05f;      // Amount by which the interval decreases over time
    public float enemySpeed = 5f;          // Initial speed of the enemy

    private float currentSpawnInterval;    // Current spawn interval
    private float spawnTimer;              // Timer to track time between spawns

    private void Start()
    {
        // Initialize spawn interval and timer
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    private void Update()
    {
        // Update the spawn timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn an enemy
        if (spawnTimer <= 0f)
        {
            EnemySpawner();

            // Decrease the spawn interval, clamped to a minimum value
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - decreaseRate, minSpawnInterval);

            // Reset the spawn timer
            spawnTimer = currentSpawnInterval;
        }
    }

    private void EnemySpawner()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null || player == null)
        {
            Debug.LogWarning("Missing required references in EnemySpawner!");
            return;
        }

        // Choose a random spawn point
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the enemy at the random spawn point
        GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Calculate direction towards the player
        Vector2 directionToPlayer = (player.position - randomSpawnPoint.position).normalized;

        // Set the initial velocity of the enemy
        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        if (enemyRb != null)
        {
            enemyRb.velocity = directionToPlayer * enemySpeed;
        }
        else
        {
            Debug.LogWarning("Enemy prefab is missing a Rigidbody2D component!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(other.gameObject);

    }
}
