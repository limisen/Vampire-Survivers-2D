using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitDetection : MonoBehaviour
{
    public float DMG;
    [SerializeField] FeedBackText TextPrefab;
    [SerializeField] private float TextEnlargeAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal the dmg to the Player
            GameObject.FindAnyObjectByType<GameManager>().Player_current_HP -= DMG;

            // Destroy the Projectile
            Destroy(this.gameObject);

            // Display the dmg dealt
            TextPopUps.SpawnText(TextPrefab, DMG.ToString(), transform.position, TextEnlargeAmount);
        }
    }
}
