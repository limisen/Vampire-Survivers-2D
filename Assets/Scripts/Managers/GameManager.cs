using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton; // Self Reference

    // Data:
    [Header("Data")]
    [SerializeField] public bool gamePaused = true;

    #region Player Data
    [Header("Player Data")]
    [SerializeField] public float Player_MoveSpeed = 10f;
    [Space]
    [Space]
    [SerializeField] public float Player_MaxHP = 10;
    [SerializeField] public float Player_current_HP = 0;
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
    [SerializeField] public float Missile_DMG = 5;
    [SerializeField] public float Missile_MoveSpeed = 10;
    [SerializeField] public float amount_to_spawn = 1;
    [SerializeField] public float time_between_launch = 2;

    [SerializeField] public bool Chain_Lightning_Unlocked = false;
    [SerializeField] public float Chain_Lightning_DMG = 5;
    [SerializeField] public float amount_to_chain = 1;
    [SerializeField] public float time_between_lightning = 2;

    [SerializeField] public bool Aura_Unlocked = false;
    [SerializeField] public float Aura_DMG = 5;
    [SerializeField] public float radius = 5;
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


    private void Awake()
    {
        if (singleton != null)
        {
            Destroy(this);
            return;
        }

        singleton = this;
    }

    private void Start()
    {
        // set the state to be the state we should be in at the launch of the game.
        
    }

    private void Update()
    {
        
    }
}