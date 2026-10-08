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
