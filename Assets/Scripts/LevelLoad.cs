using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

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
		if(CrossPlatformInputManager.GetButton("Submit"))
        {
            LoadTheNextLevel(sceneIndex);
        }
        if (CrossPlatformInputManager.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }

    private void LoadTheNextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
