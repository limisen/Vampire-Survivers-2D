using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    
    
    [SerializeField] public float MaxHP = 10;
    [SerializeField] public float currentHP;

    
    [SerializeField] public int DMG = 3;


    [SerializeField] public float EXP_to_Drop = 1;
    [SerializeField] GameObject EXP_Prefab;

    [SerializeField] public int score_to_give = 1;

    private void Awake()
    {
        currentHP = MaxHP;
    }

    private void LateUpdate()
    {
        if (currentHP <= 0)
        {
            // Destroy the Enemy
            Destroy(gameObject);

            // Instansiate a EXP_orb at the current enemy position
            GameObject EXP_Orb = Instantiate(EXP_Prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            // Set the EXP this orb gives when picked up to be equal to the enemy's EXP_to_Drop
            EXP_Orb.GetComponent<EXP_Pick_Up>().EXP_to_give = EXP_to_Drop * (1 + GameManager.singleton.Player_current_lvl);

            // Increase the player's score for killing this enemy.
            GameManager.singleton.score += score_to_give;
        }
    }
}
