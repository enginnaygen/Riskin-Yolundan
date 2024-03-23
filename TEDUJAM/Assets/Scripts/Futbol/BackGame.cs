using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGame : MonoBehaviour
{
    [SerializeField] AudioClip soundtrack;

    public void Backk()
    {
        
        AudioSource music;
        music = FindObjectOfType<AudioSource>();
        music.clip = soundtrack;
        music.Play();
        SceneManager.UnloadSceneAsync("Football");

    }
}
