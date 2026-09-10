using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public int MaxHP = 10;
    [SerializeField] public int currentHP;

    [SerializeField] public int DMG = 3;

    [SerializeField] public int EXP_to_Drop = 1;

    private void LateUpdate()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject); // Delete Self
        }
    }
}
