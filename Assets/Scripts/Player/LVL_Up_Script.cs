using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{
    private PlayerData Player;

    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>();
    }

    // Upgrade Choices, first what to upgrade, Which weapon or player stats, then decide based on that previous choice what relates to it and which atribute of it to increase or decrease
    public void Choice(int option)
    {
        // First check what lvl we are

        if (Player.current_lvl == 1)
        {
            switch (option)
            {
                case 0:
                    Debug.Log("Unlocking 'Magic Missile'...");
                    Player.Magic_Missile_Unlocked = true;
                    break;

                case 1:
                    Debug.Log("Unlocking 'Aura'...");
                    Player.Aura_Unlocked = true;
                    break;

                case 2:
                    Debug.Log("Unlocking 'Chain Lightning'...");
                    Player.Chain_Lightning_Unlocked = true;
                    break;
            }
        }
        else
        {
            Debug.Log("Not Players first upgrade... " + Player.current_lvl);
        }

    }
}
