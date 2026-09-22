using UnityEngine;

public class EnemySpawner : EnemyData
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] SpawnPoints;

    [SerializeField] float time_between_spawns = 2f;
    [SerializeField] public float Enemies_to_spawn = 2f;
    private float timeRemaining;

    [SerializeField] bool scale_With_Time;

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

            if (timeRemaining <= 0)
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
        if (scale_With_Time)
        {
            Enemies_to_spawn += 0.3f;
        }

        for (int i = 0; i < Enemies_to_spawn; i++)
        {
            // Effectivly spawn a clone of the enemy at a random index, and spawn it at a random position of the spawnPoint positions, (With 0,0,0 rotation).
            Instantiate(enemies[Random.Range(0, enemies.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position, Quaternion.identity);
        }
    }
}
