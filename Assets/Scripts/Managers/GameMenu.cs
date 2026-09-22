using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] public GameObject Start_Menu;
    [SerializeField] public GameObject Settings_Menu;
    [SerializeField] public GameObject GameOver_Menu;
    [SerializeField] public GameObject Pause_Menu;
    [SerializeField] public GameObject LvL_Up_Menu;

    [SerializeField] public GameObject Inventory;

    [SerializeField] public GameObject Player_UI;
    [SerializeField] public UnityEngine.UI.Slider EXP_slider;
    [SerializeField] public UnityEngine.UI.Slider HP_slider;
    [SerializeField] public TextMeshProUGUI Player_Score_UI;

    private PlayerData Player;

    private void Awake()
    {
        Player = FindAnyObjectByType<PlayerData>();
    }

    private void Start()
    {
        EXP_slider.maxValue = Player.EXP_to_next_lvl;
        HP_slider.maxValue = Player.MaxHP;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel") && Pause_Menu.activeSelf == false)
        // Add New input system pause key pressed (logi) here
        {
            Pause_Menu.SetActive(true);
            Player_UI.SetActive(false);
            GameManager.singleton.gamePaused = true;

            Debug.Log("Pause button was pressed");
        }
        else if (Input.GetButtonDown("Cancel") && Pause_Menu.activeSelf == true)
        // Add New input system pause key pressed (logi) here
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

        // Keep promting the player to choose another upgrade untill the nr of upgrades matches their lvl
        //if (Player.GetComponentInParent<PlayerData>().upgrades_Chosen != Player.GetComponentInParent<PlayerData>().current_lvl)
        //{
        //    LvL_Up_Menu.SetActive(true);
        //    Player_UI.SetActive(true);
        //    gamePaused = true;
        //}
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
        Debug.Log("Restart Pressed");

        Player_UI.SetActive(true);

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

        // Reseting player data to default values
        Player.moveSpeed = 20f;
        Player.MaxHP = 10;
        Player.current_HP = Player.MaxHP;
        Player.EXP_to_next_lvl = 5f;
        Player.current_EXP = 0;
        Player.current_lvl = 1;
        Player.score = 0;
        Player.transform.position = Vector3.zero; // resetting player position

        // Updating UI to reflect the reset
        EXP_slider.maxValue = Player.EXP_to_next_lvl;
        HP_slider.maxValue = Player.MaxHP;

        // Also reset Camera Position
        FindAnyObjectByType<Camera>().gameObject.transform.position = new Vector3(0, 0, -10);

        FindAnyObjectByType<EnemySpawner>().Enemies_to_spawn = 2;
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
    }
}
