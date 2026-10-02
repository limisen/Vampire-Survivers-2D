using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] public GameObject Start_Menu;
    [SerializeField] public GameObject Settings_Menu;
    [SerializeField] public GameObject GameOver_Menu;
    [SerializeField] public GameObject Pause_Menu;
    [SerializeField] public GameObject LvL_Up_Menu;

    // Arguably Player UI too so I'll keep it here in the middle
    [SerializeField] public GameObject Inventory;

    [Header("Player UI")]
    [SerializeField] public GameObject Player_UI;
    [SerializeField] public UnityEngine.UI.Slider EXP_slider;
    [SerializeField] public UnityEngine.UI.Slider HP_slider;
    [SerializeField] public TextMeshProUGUI Player_Score_UI;

    [Header("EXP")]
    [SerializeField] GameObject EXP_Prefab;

    private void Start()
    {
        EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        HP_slider.maxValue = GameManager.singleton.Player_MaxHP;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel") && Pause_Menu.activeSelf == false)
        {
            Pause_Menu.SetActive(true);
            Player_UI.SetActive(false);
            GameManager.singleton.gamePaused = true;

            Debug.Log("Pause button was pressed");
        }
        else if (Input.GetButtonDown("Cancel") && Pause_Menu.activeSelf == true)
        {
            Pause_Menu.SetActive(false);
            Player_UI.SetActive(true);
            GameManager.singleton.gamePaused = false;

            Debug.Log("Pause button was pressed");
        }

        // If there's any meny active make sure the game is paused
        if (Start_Menu.activeSelf || Settings_Menu.activeSelf || GameOver_Menu.activeSelf || Pause_Menu.activeSelf || LvL_Up_Menu.activeSelf)
        {
            GameManager.singleton.gamePaused = true;
        }
    }


    public void StartPressed()
    {
        GameManager.singleton.gamePaused = false;
        Start_Menu.SetActive(false);
        Debug.Log("Start Pressed");

        Player_UI.SetActive(true);
    }
    public void RestartPressed()
    {
        GameManager.singleton.gamePaused = false;
        GameOver_Menu.SetActive(false);
        LvL_Up_Menu.SetActive(false);
        Pause_Menu.SetActive(false);
        Settings_Menu.SetActive(false);
        Start_Menu.SetActive(false);

        Debug.Log("Restart Pressed");

        Player_UI.SetActive(true);

        #region Destroying spawned GameObjects
        // IF there are any Enemies left in the scene destroy them
        GameObject[] Enemies_in_Scene = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in Enemies_in_Scene)
        {
            Destroy(Enemy);
        }

        // IF there are any EXP orbs left in the scene destroy them
        GameObject[] EXP_in_Scene = GameObject.FindGameObjectsWithTag("EXP");
        foreach (GameObject EXP_ORB in EXP_in_Scene)
        {
            Destroy(EXP_ORB);
        }

        // IF there are any Missiles left in the scene destroy them
        GameObject[] Missiles_in_Scene = GameObject.FindGameObjectsWithTag("Missile");
        foreach (GameObject Missile in Missiles_in_Scene)
        {
            Destroy(Missile);
        }
        #endregion

        #region Player Data Reset
        // Reseting player data to default values
        GameManager.singleton.Player_MoveSpeed= 15f;

        GameManager.singleton.Player_MaxHP = 10;
        GameManager.singleton.Player_current_HP = GameManager.singleton.Player_MaxHP;

        GameManager.singleton.EXP_to_next_lvl = 5f;
        GameManager.singleton.current_EXP = 0;
        GameManager.singleton.Player_current_lvl = 0;

        GameManager.singleton.Magic_Missile_Unlocked = false;
        GameManager.singleton.Aura_Unlocked = false;
        GameManager.singleton.Chain_Lightning_Unlocked = false;

        GameManager.singleton.score = 0;

        GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.zero; // resetting player position

        // reseting the weapon data
        GameManager.singleton.Missile_DMG = 5;
        GameManager.singleton.Missile_MoveSpeed = 10;
        GameManager.singleton.amount_to_spawn = 1;
        GameManager.singleton.time_between_launch = 2;

        GameManager.singleton.Aura_DMG = 5;
        GameManager.singleton.amount_to_chain = 1;
        GameManager.singleton.time_between_lightning = 2;

        GameManager.singleton.Chain_Lightning_DMG = 5;
        GameManager.singleton.radius = 5;
        #endregion

        #region Updating UI values
        // Updating UI to reflect the reset
        EXP_slider.maxValue = GameManager.singleton.EXP_to_next_lvl;
        HP_slider.maxValue = GameManager.singleton.Player_MaxHP;
        HP_slider.value = GameManager.singleton.Player_current_HP;
        #endregion

        // Also reset Camera Position
        FindAnyObjectByType<Camera>().gameObject.transform.position = new Vector3(0, 0, -10);

        // Reset the amount the Spawner starts to spawn
        FindAnyObjectByType<EnemySpawner>().Enemies_to_spawn = 1;

        // Spawn the starting EXP orb (otherwise the player doesnt get the choice to LVL up and choose their starting weapon
        GameObject EXP_orb = Instantiate(EXP_Prefab, new Vector3(0, 4, 0), Quaternion.identity);
        // Then set the amount it should give
        EXP_orb.GetComponent<EXP_Pick_Up>().EXP_to_give = (int)GameManager.singleton.EXP_to_next_lvl;
    }
    public void ContinuePressed()
    {
        GameManager.singleton.gamePaused = false;
        Pause_Menu.SetActive(false);
        Player_UI.SetActive(true);
        Debug.Log("Continue Pressed");
    }
    public void SettingsPressed()
    {
        Debug.Log("Settings Pressed");
    }
    public void QuitPressed()
    {
        Debug.Log("Quit Pressed");
    }
    public void Close_LVL_Up_Menu()
    {
        GameManager.singleton.gamePaused = false;
        LvL_Up_Menu.SetActive(false);
        HP_slider.maxValue = GameManager.singleton.Player_MaxHP; // Just to make sure that if a upgrade increases MaxHP it increases the max slider's maxValue
    }
}
