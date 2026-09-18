using UnityEngine;

public class MagicMissile_Spawner : MonoBehaviour
{
    [SerializeField] int missiles_to_fire = 1;

    [SerializeField] GameObject missle_Prefab;

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

            if (timeRemaining <= 0)
            {
                for (int i = 1; i < missiles_to_fire + 1; i++)
                {
                    // Spawn the enemy if we have reached 0 on the timer
                    Instantiate(missle_Prefab, transform.position + new Vector3(1 + (1/i), 1 + (1/i), 0), Quaternion.identity);
                }
                // Then reset the timer in for the next spawn
                timeRemaining = time_between_spawns;
            }
        }
    }
}