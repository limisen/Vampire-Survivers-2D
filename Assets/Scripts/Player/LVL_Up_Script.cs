using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{
    Dictionary<string, Dictionary<string, object>> UpgradeOptions;
    static Dictionary<string, Dictionary<string, object>> PermanentUpgradeOptions;

    List<object> upgradeOption_1;
    List<object> upgradeOption_2;
    List<object> upgradeOption_3;


    TextMeshProUGUI LVL_up_button_1_TextComponent;
    TextMeshProUGUI LVL_up_button_2_TextComponent;
    TextMeshProUGUI LVL_up_button_3_TextComponent;
    private void Awake()
    {
        // Get the button TextComponents
        LVL_up_button_1_TextComponent = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_2_TextComponent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_3_TextComponent = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        PermanentUpgradeOptions = new Dictionary<string, Dictionary<string, object>>
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

        // Create a DEEP copy of the PermanentUpgradeOptions to be used for generating random upgrades
        UpgradeOptions = PermanentUpgradeOptions.ToDictionary(
        outer => outer.Key,
        outer => new Dictionary<string, object>(outer.Value)
    );
    }

    private void OnEnable()
    {
        if (GameManager.singleton.Player_current_lvl == 0)
        {
            // Give the player a choice of which weapon to start with.
            upgradeOption_1 = new List<object>() { "Magic Missile", "Unlocked", false };
            upgradeOption_2 = new List<object>() { "Aura", "Unlocked", false };
            upgradeOption_3 = new List<object>() { "Chain Lightning", "Unlocked", false };

            LVL_up_button_1_TextComponent.text = "Unlock Magic Missle";
            LVL_up_button_2_TextComponent.text = "Unlock Aura";
            LVL_up_button_3_TextComponent.text = "Unlock Chain Lightning";
        }
        else
        {
            // generate 3 unique upgrades
            upgradeOption_1 = GenerateUpgradeOption();
            upgradeOption_2 = GenerateUpgradeOption();
            upgradeOption_3 = GenerateUpgradeOption();

            // Set the text on the button to be what the upgrade is
            LVL_up_button_1_TextComponent.text = upgradeOption_1[0] + " " + upgradeOption_1[1];
            LVL_up_button_2_TextComponent.text = upgradeOption_2[0] + " " + upgradeOption_2[1];
            LVL_up_button_3_TextComponent.text = upgradeOption_3[0] + " " + upgradeOption_3[1];
        }
    }
    public void upgradeChoice(int choice)
    {
        // Depending on the chosen upgrade perform that upgrade
        switch (choice)
        {
            case 0:
                // Upgrade application happens here
                switch (upgradeOption_1[0].ToString())
                {
                    case "Magic Missile":
                        switch (upgradeOption_1[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Missile_DMG += 5;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Missile_MoveSpeed += 5;
                                break;
                            case "Amount To Spawn":
                                GameManager.singleton.amount_to_spawn += 1;
                                break;
                            case "Time Between Launch":
                                GameManager.singleton.time_between_launch -= 0.25f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Magic_Missile_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_1[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "Aura":
                        switch (upgradeOption_1[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Aura_DMG += 5;
                                break;
                            case "Radius":
                                GameManager.singleton.radius += 2;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Aura_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_1[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "Chain Lightning":
                        switch (upgradeOption_1[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Chain_Lightning_DMG += 5;
                                break;
                            case "Amount To Chain":
                                GameManager.singleton.radius += 1;
                                break;
                            case "Time Between Lightning":
                                GameManager.singleton.time_between_lightning -= 0.2f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Chain_Lightning_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_1[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "PlayerStats":
                        switch (upgradeOption_1[0].ToString())
                        {
                            case "Max HP":
                                GameManager.singleton.Player_MaxHP += 5;
                                GameManager.singleton.Player_current_HP += 5;
                                GameManager.singleton.gameMenu.HP_slider.maxValue = GameManager.singleton.Player_MaxHP;
                                GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Player_MoveSpeed += 2.5f;
                                break;
                        }
                        break;
                }
                break;
            case 1:
                switch (upgradeOption_2[0].ToString())
                {
                    case "Magic Missile":
                        switch (upgradeOption_2[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Missile_DMG += 5;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Missile_MoveSpeed += 5;
                                break;
                            case "Amount To Spawn":
                                GameManager.singleton.amount_to_spawn += 1;
                                break;
                            case "Time Between Launch":
                                GameManager.singleton.time_between_launch -= 0.25f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Magic_Missile_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_2[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "Aura":
                        switch (upgradeOption_2[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Aura_DMG += 5;
                                break;
                            case "Radius":
                                GameManager.singleton.radius += 2;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Aura_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_2[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "Chain Lightning":
                        switch (upgradeOption_2[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Chain_Lightning_DMG += 5;
                                break;
                            case "Amount To Chain":
                                GameManager.singleton.radius += 1;
                                break;
                            case "Time Between Lightning":
                                GameManager.singleton.time_between_lightning -= 0.2f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Chain_Lightning_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_2[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "PlayerStats":
                        switch (upgradeOption_2[0].ToString())
                        {
                            case "Max HP":
                                GameManager.singleton.Player_MaxHP += 5;
                                GameManager.singleton.Player_current_HP += 5;
                                GameManager.singleton.gameMenu.HP_slider.maxValue = GameManager.singleton.Player_MaxHP;
                                GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Player_MoveSpeed += 2.5f;
                                break;
                        }
                        break;
                }
                break;
            case 2:
                switch (upgradeOption_3[0].ToString())
                {
                    case "Magic Missile":
                        switch (upgradeOption_3[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Missile_DMG += 5;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Missile_MoveSpeed += 5;
                                break;
                            case "Amount To Spawn":
                                GameManager.singleton.amount_to_spawn += 1;
                                break;
                            case "Time Between Launch":
                                GameManager.singleton.time_between_launch -= 0.25f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Magic_Missile_Unlocked = true;
                                break;
                        }
                        break;
                    case "Aura":
                        switch (upgradeOption_3[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Aura_DMG += 5;
                                break;
                            case "Radius":
                                GameManager.singleton.radius += 2;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Aura_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_3[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "Chain Lightning":
                        switch (upgradeOption_3[1].ToString())
                        {
                            case "DMG":
                                GameManager.singleton.Chain_Lightning_DMG += 5;
                                break;
                            case "Amount To Chain":
                                GameManager.singleton.radius += 1;
                                break;
                            case "Time Between Lightning":
                                GameManager.singleton.time_between_lightning -= 0.2f;
                                break;
                            case "Unlocked":
                                GameManager.singleton.Chain_Lightning_Unlocked = true;
                                PermanentUpgradeOptions[upgradeOption_3[0].ToString()].Remove("Unlocked");
                                break;
                        }
                        break;
                    case "PlayerStats":
                        switch (upgradeOption_3[0].ToString())
                        {
                            case "Max HP":
                                GameManager.singleton.Player_MaxHP += 5;
                                GameManager.singleton.Player_current_HP += 5;
                                GameManager.singleton.gameMenu.HP_slider.maxValue = GameManager.singleton.Player_MaxHP;
                                GameManager.singleton.gameMenu.HP_slider.value = GameManager.singleton.Player_current_HP;
                                break;
                            case "MoveSpeed":
                                GameManager.singleton.Player_MoveSpeed += 2.5f;
                                break;
                        }
                        break;
                }
                break;
        }

        GameManager.singleton.Player_current_lvl++; // increase current lvl

        GameManager.singleton.current_EXP -= GameManager.singleton.EXP_to_next_lvl; // Reset the progress towards the next lvl BUT keep the excess exp (if there is any)
        GameManager.singleton.EXP_to_next_lvl += GameManager.singleton.EXP_to_next_lvl; // raise the EXP needed to levelUP

        GameManager.singleton.gameMenu.EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl; // Set the slider.maxValue to the new value
        GameManager.singleton.gameMenu.EXP_slider.value = GameManager.singleton.current_EXP; // Reflect new visual representation of the progress towards the next lvl


        // Reset the options of upgrades infor the next random upgrade choice BY creating a DEEP copy of the PermanentUpgradeOptions
        UpgradeOptions = PermanentUpgradeOptions.ToDictionary(
        outer => outer.Key,
        outer => new Dictionary<string, object>(outer.Value)
        );
    }

    // Generates a random upgrade option and returns List<object>(upgradeType, UpgradeAttribute, UpgradeCurrentValue)
    private List<object> GenerateUpgradeOption()
    {
        // Get a enumeratior so we can go through the upgrade options Types
        var enumerator = UpgradeOptions.GetEnumerator();

        // Randomly pick a type of upgrade.
        for (int i = 0; i < Random.Range(1, UpgradeOptions.Count); i++) // Make sure to move at least once as GetEnumerator() starts one step outside the index and can go on step outside the index
        {
            enumerator.MoveNext();
        }

        // Save the type of upgrade to a variable
        var randomTypeOfUpgrade = enumerator.Current.Key;

        // gets the inner dictionary (of UpgradeOptions)
        var attributes = enumerator.Current.Value;

        // Get a enumeratior so we can go through the "upgrade option"'s attributes
        var innerEnumerator = attributes.GetEnumerator();

        // Randomly pick a attribute to upgrade
        for (int i = 0; i < Random.Range(1, attributes.Count); i++)
        {
            innerEnumerator.MoveNext();
        }

        // Save the choosen attribute
        var randomUpgradeAttribute = innerEnumerator.Current.Key;

        // Save the Value of the choosen attribute
        var randomUpgradeValue = innerEnumerator.Current.Value;

        // Save the Entire generated option (type, attribute and value)
        var upgardeOption = new List<object>();

        upgardeOption.Add(randomTypeOfUpgrade);
        upgardeOption.Add(randomUpgradeAttribute);
        upgardeOption.Add(randomUpgradeValue);

        // Delete this specifc upgrade choice form possibilites infor next generation
        UpgradeOptions[randomTypeOfUpgrade].Remove(randomUpgradeAttribute);
        // If (somehow) all the attributes are used up delete that upgrade type
        if (UpgradeOptions[randomTypeOfUpgrade].Count == 0) { UpgradeOptions.Remove(randomTypeOfUpgrade); }

        return upgardeOption;
    }
}
