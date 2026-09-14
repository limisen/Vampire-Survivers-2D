using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float MaxHP = 10;
    [SerializeField] public float current_HP = 0;

    [SerializeField] public int DMG = 1;

    [SerializeField] public float EXP_to_next_lvl = 5f;
    [SerializeField] public float current_EXP = 0;
    [SerializeField] public float current_lvl = 1;
    public int upgrades_Chosen = 1;

    public int score = 0;

    [SerializeField] public GameMenu gameMenu;

    void Start()
    {
        current_HP = MaxHP;

        gameMenu.HP_slider.maxValue = MaxHP;
    }

    void Update()
    {
        gameMenu.EXP_slider.value = current_EXP;
        gameMenu.HP_slider.value = current_HP;


        if (current_HP <= 0)
        {
            Debug.Log("Player Died");
            gameMenu.gamePaused = true;
            gameMenu.Player_UI.SetActive(false);
            gameMenu.GameOverMenu.SetActive(true);
        }

        gameMenu.Player_Score_UI.text = "Score: " + score.ToString();
    }

    public void On_level_up()
    {
        // IF lvl up with exact EXP
        if (current_EXP == EXP_to_next_lvl)
        {
            gameMenu.LvL_Up_Menu.SetActive(true);
            gameMenu.gamePaused = true;

            current_lvl++; // increase current lvl
            EXP_to_next_lvl += EXP_to_next_lvl * current_lvl; // raise the EXP needed to levelUP
            current_EXP = 0; // Reset the progress towards the next lvl

            gameMenu.EXP_slider.maxValue = EXP_to_next_lvl; // Set the max value to the new value
            gameMenu.EXP_slider.value = 0; // Reset the visual progress towards the next lvl
        }
        // IF lvl up with excess EXP
        else if (current_EXP > EXP_to_next_lvl)
        {
            gameMenu.LvL_Up_Menu.SetActive(true);
            gameMenu.gamePaused = true;

            current_lvl++; // increase current lvl

            current_EXP -= EXP_to_next_lvl; // Reset the progress towards the next lvl BUT keep the excess exp

            EXP_to_next_lvl += EXP_to_next_lvl * current_lvl; // raise the EXP needed to levelUP

            gameMenu.EXP_slider.maxValue = EXP_to_next_lvl; // Set the max value to the new value
            gameMenu.EXP_slider.value = current_EXP; // Reset the visual progress towards the next lvl

            On_level_up(); // Incase we still have enough EXP to lvl up again, recursivly call this same function
        }
    }
}
