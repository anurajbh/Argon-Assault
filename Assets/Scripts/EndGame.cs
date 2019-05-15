using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    Scene CurrentScene;
    int sceneIndex;
    AudioSource aud;
    bool won = false;
    private void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene();
        sceneIndex = CurrentScene.buildIndex;
        aud = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        won = true;
        
    }
    private void Update()
    {
        if(won)
        {
            PlayVictory();
            Invoke("WinTheGame", 2f);
        }
    }

    private void WinTheGame()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    private void PlayVictory()
    {
        if (!aud.isPlaying)
        {
            aud.Play();
        }
    }
}
