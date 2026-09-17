using UnityEngine;

public class Missile_HitDetection : MonoBehaviour
{
    [SerializeField] float dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyData>().currentHP -= dmg;
            Destroy(gameObject.GetComponentInParent<MissileMovement>().gameObject);
        }
    }
}
