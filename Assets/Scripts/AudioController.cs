using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaFundo;
    public AudioClip[] musicaFundo;

    void Start()
    {
        AudioClip musicaFundaDessaFase = musicaFundo[0];
        audioSourceMusicaFundo.clip = musicaFundaDessaFase;
        audioSourceMusicaFundo.loop = true;
        audioSourceMusicaFundo.Play();
    }

    void Update()
    {
        
    }
}
