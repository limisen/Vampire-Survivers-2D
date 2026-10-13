using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audiSource;
    [SerializeField] public List<AudioClip> Music = new List<AudioClip>();
    [SerializeField] public List<AudioClip> SFX = new List<AudioClip>();

    [SerializeField] StateMachine stateMachine;

    [SerializeField] string currentState;

    private void Awake()
    {
        audiSource = GetComponent<AudioSource>();
        audiSource.volume = PlayerPrefs.GetFloat("Master_Volume", 0.33f);
    }

    private void Update()
    {
        audiSource.volume = PlayerPrefs.GetFloat("Master_Volume", 0.33f);

        currentState = stateMachine.CurrentState.GetType().Name;

        if (stateMachine.CurrentState.GetType().Name == "MainMenuState")
        {
            audiSource.generator = Music[0]; // main menu song
            if (audiSource.isPlaying == false)
            {
                audiSource.Play();
            }
        }
        else if (stateMachine.CurrentState.GetType().Name == "PlayingSate" || stateMachine.CurrentState.GetType().Name == "IdleState" || stateMachine.CurrentState.GetType().Name == "MovingState")
        {
            audiSource.generator = Music[1]; // main menu song
            if (audiSource.isPlaying == false)
            {
                audiSource.Play();
            }
        }
        else if (stateMachine.CurrentState.GetType().Name == "SettingsState")
        {
            if (audiSource.isPlaying == false)
            {
                audiSource.Play();
            }
        }
        else
        {
            audiSource.volume *= 0.3f;
        }
    }
}
