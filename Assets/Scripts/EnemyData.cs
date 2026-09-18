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

    [SerializeField] public PlayerData player_data;

    private void Awake()
    {
        player_data = FindAnyObjectByType<PlayerData>();
        currentHP = MaxHP;
    }

    private void LateUpdate()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);

            Instantiate(EXP_Prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
