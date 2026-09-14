using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float time_between_spawns = 2f;
    private float timeRemaining;

    [SerializeField] GameObject[] list_of_enemies;
    [SerializeField] GameObject[] list_of_SpawnPoints;
    [SerializeField] GameMenu gameMenu;

    public void SpawnEnemy()
    {
        // Effectivly spawn a clone of the enemy at index a random index, and spawn it at a random position in the spawPoint list.
        Instantiate<GameObject>(list_of_enemies[Random.Range(0,list_of_enemies.Length)], list_of_SpawnPoints[Random.Range(0,list_of_SpawnPoints.Length)].transform);  
    }

    private void Start()
    {
        timeRemaining = time_between_spawns; // Starte the timer
    }

    private void Update()
    {
        if (gameMenu.gamePaused == false)
        {
            timeRemaining -= Time.deltaTime; // incriment the timer

            if (timeRemaining < 0)
            {
                // Spawn the enemy if we have reached 0 on the timer
                SpawnEnemy();
                timeRemaining = time_between_spawns;
            }
        }
    }
}
