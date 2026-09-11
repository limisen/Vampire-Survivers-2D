using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyParent;

    public bool gamePaused = true;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] public GameObject LvL_Up_Menu;

    [SerializeField] GameObject Player_UI;
    [SerializeField] public UnityEngine.UI.Slider EXP_slider;
    [SerializeField] public UnityEngine.UI.Slider HP_slider;


    public void StartPressed()
    {
        gamePaused = false;
        MainMenu.SetActive(false);
        Debug.Log("Start Pressed");

        Player.SetActive(true);
        Player_UI.SetActive(true);
        EnemyParent.SetActive(true);
    }

    public void ContinuePressed()
    {
        gamePaused = false;
        PauseMenu.SetActive(false);
        HP_slider.gameObject.SetActive(true);
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
        {
            PauseMenu.SetActive(true);
            HP_slider.gameObject.SetActive(false);
            gamePaused = true;

            Debug.Log("Pause button was pressed");
        }
        else if (Input.GetButtonDown("Cancel") && PauseMenu.activeSelf == true)
        {
            PauseMenu.SetActive(false);
            HP_slider.gameObject.SetActive(true);
            gamePaused = false;

            Debug.Log("Pause button was pressed");
        }

        if (Player.GetComponentInParent<PlayerData>().upgrades_Chosen != Player.GetComponentInParent<PlayerData>().current_lvl)
        {
            LvL_Up_Menu.SetActive(true);
            HP_slider.gameObject.SetActive(false);
            gamePaused = true;
        }
    }
}
