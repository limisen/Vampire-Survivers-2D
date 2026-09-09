using UnityEngine;
using UnityEngine.UIElements;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;

    [SerializeField] public int MaxHP = 10;
    [SerializeField] public int currentHP;


    [SerializeField] public float EXP_to_next_lvl = 5f;
    [SerializeField] public float current_EXP;
    [SerializeField] public float current_lvl;


    private void Start()
    {
        currentHP = MaxHP;
    }

    public void IF_level_UP()
    {
        if (current_EXP == EXP_to_next_lvl)
        {
            current_lvl++; // increase current lvl
            EXP_to_next_lvl *= current_lvl; // raise the EXP needed to levelUP
            current_EXP = 0; // Reset the progress towards the next lvl

            Slider slider = GetComponent<Slider>();
            
            slider.highValue = EXP_to_next_lvl; // Set the max value to the new value
            slider.value = 0; // Reset the visual progress towards the next lvl
        }
    }
}
