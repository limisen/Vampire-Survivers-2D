using TMPro;
using UnityEditor;
using UnityEngine;

public class Video_Settings : MonoBehaviour
{
    TMP_Dropdown dropdown;
    int value;
    private void Start()
    {
        // get playerPrefs current settings
        value = PlayerPrefs.GetInt("Video_Settings", 0);

        // get other necessary stuff
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(delegate { OnValueChange(dropdown); });

        // Make sure The Player's Video Settings are applied
        if (value == 0)
        {
            //Set the applications video settings to be Fullscreen
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else if (value == 1)
        {
            //Set the applications video settings to be windowed
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void OnValueChange(TMP_Dropdown dropdown)
    {
        Debug.Log("Video Settings Changed...");

        Debug.Log("Value: " + dropdown.value);

        if (dropdown.value == 0)
        {
            //Set the applications video settings to be Fullscreen
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            PlayerPrefs.SetInt("Video_Settings", 0);
            Debug.Log("...To Fullscreen");
        }
        else if (dropdown.value == 1)
        {
            //Set the applications video settings to be windowed
            Screen.fullScreenMode = FullScreenMode.Windowed;
            PlayerPrefs.SetInt("Video_Settings", 1);
            Debug.Log("...To Windowed");
        }
    }
}
