using TMPro;
using UnityEngine;
using static Weapons;

public class LVL_Up_Script : MonoBehaviour
{
    private PlayerData Player;
    private ChainLightning_Data ChainLightningData;
    private Aura_Data AuraData;
    private MagicMissile_Data MagicMissileData;

    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>();

        MagicMissileData = Player.GetComponentInChildren<MagicMissile_Data>(true);
        AuraData = Player.GetComponentInChildren<Aura_Data>(true);
        ChainLightningData = Player.GetComponentInChildren<ChainLightning_Data>(true);
    }

    private void Start()
    {
        if (Player.current_lvl == 1)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                string weapon = "";

                switch (i)
                {
                    case 0:
                        weapon = "Magic Missile";
                        break;
                    case 1:
                        weapon = "Aura";
                        break;
                    case 2:
                        weapon = "Chain Lightning";
                        break;
                }
                gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText("Unlock " + weapon + "!");
                gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13;
            }
        }
    }

    private void OnDisable()
    {
        // Get the button TextComponents
        TextMeshProUGUI LVL_up_button_1_TextComponent = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI LVL_up_button_2_TextComponent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI LVL_up_button_3_TextComponent = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        // Default Values:
        LVL_up_button_1_TextComponent.SetText("Choose This!");
        LVL_up_button_1_TextComponent.fontSize = 20;
        LVL_up_button_2_TextComponent.SetText("Choose This!");
        LVL_up_button_2_TextComponent.fontSize = 20;
        LVL_up_button_3_TextComponent.SetText("Choose This!");
        LVL_up_button_3_TextComponent.fontSize = 20;
    }

    // Upgrade Choices, first what to upgrade, Which weapon or player stats, then decide based on that previous choice what relates to it and which atribute of it to increase or decrease
    public void Choice(int option)
    {
        
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
            


            switch (option)
            {
                case 0:
                    Debug.Log("Increasing DMG of 'Magic Missile'...");
                    MagicMissileData.DMG += 5;
                    MagicMissileData.amount_to_spawn += 1;
                    break;
                case 1:
                    Debug.Log("Increasing DMG of 'Aura'...");
                    AuraData.DMG += 1;
                    AuraData.radius += 5;
                    break;
                case 2:
                    Debug.Log("Increasing DMG of 'Chaing Lightning'...");
                    ChainLightningData.DMG += 1;
                    break;
            }
        }
    }
}
