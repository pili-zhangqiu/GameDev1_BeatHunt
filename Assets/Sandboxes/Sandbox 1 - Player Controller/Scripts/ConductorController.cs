using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorController : MonoBehaviour
{
    private float songBpm;                     // Song beats per minute. This is determined by the song you're trying to sync up to
    public static float secPerBeat;            // The number of seconds for each song beat

    public static float songPosition;          // Current song position, in seconds
    public static float songPositionInBeats;   // Current song position, in beats

    public float dspSongTime;           // How many seconds have passed since the song started

    public AudioSource musicSource;     // An AudioSource attached to this GameObject that will play the music.

    // ------------------------------- Start -------------------------------
    void Start()
    {
        // Define the beats per minute of the audiosource
        songBpm = 120;

        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // ------------------------------- Update -------------------------------
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        Debug.Log("Song started: " + songPosition + " seconds ago");

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        Debug.Log("Song started: " + songPositionInBeats + " beats ago");
        Debug.Log("--------------------------------------------");
    }
}
