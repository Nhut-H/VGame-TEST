using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource adSource;
    public AudioClip backGroundSound;
    // Start is called before the first frame update
    void Start()
    {
        adSource = GetComponent<AudioSource>();
        StartCoroutine(PlayThisSound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PlayThisSound()
    {
        yield return new WaitForSeconds(0.5f);
        adSource.PlayOneShot(backGroundSound, 0.5f);
        
    }
}
