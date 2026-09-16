using UnityEngine;

public class EnemySpawner : EnemyData
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] SpawnPoints;

    [SerializeField] float time_between_spawns = 2f;
    private float timeRemaining;


    private void Start()
    {
        // Starte the timer
        timeRemaining = time_between_spawns;
    }

    private void Update()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            // incriment the timer
            timeRemaining -= Time.deltaTime; 

            if (timeRemaining < 0)
            {
                // Spawn the enemy if we have reached 0 on the timer
                SpawnEnemy();
                // Then reset the timer in for the next spawn
                timeRemaining = time_between_spawns;
            }
        }
    }

    public void SpawnEnemy()
    {
        // Effectivly spawn a clone of the enemy at a random index, and spawn it at a random position of the spawnPoint positions, (With 0,0,0 rotation).
        Instantiate(enemies[Random.Range(0, enemies.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position, Quaternion.identity);
    }
}
