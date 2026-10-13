using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    private float timeRemaining;
    private int amountChained;
    private int MAXamountToChain;

    private GameObject Trail;
    private GameObject Player;

    public List<GameObject> Enemies = new List<GameObject>();

    public GameObject nearestObj;
    float Enemy_distance;
    float nearestDistance = float.PositiveInfinity;


    public float DMG;
    [SerializeField] FeedBackText TextPrefab;
    [SerializeField] private float TextEnlargeAmount;


    AudioSource MasterAudioSource;
    [SerializeField] AudioClip Lightning_Hit_SFX;

    private void Awake()
    {
        timeRemaining = GameManager.singleton.time_between_lightning;
        MAXamountToChain = GameManager.singleton.amount_to_chain;
        DMG = GameManager.singleton.Chain_Lightning_DMG;
        Trail = this.transform.GetChild(0).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        MasterAudioSource = FindAnyObjectByType<AudioSource>();
    }

    private void Update()
    {
        if (GameManager.singleton.gamePaused == false)
        {
            // incriment the timer
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                
                CauseLightning();
            }
        }
    }

    void CauseLightning()
    {
        // Find all enemies in the scene
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();

        // If there are enemies in the scene, start the chain lightning effect
        if (Enemies.Count > 0)
        {
            // If the number of enemies is less than the max amount to chain, set the max amount to chain to the number of enemies (so we don't try to chain to more enemies than exist)
            if (Enemies.Count < MAXamountToChain)
            {
                MAXamountToChain = Enemies.Count;
            }
            else
            {   
                // otherwise, set the max amount to chain to the value in the GameManager
                MAXamountToChain = GameManager.singleton.amount_to_chain;
            }

            // Continue chaining until we reach the max amount to chain
            if (amountChained != MAXamountToChain)
            {
                if (Trail.activeSelf == false)
                {
                    Trail.GetComponent<TrailRenderer>().Clear(); // Clear the trail renderer so we don't see the trail from the place it stopped at.
                    this.transform.position = Player.transform.position; // make sure we origniate from the player

                    Trail.SetActive(true);
                }

                // Find the nearest enemy to the current position of the chain lightning
                FindNearest();

                // move towards enemy
                this.transform.position += 0.1f * (nearestObj.transform.position - this.transform.position);

                // Check if we are close enough to the enemy to deal damage
                float Am_I_Close_Enough = Vector3.Distance(this.transform.position, nearestObj.transform.position);
                if (Am_I_Close_Enough < 1)
                {
                    // make sure we deal the correct amount of DMG
                    DMG = GameManager.singleton.Chain_Lightning_DMG;

                    // Deal the DMG
                    nearestObj.GetComponent<EnemyData>().currentHP -= DMG;

                    // Display the dmg dealt
                    TextPopUps.SpawnText(TextPrefab, GameManager.singleton.Chain_Lightning_DMG.ToString(), transform.position, TextEnlargeAmount);

                    // Play SFX for when the lightning "hits" a enemy
                    MasterAudioSource.PlayOneShot(Lightning_Hit_SFX);

                    // Increment the amount we have chained.
                    amountChained++;

                    // If we have reached the max amount to chain, reset the chain lightning effect
                    if (amountChained == MAXamountToChain)
                    {
                        Trail.SetActive(false);
                        amountChained = 0;
                        timeRemaining = GameManager.singleton.time_between_lightning;
                        Trail.GetComponent<TrailRenderer>().Clear();
                    }
                }

                // double check if there are still enemies in the scene, if not, reset the chain lightning effect
                Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();
                if (Enemies.Count < amountChained || Enemies.Count == 0)
                {
                    Trail.SetActive(false);
                    amountChained = 0;
                    timeRemaining = GameManager.singleton.time_between_lightning;
                    Trail.GetComponent<TrailRenderer>().Clear();

                }
            }
        }
    }

    // Debugging function to draw a red wire sphere around the chain lightning object in the scene view, so we can see where it is and how close it is
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 1f);
    }

    // Function to find the nearest enemy
    public void FindNearest()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemy_distance = Vector3.Distance(this.transform.position, Enemies[i].transform.position);

            if (Enemy_distance < nearestDistance)
            {
                nearestObj = Enemies[i];
                nearestDistance = Enemy_distance;
            }
        }
        nearestDistance = float.PositiveInfinity;
    }
}
