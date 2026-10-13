using System;
using System.Collections;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    
    
    [SerializeField] public float MaxHP = 10;
    [SerializeField] public float currentHP;

    
    [SerializeField] public float DMG = 3;


    [SerializeField] public float EXP_to_Drop = 1;
    [SerializeField] GameObject EXP_Prefab;

    [SerializeField] public int score_to_give = 1;

    [SerializeField] private float ScaleAmount;

    [SerializeField] AudioSource MasterAudioSource;
    [SerializeField] AudioClip death_SFX_Clip;


    private void Awake()
    {
        // Scale the Enemy's MaxHP by multiplying it's bases value by the players current lvl + 1 every 4 min
        ScaleAmount = GameManager.singleton.Player_current_lvl + (Time.realtimeSinceStartup / 240);

        //DMG = DMG * (1 + GameManager.singleton.Player_current_lvl);
        MaxHP = MaxHP * ScaleAmount;

        currentHP = MaxHP;

        MasterAudioSource = GameObject.FindAnyObjectByType<AudioSource>();
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

            // Play the DeathSFX via a coroutine
            MasterAudioSource.PlayOneShot(death_SFX_Clip);
        }
    }
}
