using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    [SerializeField] AudioClip soundtrack;
    public void Back()
    {
        AudioSource music;
        music = FindObjectOfType<AudioSource>();
        music.clip = soundtrack;
        music.Play();
        SceneManager.UnloadSceneAsync("StoneGame");
        Time.timeScale = 1;
    }
}
