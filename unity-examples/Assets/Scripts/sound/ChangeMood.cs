using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMood : MonoBehaviour
{
    public Sprite[] moodPortraits;
    public AudioClip[] uiSounds;
    public AudioClip startSound;
    public AudioClip endSound;
    private Image activePortrait;
    private AudioSource audioPlayer;

    void Start()
    {
        activePortrait = GetComponent<Image>();
        audioPlayer = GetComponent<AudioSource>();
    }

    public void ChangeToNewMood()
    {
        activePortrait.sprite = moodPortraits[Random.Range(0, moodPortraits.Length)];
        audioPlayer.PlayOneShot(uiSounds[Random.Range(0, uiSounds.Length)]);
    }
}
