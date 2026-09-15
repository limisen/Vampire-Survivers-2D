using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float MaxHP = 10;
    [SerializeField] public float currentHP;

    [SerializeField] public int DMG = 3;

    [SerializeField] public int EXP_to_Drop = 1;
    [SerializeField] GameObject EXP_Prefab;

    [SerializeField] public int score_to_give = 1;
    public PlayerData player_data;

    private void Start()
    {
        player_data = GetComponent<EnemyMovement>().Player.GetComponentInParent<PlayerData>();
    }
    private void LateUpdate()
    {
        if (currentHP <= 0)
        {
            GameObject EXP_Orb = Instantiate<GameObject>(EXP_Prefab, transform.position, Quaternion.identity); // Spawn EXP Orb
            EXP_Orb.GetComponent<EXP_Pick_Up>().EXP_to_give = score_to_give; // Set the EXP the orb gives to the Enemy's EXP_to_give
            Destroy(gameObject); // Delete Self

            player_data.score += score_to_give; // Add the Enemy's score_to_give to the playerData.Score
        }
    }
}
