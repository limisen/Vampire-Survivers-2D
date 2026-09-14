using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyParent;

    public bool gamePaused = true;

    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject GameOverMenu;
    [SerializeField] public GameObject PauseMenu;
    [SerializeField] public GameObject LvL_Up_Menu;

    [SerializeField] public GameObject Player_UI;
    [SerializeField] public UnityEngine.UI.Slider EXP_slider;
    [SerializeField] public UnityEngine.UI.Slider HP_slider;
    [SerializeField] public TextMeshProUGUI Player_Score_UI;


    public void StartPressed()
    {
        gamePaused = false;
        MainMenu.SetActive(false);
        Debug.Log("Start Pressed");

        Player.SetActive(true);
        Player_UI.SetActive(true);
        EnemyParent.SetActive(true);
    }
    public void RestartPressed()
    {
        gamePaused = false;
        GameOverMenu.SetActive(false);
        Debug.Log("Restart Pressed");

        Player.SetActive(true);
        Player_UI.SetActive(true);
        EnemyParent.SetActive(true);

        // IF there are any Enemies in the scene destroy them
        GameObject[] Enemies_in_Sceen = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in Enemies_in_Sceen)
        {
            Destroy(Enemy);
        }

        // Reseting player data to default values
        PlayerData player_data = Player.GetComponentInParent<PlayerData>();
        player_data.moveSpeed = 5f;
        player_data.MaxHP = 100;
        player_data.current_HP = player_data.MaxHP;
        player_data.DMG = 1;
        player_data.EXP_to_next_lvl = 5f;
        player_data.current_EXP = 0;
        player_data.current_lvl = 1;
        player_data.upgrades_Chosen = 1;
        player_data.score = 0;
        Player.transform.position = Vector3.zero; // resetting player position

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
        gamePaused = false;
        PauseMenu.SetActive(false);
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
        gamePaused = false;

        Player.GetComponentInParent<PlayerData>().upgrades_Chosen += 1;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel") && PauseMenu.activeSelf == false)
        // Add New input system pause key pressed (logi) here
        {
            PauseMenu.SetActive(true);
            Player_UI.SetActive(false);
            gamePaused = true;

            Debug.Log("Pause button was pressed");
        }
        else if (Input.GetButtonDown("Cancel") && PauseMenu.activeSelf == true)
        // Add New input system pause key pressed (logi) here
        {
            PauseMenu.SetActive(false);
            Player_UI.SetActive(true);
            gamePaused = false;

            Debug.Log("Pause button was pressed");
        }

        if (Player.GetComponentInParent<PlayerData>().upgrades_Chosen != Player.GetComponentInParent<PlayerData>().current_lvl)
        {
            LvL_Up_Menu.SetActive(true);
            Player_UI.SetActive(true);
            gamePaused = true;
        }
    }
}
