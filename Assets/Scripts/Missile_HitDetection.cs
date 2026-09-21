using System.Collections.Generic;
using UnityEngine;

public class Missile_HitDetection : MonoBehaviour
{
    [SerializeField] float dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Deal the dmg to the enemy
            collision.gameObject.GetComponent<EnemyData>().currentHP -= dmg;

            // save it to a variable for easier access
            List<GameObject> ListOfEnemies = gameObject.GetComponentInParent<MissileMovement>().Enemies;

            // Remove the enemy from the list of enemies
            ListOfEnemies.Remove(collision.gameObject);

            // if the enemy is killed then dont destroy the missile otherwise deal dmg via the next missile. Untill the enemy is dead or no missiles remain
            if (collision.gameObject.GetComponent<EnemyData>().currentHP > 0)
            {
                // Destroy the Missle
                Destroy(gameObject.GetComponentInParent<MissileMovement>().gameObject);
            }
        }
    }
}
