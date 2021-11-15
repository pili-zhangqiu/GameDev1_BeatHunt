using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorController : MonoBehaviour
{
    public float songBpm;                     // Song beats per minute. This is determined by the song you're trying to sync up to
    public static float secPerBeat;            // The number of seconds for each song beat

    public static float songPosition;          // Current song position, in seconds
    public static float songPositionInBeats;   // Current song position, in beats

    public float dspSongTime;           // How many seconds have passed since the song started

    public AudioSource musicSource;     // An AudioSource attached to this GameObject that will play the music.

    //The offset to the first beat of the song in seconds
    public float firstBeatOffset = 0.25f;

    // ------------------------------- Start -------------------------------
    void Start()
    {
        // Define the beats per minute of the audiosource
        songBpm = 160;

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
    void FixedUpdate()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime + firstBeatOffset);
        //Debug.Log("Song position: " + songPosition + " seconds");

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        //Debug.Log("Song position: " + songPositionInBeats + " beats");
        //Debug.Log("--------------------------------------------");
    }
}
