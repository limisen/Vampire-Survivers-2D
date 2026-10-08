using TMPro;
using UnityEngine;

public class MainMenu_HighScore_Display : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private string ScoreToWrite;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.GetInt("Higscore") > GameManager.singleton.score)
        {
            ScoreToWrite = PlayerPrefs.GetInt("Higscore").ToString();
        } 
        else if (PlayerPrefs.GetInt("Higscore") < GameManager.singleton.score)
        {
            ScoreToWrite = GameManager.singleton.score.ToString();
            PlayerPrefs.SetInt("Higscore", GameManager.singleton.score);
        }

        if (PlayerPrefs.GetInt("Higscore") == 0 && GameManager.singleton.score == 0)
        {
            ScoreToWrite = "0";
        }
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Higscore") > GameManager.singleton.score)
        {
            ScoreToWrite = PlayerPrefs.GetInt("Higscore").ToString();
        }
        else if (PlayerPrefs.GetInt("Higscore") < GameManager.singleton.score)
        {
            ScoreToWrite = GameManager.singleton.score.ToString();
            PlayerPrefs.SetInt("Higscore", GameManager.singleton.score);
        }

        textComponent.text = ("High Score: " + ScoreToWrite);
    }
}
