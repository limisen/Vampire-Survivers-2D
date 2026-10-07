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
        // Make sure they are applied

        // get other necessary stuff
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
        value = dropdown.value;

        dropdown.onValueChanged.AddListener(delegate { OnValueChange(dropdown); });
    }

    public void OnValueChange(TMP_Dropdown dropdown)
    {
        Debug.Log("Video Settings Changed...");

        Debug.Log("Value: " + dropdown.value);

        if (dropdown.value == 0)
        {
            //Set the applications video settings to be Fullscreen
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            PlayerSettings.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("...To Fullscreen");
        }
        else if (dropdown.value == 1)
        {
            //Set the applications video settings to be windowed
            Screen.fullScreenMode = FullScreenMode.Windowed;
            PlayerSettings.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("...To Windowed");
        }
    }
}
