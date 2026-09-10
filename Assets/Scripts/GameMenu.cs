using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyParent;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenu;

    [SerializeField] GameObject Player_UI;
    [SerializeField] public UnityEngine.UI.Slider EXP_slider;
    [SerializeField] public UnityEngine.UI.Slider HP_slider;

    public void StartPressed()
    {
        MainMenu.SetActive(false);
        Debug.Log("Start Pressed");

        Player.SetActive(true);
        Player_UI.SetActive(true);
        EnemyParent.SetActive(true);
    }

    public void ContinuePressed()
    {
        PauseMenu.SetActive(false);
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

    private void Update()
    {

        if (Input.GetButtonDown("Cancel") && PauseMenu.activeSelf == false)
        {
            PauseMenu.SetActive(true);

            Debug.Log("Pause button was pressed");
        }
        else if (Input.GetButtonDown("Cancel") && PauseMenu.activeSelf == true)
        {
            PauseMenu.SetActive(false);

            Debug.Log("Pause button was pressed");
        }
    }
}
