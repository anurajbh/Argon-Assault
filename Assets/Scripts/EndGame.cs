using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    Scene CurrentScene;
    int sceneIndex;
    private void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene();
        sceneIndex = CurrentScene.buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneIndex+1);
    }
}
