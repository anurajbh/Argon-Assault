using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    Scene scene;
    int sceneIndex;
	// Use this for initialization
	void Start ()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadTheNextLevel(sceneIndex);
        }
	}

    private void LoadTheNextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
