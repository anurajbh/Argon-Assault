using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Restart : MonoBehaviour
{
    private void Update()
    {
        if(CrossPlatformInputManager.GetButton("Submit"))
        {
            SceneManager.LoadScene(0);
        }
        if(CrossPlatformInputManager.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
}
