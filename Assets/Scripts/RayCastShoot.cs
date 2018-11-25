using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{

    // Use this for initialization

    //gun stats
    [SerializeField] int phaserDamage = 1;
    [SerializeField] float fireRate = .25f;
    [SerializeField] float weaponRange = 50f;
    [SerializeField] float hitForce = 100f;

    //transform to indicate starting point
    [SerializeField] Transform phaserEnd;

    [SerializeField] Camera fpsCam;

    //private AudioSource phaserAudio;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    private LineRenderer phaserLine;
    private float nextFire = 1f;

    void Start()
    {
        phaserLine = GetComponent<LineRenderer>();
        //phaserAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            phaserLine.SetPosition(0, phaserEnd.localPosition);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward *12, out hit, weaponRange))
            {
                phaserLine.SetPosition(1, hit.point);
            }
            else
            {
                phaserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * 12 * weaponRange));
            }
        }
    }
    private IEnumerator ShotEffect()
    {
       // phaserAudio.Play();
        phaserLine.enabled = true;
        yield return shotDuration;
        phaserLine.enabled = false;
    }
}
