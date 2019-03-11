using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float loadDelay = 5f;
   
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        InitializeDeathSequence();
    }

    private void InitializeDeathSequence()
    {
        SendMessage("KillPlayer");
        SendMessage("BlowUpShip");
        Invoke("reloadLevel", loadDelay);
        
    }

    private void reloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
