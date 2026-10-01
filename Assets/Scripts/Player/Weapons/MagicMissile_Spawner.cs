using UnityEngine;

public class MagicMissile_Spawner : MonoBehaviour
{
    [SerializeField] GameObject missile_Prefab;
    private int amountSpawned;
    private float timeRemaining;
    private float delay;

    private void Start()
    {
        // Starte the timer
        timeRemaining = GameManager.singleton.time_between_launch;
    }

    private void Update()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            // incriment the timer
            timeRemaining -= Time.deltaTime;
            delay -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                if (delay <= 0)
                {
                    GameObject spawned_Missile = Instantiate(missile_Prefab, transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0), Quaternion.identity);
                    spawned_Missile.GetComponentInChildren<Missile_HitDetection>().DMG = GameManager.singleton.Missile_DMG;

                    amountSpawned++;
                    delay = 0.1f;
                }


                if (amountSpawned == GameManager.singleton.amount_to_spawn)
                {
                    amountSpawned = 0;
                    // Then reset the timer in for the next spawn
                    timeRemaining = GameManager.singleton.time_between_launch;
                }
            }
        }
    }
}