using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    private float timeRemaining;

    GameObject[] Enemies;

    GameObject nearestObj;
    float distance;
    float nearestDistance = float.PositiveInfinity;


    private void Awake()
    {
        timeRemaining = GameManager.singleton.time_between_lightning;
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
                CauseLightning();
                // Then reset the timer in for the next spawn
                timeRemaining = GameManager.singleton.time_between_lightning;
            }
        }
    }

    void CauseLightning()
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
            nearestObj.GetComponent<EnemyData>().currentHP -= GameManager.singleton.Chain_Lightning_DMG;

            for (int i = 1; i < GameManager.singleton.amount_to_chain - 1; i++)
            {
                if (i >= Enemies.Length)
                {
                    return;
                }
                transform.position = Enemies[i].gameObject.transform.position;
                Enemies[i].gameObject.GetComponent<EnemyData>().currentHP -= GameManager.singleton.Chain_Lightning_DMG;
            }
            transform.localPosition = new Vector3(0,0,0);
        }
    }
}
