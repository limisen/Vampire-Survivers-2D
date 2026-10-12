using UnityEngine;
using UnityEngine.UIElements;

public class Aura : MonoBehaviour
{
    [SerializeField] FeedBackText TextPrefab;
    [SerializeField] private float TextEnlargeAmount;

    float timer;
    Collider2D[] Enemies;

    private void Awake()
    {
        timer = GameManager.singleton.Aura_TickRate;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        // Check if it's time to deal DMG
        if (GameManager.singleton.gamePaused == false && timer <= 0)
        {
            // Get the Enemies withing the Aura's Radius
            Enemies = Physics2D.OverlapCircleAll(transform.position, GameManager.singleton.Aura_Radius);

            // Starting from the last element, deal DMG to each enemy and spawn the DMG Text pop up.
            for (int i = 0; i < Enemies.Length; i++)
            {
                Debug.Log("Attempting to Deal Aura DMG to: " + Enemies[i]);
                if (Enemies[i].gameObject.CompareTag("Enemy")) 
                { 
                    Debug.Log("It is a Enemy! Dealing DMG");
                    Enemies[i].gameObject.GetComponent<EnemyData>().currentHP -= GameManager.singleton.Aura_DMG;
                    TextPopUps.SpawnText(TextPrefab, GameManager.singleton.Aura_DMG.ToString(), Enemies[i].transform.position, TextEnlargeAmount);
                }
            }
            // Reset The timer once we are done with all the enemies
            timer = GameManager.singleton.Aura_TickRate;
        }
    }
}
