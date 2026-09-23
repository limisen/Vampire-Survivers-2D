using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{
    //private List<weapon> Weapons;

    //private void Awake()
    //{
    //    Weapons = new List<weapon>
    //    {
    //        MagicMissile,
    //        Aura,
    //        ChainLightning
    //    };


    //}

    private PlayerData Player;

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();

        }

        Player = FindAnyObjectByType<PlayerData>();
    }

    // Upgrade Choices, first what to upgrade, Which weapon or player stats, then decide based on that previous choice what relates to it and which atribute of it to increase or decrease
    public void Choice(int option)
    {
        int RNG;
        switch (option)
        {
            case 0:
                RNG = Random.Range(0, 4);

                switch (RNG)
                {
                    //case 0: // increase dmg of missiles
                        
                    //    break;

                    //case 1: // increase amount of missiles spawned
                    //    Player.ma
                    //        break;
                    //case 2: // increase speed of missile
                    //    Player.Magic_Missile_MoveSpeed += 5;
                    //    break;

                    //case 3: // decrease amount between missiles spawns
                    //    Player.
                    //        break;
                }
                Debug.Log("Choise " + option + " was choosen, rng: " + RNG);
                break;

            case 1:
                RNG = Random.Range(0, 3);
                //if (this == first Upgrade) { Get a new upgrade }
                Debug.Log("Choise " + option + " was choosen, rng: " + RNG);
                break;

            case 2:
                RNG = Random.Range(0, 3);
                //if (this == first Upgrade || 2nd upgrade) { Get a new upgrade }
                Debug.Log("Choise " + option + " was choosen, rng: " + RNG);
                break;

            default:
                break;
        }
    }
}
