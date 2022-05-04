using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchButton : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
 public void SesiCikar()
    {
        if (audioSource)
            audioSource.Play();
    }
}
