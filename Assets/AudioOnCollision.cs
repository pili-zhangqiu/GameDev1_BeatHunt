using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(sound, 1f);
    }
}
