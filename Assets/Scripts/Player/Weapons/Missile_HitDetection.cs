using System.Collections.Generic;
using UnityEngine;

public class Missile_HitDetection : MonoBehaviour
{
    public float DMG;
    [SerializeField] FeedBackText TextPrefab;
    [SerializeField] private float TextEnlargeAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Deal the dmg to the enemy
            collision.gameObject.GetComponent<EnemyData>().currentHP -= DMG;

            // save it to a variable for easier access
            List<GameObject> ListOfEnemies = gameObject.GetComponentInParent<MissileMovement>().Enemies;

            // Remove the enemy from the list of enemies
            ListOfEnemies.Remove(collision.gameObject);

            // Destroy the Missle
            Destroy(gameObject.GetComponentInParent<MissileMovement>().gameObject);

            // Display the dmg dealt
            TextPopUps.SpawnText(TextPrefab , DMG.ToString(), transform.position, TextEnlargeAmount);
        }
    }
}
