using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{
    Dictionary<string, Dictionary<string, object>> UpgradeOptions;
    Dictionary<string, Dictionary<string, object>> PermanentUpgradeOptions;

    Dictionary<string, object> upgardeOption_1 = new Dictionary<string, object>();


    TextMeshProUGUI LVL_up_button_1_TextComponent;
    TextMeshProUGUI LVL_up_button_2_TextComponent;
    TextMeshProUGUI LVL_up_button_3_TextComponent;
    private void Awake()
    {
        // Get the button TextComponents
        LVL_up_button_1_TextComponent = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_2_TextComponent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_3_TextComponent = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        UpgradeOptions = new Dictionary<string, Dictionary<string, object>>
        {
            {"Magic Missile", new Dictionary<string, object>()
                {
                    { "DMG", 5},
                    { "MoveSpeed", 10},
                    { "Amount To Spawn", 5},
                    { "Time Between Launch", 5},
                    { "Unlocked", false}
                }
            },

            {"Aura", new Dictionary<string, object>()
                {
                    { "DMG", 5},
                    { "Radius", 5},
                    { "Unlocked", false}
                }
            },

            {"Chain Lightning", new Dictionary<string, object>()
                {
                    { "DMG", 5},
                    { "Amount To Chain", 1},
                    { "Time Between Lightning", 2},
                    { "Unlocked", false}
                }
            },

            {"Player Stats", new Dictionary<string, object>()
                {
                    { "Max HP", 5},
                    { "MoveSpeed", false}
                }
            },
        };

        PermanentUpgradeOptions = UpgradeOptions;
    }

    private void OnEnable()
    {
        // Get a enumeratior so we can go through the upgrade options Types
        var enumerator = UpgradeOptions.GetEnumerator();
        
        // Randomly pick a type of upgrade.
        for (int i = 0; i < Random.Range(1, UpgradeOptions.Count + 1); i++)
        {
            enumerator.MoveNext();
        }
        var randomTypeOfUpgrade = enumerator.Current.Key;
        var attributes = enumerator.Current.Value;
        // Get a enumeratior so we can go through the upgrade option attributes
        var innerEnumerator = attributes.GetEnumerator();

        for (int i = 0; i < Random.Range(1, attributes.Count + 1); i++)
        {
            innerEnumerator.MoveNext();
        }

        var randomUpgradeAttribute = innerEnumerator.Current.Key;

        var randomUpgradeValue = innerEnumerator.Current.Value;
        //var choosenUpgrade = UpgradeOptions[randomTypeOfUpgrade, randomUpgradeAttribute];

        //upgardeOption_1 = ??;

        if (GameManager.singleton.Player_current_lvl == 0)
        {
            // Give the player a choice of which weapon to start with.

            LVL_up_button_1_TextComponent.text = "Unlock Magic Missle";
            LVL_up_button_2_TextComponent.text = "Unlock Aura";
            LVL_up_button_3_TextComponent.text = "Unlock Chain Lightning";
        }
        else
        {
            // generate 3 unique upgrades by getting a random item from a list and per generation deleting the chosen item

            LVL_up_button_1_TextComponent.text = randomTypeOfUpgrade + " " + randomUpgradeAttribute;
            LVL_up_button_2_TextComponent.text = randomTypeOfUpgrade + " " + randomUpgradeAttribute;
            LVL_up_button_3_TextComponent.text = randomTypeOfUpgrade + " " + randomUpgradeAttribute;
        }
    }
    public void upgradeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                if (GameManager.singleton.Player_current_lvl == 0) GameManager.singleton.Magic_Missile_Unlocked = true;
                // Delete the option to get this unlock choice when next generating the upgrade choices
                else GameManager.singleton.Missile_DMG += 5;
                break;
            case 1:
                if (GameManager.singleton.Player_current_lvl == 0) GameManager.singleton.Aura_Unlocked = true;
                // Delete the option to get this unlock choice when next generating the upgrade choices
                else GameManager.singleton.Aura_DMG += 5;
                break;
            case 2:
                if (GameManager.singleton.Player_current_lvl == 0) GameManager.singleton.Chain_Lightning_Unlocked = true;
                // Delete the option to get this unlock choice when next generating the upgrade choices
                else GameManager.singleton.Chain_Lightning_DMG += 5;
                break;
        }
        GameManager.singleton.Player_current_lvl++; // increase current lvl

        GameManager.singleton.current_EXP -= GameManager.singleton.EXP_to_next_lvl; // Reset the progress towards the next lvl BUT keep the excess exp (if there is any)
        GameManager.singleton.EXP_to_next_lvl += GameManager.singleton.EXP_to_next_lvl; // raise the EXP needed to levelUP

        GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl; // Set the slider.maxValue to the new value
        GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP; // Reflect new visual representation of the progress towards the next lvl

        // Reset the options of upgrades infor the next random upgrade choice.
        UpgradeOptions = PermanentUpgradeOptions;
    }
}
