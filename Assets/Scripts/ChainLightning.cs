using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    [SerializeField] int amount_to_chain = 1;

    [SerializeField] int dmg = 1;

    [SerializeField] float time_between_Lightning = 2f;
    private float timeRemaining;

    GameObject[] Enemies;

    GameObject nearestObj;
    float distance;
    float nearestDistance = float.PositiveInfinity;

    GameObject Player;

    

    private void Awake()
    {
        timeRemaining = time_between_Lightning;

        Player = GameObject.FindWithTag("Player");
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
                causeLightning();
                // Then reset the timer in for the next spawn
                timeRemaining = time_between_Lightning;
            }
        }
    }

    void causeLightning()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Enemies.Length > 0)
        {

            for (int i = 0; i < Enemies.Length; i++)
            {
                distance = Vector3.Distance(transform.position, Enemies[i].transform.position);

                if (distance < nearestDistance)
                {
                    nearestObj = Enemies[i];
                    nearestDistance = distance;
                }
            }

            transform.position = nearestObj.transform.position;
            nearestObj.GetComponent<EnemyData>().currentHP -= dmg;

            for (int i = 1; i < amount_to_chain - 1; i++)
            {
                if (i >= Enemies.Length)
                {
                    return;
                }
                transform.position = Enemies[i].gameObject.transform.position;
                Enemies[i].gameObject.GetComponent<EnemyData>().currentHP -= dmg;
            }
            transform.localPosition = new Vector3(0,0,0);
        }
    }
}
