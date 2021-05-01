using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathExplosion;
    [SerializeField] private ParticleSystem hitSparks;
    [SerializeField] private Transform parent;
    [SerializeField] private int pointsOnKill;
    [SerializeField] private int pointsOnHit;
    [SerializeField] private float HP;

    private bool isAlive = true;
    private ScoreBoard sb;
    private void Start()
    {
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        sb = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProccessDamage(other);
        ProccessParticleEffects(hitSparks);
        ProccessScore(pointsOnHit);
        if (isAlive && HP <= 0)
        {
            isAlive = false;
            ProccessScore(pointsOnKill);
            ProccessParticleEffects(deathExplosion);
            Destroy(this.gameObject);
        }
    }

    private void ProccessDamage(GameObject attack)
    {
        if (attack.gameObject.tag == "LightAttack")
        {
            HP -= 1;
        }
        if (attack.gameObject.tag == "HeavyAttack")
        {
            HP -= 7;
        }
    }

    private void ProccessParticleEffects(ParticleSystem particles)
    {
        ParticleSystem spawnedExplosion =
            Instantiate(particles, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedExplosion.transform.parent = parent;
    }

    private void ProccessScore(int points)
    {
        sb.IncreaseScore(points);
        sb.UpdateUiScore();
    }
}
