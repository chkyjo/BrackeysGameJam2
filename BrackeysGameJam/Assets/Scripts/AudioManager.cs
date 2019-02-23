using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour{

    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Awake(){
        //GetComponent<AudioSource>().clip = audioClips[0];
        //GetComponent<AudioSource>().Play();
    }

    public AudioClip GetAudio(ClipIds clipId) {
        return audioClips[(int)clipId];
    }

}

public enum ClipIds {
    ItemPickUp
}
