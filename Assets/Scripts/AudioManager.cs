using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audiSource;
    [SerializeField] List<AudioClip> sounds = new List<AudioClip>();

    [SerializeField] StateMachine stateMachine;

    [SerializeField] string currentState;

    private void Awake()
    {
        audiSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audiSource.volume = PlayerPrefs.GetFloat("Master_Volume", 0.33f);
        audiSource.generator = sounds[0]; // main menu song
    }

    private void Update()
    {
        audiSource.volume = PlayerPrefs.GetFloat("Master_Volume", 0.33f);

        currentState = stateMachine.CurrentState.GetType().Name;

        if (stateMachine.CurrentState.GetType().Name == "MainMenuState")
        {
            audiSource.generator = sounds[0]; // main menu song
            if (audiSource.isPlaying == false)
            {
                audiSource.Play();
            }
        }
        else if (stateMachine.CurrentState.GetType().Name == "PlayingSate" || stateMachine.CurrentState.GetType().Name == "IdleState" || stateMachine.CurrentState.GetType().Name == "MovingState")
        {
            audiSource.generator = sounds[1]; // main menu song
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
