using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Upgrades;
using static Weapons;

public class LVL_Up_Script : MonoBehaviour
{
    PlayerData Player;
    ChainLightning_Data ChainLightningData;
    Aura_Data AuraData;
    MagicMissile_Data MagicMissileData;

    Upgrades Upgrades_ObjRef;
    List<Upgrades> choices;
    Upgrades UpgradeOption_1 = null;
    Upgrades UpgradeOption_2 = null;
    Upgrades UpgradeOption_3 = null;
    UpgradeableStats Option_1_statToUpgrade = UpgradeableStats.Unlocked; // Temporary assignment
    UpgradeableStats Option_2_statToUpgrade = UpgradeableStats.Unlocked; // Temporary assignment
    UpgradeableStats Option_3_statToUpgrade = UpgradeableStats.Unlocked; // Temporary assignment


    TextMeshProUGUI LVL_up_button_1_TextComponent;
    TextMeshProUGUI LVL_up_button_2_TextComponent;
    TextMeshProUGUI LVL_up_button_3_TextComponent;
    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>();

        Upgrades_ObjRef = Player.GetComponent<Upgrades>();

        // Get the Data Components
        MagicMissileData = Player.GetComponentInChildren<MagicMissile_Data>(true);
        AuraData = Player.GetComponentInChildren<Aura_Data>(true);
        ChainLightningData = Player.GetComponentInChildren<ChainLightning_Data>(true);

        // Get the button TextComponents
        LVL_up_button_1_TextComponent = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_2_TextComponent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_3_TextComponent = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        if (Player.current_lvl == 1)
        {
            UpgradeOption_1 = Upgrades_ObjRef.UpgradesList[0];
            UpgradeOption_2 = Upgrades_ObjRef.UpgradesList[1];
            UpgradeOption_3 = Upgrades_ObjRef.UpgradesList[2];

            LVL_up_button_1_TextComponent.text = UpgradeOption_1.Type.ToString() + " " + Option_1_statToUpgrade.ToString();
            LVL_up_button_2_TextComponent.text = UpgradeOption_2.Type.ToString() + " " + Option_2_statToUpgrade.ToString();
            LVL_up_button_3_TextComponent.text = UpgradeOption_3.Type.ToString() + " " + Option_3_statToUpgrade.ToString();
        }
        else
        {
            //    Get three unique choices of upgrades
            choices = Upgrades_ObjRef.GetRandomUpgrades(3);

            //Define what each upgrade option is and which stat it changes
            UpgradeOption_1 = choices[0];
            Option_1_statToUpgrade = UpgradeOption_1.AvailableStats[Random.Range(0, UpgradeOption_1.AvailableStats.Length)];

            UpgradeOption_2 = choices[1];
            Option_2_statToUpgrade = UpgradeOption_2.AvailableStats[Random.Range(0, UpgradeOption_2.AvailableStats.Length)];

            UpgradeOption_3 = choices[2];
            Option_3_statToUpgrade = UpgradeOption_3.AvailableStats[Random.Range(0, UpgradeOption_3.AvailableStats.Length)];

            LVL_up_button_1_TextComponent.text = UpgradeOption_1.Type.ToString() + " " + Option_1_statToUpgrade.ToString();
            LVL_up_button_2_TextComponent.text = UpgradeOption_2.Type.ToString() + " " + Option_2_statToUpgrade.ToString();
            LVL_up_button_3_TextComponent.text = UpgradeOption_3.Type.ToString() + " " + Option_3_statToUpgrade.ToString();
        }
    }

    public void Choice(int option)
    {
        switch (option)
        {
            case 0:

                ApplyUpgrade(0);
                break;
            case 1:

                ApplyUpgrade(1);
                break;
            case 2:

                ApplyUpgrade(2);
                break;
        }
    }

    void ApplyUpgrade(int index)
    {
        Upgrades selectedUpgrade = null;
        UpgradeableStats statToUpgrade = UpgradeableStats.Damage; // temporary assignment

        switch (index)
        {
            case 0:
                selectedUpgrade = UpgradeOption_1;
                statToUpgrade = Option_1_statToUpgrade;
                break;
            case 1:
                selectedUpgrade = UpgradeOption_2;
                statToUpgrade = Option_2_statToUpgrade;
                break;
            case 2:
                selectedUpgrade = UpgradeOption_3;
                statToUpgrade = Option_3_statToUpgrade;
                break;
        }


        switch (selectedUpgrade.Type)
        {
            case UpgradeType.MagicMissile:
                switch (statToUpgrade)
                {
                    case UpgradeableStats.Damage:
                        MagicMissileData.DMG += 2.5f;
                        break;

                    case UpgradeableStats.MoveSpeed:
                        MagicMissileData.MoveSpeed += 2.5f;
                        break;

                    case UpgradeableStats.AmountToSpawn:
                        MagicMissileData.amount_to_spawn += 1;
                        break;

                    case UpgradeableStats.TimeBetweenSpawns:
                        MagicMissileData.time_between_launch -= 0.5f;
                        break;
                    case UpgradeableStats.Unlocked:
                        Player.Magic_Missile_Unlocked = true;
                        Debug.Log("Pre modification: " + Upgrades_ObjRef.UpgradesList[0]);
                        Upgrades_ObjRef.UpgradesList[0] = new Upgrades
                            (
                                UpgradeType.ChainLightning,
                                UpgradeableStats.Damage,
                                UpgradeableStats.AmountToChain,
                                UpgradeableStats.TimeBetweenSpawns
                            );
                        Debug.Log("Post modification: " + Upgrades_ObjRef.UpgradesList[0]);
                        break;
                }
                break;

            case UpgradeType.Aura:
                switch (statToUpgrade)
                {
                    case UpgradeableStats.Damage:
                        AuraData.DMG += 2.5f;
                        break;

                    case UpgradeableStats.Radius:
                        AuraData.radius += 2.5f;
                        break;
                    case UpgradeableStats.Unlocked:
                        Player.Aura_Unlocked = true;
                        Debug.Log("Pre modification: " + Upgrades_ObjRef.UpgradesList[1]);
                        Upgrades_ObjRef.UpgradesList[1] = new Upgrades
                            (
                                UpgradeType.ChainLightning,
                                UpgradeableStats.Damage,
                                UpgradeableStats.AmountToChain,
                                UpgradeableStats.TimeBetweenSpawns
                            );
                        Debug.Log("Post modification: " + Upgrades_ObjRef.UpgradesList[1]);
                        break;
                }
                break;

            case UpgradeType.ChainLightning:

                switch (statToUpgrade)
                {
                    case UpgradeableStats.Damage:
                        ChainLightningData.DMG += 10;
                        break;

                    case UpgradeableStats.AmountToChain:
                        ChainLightningData.amount_to_chain += 1;
                        break;

                    case UpgradeableStats.TimeBetweenSpawns:
                        ChainLightningData.time_between_lightning -= 0.1f;
                        break;
                    case UpgradeableStats.Unlocked:
                        Player.Chain_Lightning_Unlocked = true;
                        Debug.Log("Pre modification: " + Upgrades_ObjRef.UpgradesList[2]);
                        Upgrades_ObjRef.UpgradesList[2] = new Upgrades
                            (
                                UpgradeType.ChainLightning,
                                UpgradeableStats.Damage,
                                UpgradeableStats.AmountToChain,
                                UpgradeableStats.TimeBetweenSpawns
                            );
                        Debug.Log("Post modification: " + Upgrades_ObjRef.UpgradesList[2]);
                        break;
                }

                break;

            case UpgradeType.Player:

                switch (statToUpgrade)
                {
                    case UpgradeableStats.MoveSpeed:
                        Player.moveSpeed += 2.5f;
                        break;

                    case UpgradeableStats.MaxHP:
                        Player.MaxHP += 10;
                        Player.current_HP += 10;
                        break;
                }

                break;
        }
    }
}
