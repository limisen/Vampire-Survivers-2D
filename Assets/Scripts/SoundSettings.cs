using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    float Volume_Value;
    Slider Volume_Slider;

    private void Start()
    {
        Volume_Value = PlayerPrefs.GetFloat("Master_Volume", 0.33f);
        AudioListener.volume = Volume_Value;

        Volume_Slider = GetComponent<Slider>();
        Volume_Slider.value = Volume_Value;
    }

    public void ChangeVolume(float newVolumeValue)
    {
        Volume_Value = Volume_Slider.value;
        newVolumeValue = Volume_Value;

        Debug.Log("Master_Volume Changed...");

        PlayerPrefs.SetFloat("Master_Volume", newVolumeValue);
        AudioListener.volume = PlayerPrefs.GetFloat("Master_Volume");

        Debug.Log("New Value: " + newVolumeValue);
    }
}
