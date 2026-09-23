using UnityEngine;

public class MagicMissile_Spawner : Weapons.MagicMissile_Data
{
    [SerializeField] GameObject missile_Prefab;

    private float timeRemaining;

    private MagicMissile_Data MissileData;

    private void Awake()
    {
        MissileData = FindAnyObjectByType<MagicMissile_Data>();
    }

    private void Start()
    {
        // Starte the timer
        timeRemaining = time_between_launch;
    }

    private void Update()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            // incriment the timer
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                for (int i = 1; i < amount_to_spawn + 1; i++)
                {
                    // Spawn the enemy if we have reached 0 on the timer
                    GameObject spawned_Missile = Instantiate(missile_Prefab, transform.position + new Vector3(Random.Range(-1,2), Random.Range(-1, 2), 0), Quaternion.identity);
                    spawned_Missile.GetComponentInChildren<Missile_HitDetection>().DMG = MissileData.DMG;
                    spawned_Missile.GetComponent<MissileMovement>().MoveSpeed = MissileData.MoveSpeed;
                }
                // Then reset the timer in for the next spawn
                timeRemaining = time_between_launch;
            }
        }
    }
}