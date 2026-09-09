using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public void StartPressed() 
    {
        gameObject.SetActive(false);
        Debug.Log("Start Pressed");

        Player.SetActive(true);
    }
    public void SettingsPressed()
    {
        Debug.Log("Settings Pressed");
    }
    public void QuitPressed()
    {
        Debug.Log("Quit Pressed");
    }
}
