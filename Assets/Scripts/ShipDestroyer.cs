using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject explosionEffect;
    //AudioSource aud;
    void Start()
    {
      //  aud = explosionEffect.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BlowUpShip()
    {
        explosionEffect.SetActive(true);
       // aud.Play();
    }
}
