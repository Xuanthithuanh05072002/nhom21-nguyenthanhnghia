using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicnen : MonoBehaviour
{
    AudioSource[] Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponentsInChildren<AudioSource>();
        Audio[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOffMusicBackground()
    {
        if (Audio[0].isPlaying)
            Audio[0].Pause();
        else Audio[0].Play();
    }
}
