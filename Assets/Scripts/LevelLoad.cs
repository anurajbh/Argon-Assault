using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    Scene scene;
    int sceneIndex;
    [SerializeField] AudioSource aud;
	// Use this for initialization
	void Start ()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DontDestroyOnLoad(gameObject);
		if(Input.GetKeyDown(KeyCode.Return))
        {
            aud.Stop();
            LoadTheNextLevel(sceneIndex);
        }
	}

    private void LoadTheNextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
