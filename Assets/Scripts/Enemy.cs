using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathfx;
    [SerializeField] Transform parent;
    [SerializeField] int pointsPerHit = 10;//damage score for each enemy
    ScoreBoard sb;
    void Start()
    {
        AddBoxCollider();
        sb = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        sb.ScoreHit(pointsPerHit);
        GameObject fx = Instantiate(deathfx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
