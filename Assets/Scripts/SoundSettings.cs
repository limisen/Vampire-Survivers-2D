using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public float Volume_Value;
    Slider Volume_Slider;

    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        Volume_Value = PlayerPrefs.GetFloat("Master_Volume", 0.33f);
        audioSource = FindAnyObjectByType<AudioSource>();
        audioSource.volume = Volume_Value;

        Volume_Slider = GetComponent<Slider>();
        Volume_Slider.value = Volume_Value;
    }

    public void ChangeVolume(float newVolumeValue)
    {
        Debug.Log("Master_Volume Changed...");

        PlayerPrefs.SetFloat("Master_Volume", newVolumeValue);
        audioSource.volume = PlayerPrefs.GetFloat("Master_Volume");

        Debug.Log("New Value: " + newVolumeValue);
        Volume_Value = newVolumeValue;
    }
}
