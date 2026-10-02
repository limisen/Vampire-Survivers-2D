using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton; // Self Reference

    // Data:
    [Header("Data")]
    [SerializeField] public bool gamePaused = true;

    [Header("GameMenu(s)")]
    [SerializeField] public GameMenu gameMenu;

    #region Player Data
    [Header("Player Data")]
    [SerializeField] public float Player_MoveSpeed = 15f;
    [Space]
    [SerializeField] public float Player_MaxHP = 10;
    [SerializeField] public float Player_current_HP = 0;
    [SerializeField] public float Player_HP_regen = 0.025f;
    [Space]
    [Space]
    [SerializeField] public float Player_current_lvl = 0;
    [SerializeField] public float current_EXP = 0;
    [SerializeField] public float EXP_to_next_lvl = 5f;
    [Space]
    [Space]
    [SerializeField] public int score;
    #endregion

    #region Weapon Data
    [Header("Weapon Data")]
    [SerializeField] public bool Magic_Missile_Unlocked = false;
    [SerializeField] public GameObject Magic_Missile_objRef;
    [SerializeField] public float Missile_DMG = 5;
    [SerializeField] public float Missile_MoveSpeed = 10;
    [SerializeField] public float amount_to_spawn = 1;
    [SerializeField] public float time_between_launch = 2;
    [Space]
    [Space]
    [SerializeField] public bool Aura_Unlocked = false;
    [SerializeField] public GameObject Aura_objRef;
    [SerializeField] public float Aura_DMG = 5;
    [SerializeField] public float radius = 5;
    [Space]
    [Space]
    [SerializeField] public bool Chain_Lightning_Unlocked = false;
    [SerializeField] public GameObject Chain_Lightning_objRef;
    [SerializeField] public float Chain_Lightning_DMG = 5;
    [SerializeField] public int amount_to_chain = 1;
    [SerializeField] public float time_between_lightning = 2;
    #endregion

    #region Enemy Data
    [Header("Enemy Data")]
    [SerializeField] public float Enemy_moveSpeed = 5f;
    [Space]
    [Space]
    [SerializeField] public float Enemy_MaxHP = 10;
    [SerializeField] public float Enemy_currentHP;
    [Space]
    [Space]
    [SerializeField] public int Enemy_DMG = 3;
    [Space]
    [Space]
    [SerializeField] public int EXP_to_Drop = 1;
    [SerializeField] GameObject EXP_Prefab;
    [Space]
    [Space]
    [SerializeField] public int score_to_give = 1;
    #endregion

    #region Game State Data
    [Header("Game State Data")]
    [SerializeField] GameStateDriver gameStateDriver;
    #endregion

    private void Awake()
    {
        #region Make(ing) GameManager a singleton
        if (singleton != null)
        {
            Destroy(this);
            return;
        }

        singleton = this;
        #endregion
    }

    private void Start()
    {
        Player_current_HP = Player_MaxHP;

    }

    private void Update()
    {

        if (Player_current_HP <= 0)
        {
            if (gamePaused == false)
            {
                Debug.Log("Player Died");
            }
            gamePaused = true;
            gameMenu.Player_UI.SetActive(false);

            gameMenu.GameOver_Menu.SetActive(true);
        }

        gameMenu.Player_Score_UI.text = "Score: " + score.ToString();

        On_level_up();

        #region Weapon Active state change check and corresponding logic
        // IF weapon is unlocked turn the corresponding weapon GameObject ON or OFF
        if (Magic_Missile_Unlocked == true)
        {
            Magic_Missile_objRef.SetActive(true);
        }
        else if (Magic_Missile_Unlocked == false)
        {
            Magic_Missile_objRef.SetActive(false);
        }

        if (Aura_Unlocked == true)
        {
            Aura_objRef.SetActive(true);
        }
        else if (Aura_Unlocked == false)
        {
            Aura_objRef.SetActive(false);
        }

        if (Chain_Lightning_Unlocked == true)
        {
            Chain_Lightning_objRef.SetActive(true);
        }
        else if (Chain_Lightning_Unlocked == false)
        {
            Chain_Lightning_objRef.SetActive(false);
        }
        #endregion

        if (Player_current_HP < Player_MaxHP && gamePaused == false)
        {
            Player_current_HP += Player_HP_regen * Time.deltaTime;
        }
        gameMenu.HP_slider.value = Player_current_HP;

    }

    public void On_level_up()
    {
        if (current_EXP >= EXP_to_next_lvl)
        {
            gameMenu.LvL_Up_Menu.SetActive(true);
            gamePaused = true;
        }
        else
        {
            gameMenu.EXP_slider.value = current_EXP;
            gameMenu.EXP_slider.maxValue = EXP_to_next_lvl;
        }
    }
}