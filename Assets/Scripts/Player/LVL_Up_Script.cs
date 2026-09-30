using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LVL_Up_Script : MonoBehaviour
{
    TextMeshProUGUI LVL_up_button_1_TextComponent;
    TextMeshProUGUI LVL_up_button_2_TextComponent;
    TextMeshProUGUI LVL_up_button_3_TextComponent;
    private void Awake()
    {
        // Get the button TextComponents
        LVL_up_button_1_TextComponent = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_2_TextComponent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        LVL_up_button_3_TextComponent = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        // Randomly pick 3 unique upgrade options.

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

            LVL_up_button_1_TextComponent.text = "Missile DMG +5";
            LVL_up_button_2_TextComponent.text = "Aura DMG +5";
            LVL_up_button_3_TextComponent.text = "Chain Lightning DMG +5";
        }
    }
    public void upgradeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                if (GameManager.singleton.Player_current_lvl == 0) GameManager.singleton.Magic_Missile_Unlocked= true;
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
    }
}
