using TMPro;
using UnityEngine;

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

        // IF there are any Enemies in the scene destroy them
        GameObject[] Enemies_in_Sceen = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in Enemies_in_Sceen)
        {
            Destroy(Enemy);
        }

        // Reseting player data to default values
        //moveSpeed = 5f;
        //player_data.MaxHP = 100;
        //player_data.current_HP = player_data.MaxHP;
        //player_data.DMG = 1;
        //player_data.EXP_to_next_lvl = 5f;
        //player_data.current_EXP = 0;
        //player_data.current_lvl = 1;
        //player_data.upgrades_Chosen = 1;
        //player_data.score = 0;
        //player_data.transform.position = Vector3.zero; // resetting player position

        FindAnyObjectByType<Camera>().gameObject.transform.position = new Vector3(0, 0, -10); // Also reset Camera Position

        // IF there are any EXP orbs in the scene destroy them
        GameObject[] EXP_in_Sceen = GameObject.FindGameObjectsWithTag("EXP");
        foreach (GameObject EXP_ORB in EXP_in_Sceen)
        {
            Destroy(EXP_ORB);
        }
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

    public void LvL_UP_Choice()
    {
        Debug.Log("Choice was chosen");

        LvL_Up_Menu.SetActive(false);
        GameManager.singleton.gamePaused = false;
    }
}
