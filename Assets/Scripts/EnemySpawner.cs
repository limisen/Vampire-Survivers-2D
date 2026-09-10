using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float time_between_spawns = 2f;
    private float timeRemaining;

    [SerializeField] GameObject[] list_of_enemies;


    public void SpawnEnemy()
    {
        Instantiate<GameObject>(list_of_enemies[0], transform); // Effectivly spawn a clone of the enemy at index 0. 
    }

    private void Start()
    {
        timeRemaining = time_between_spawns;
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            SpawnEnemy();
            timeRemaining = time_between_spawns;
        }
    }
}
