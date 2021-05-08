using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathExplosion;
    [SerializeField] private ParticleSystem hitSparks;
    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private int pointsOnKill;
    [SerializeField] private int pointsOnHit;
    [SerializeField] private float HP;

    private GameObject spawnAtRuntime;
    private bool isAlive = true;
    private ScoreBoard sb;

    private void Start()
    {
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        sb = FindObjectOfType<ScoreBoard>();
        spawnAtRuntime = GameObject.FindWithTag("spawnAtRuntime");
    }
    private void OnParticleCollision(GameObject other)
    {
        ProccessDamage(other);
        ProccessFX(hitSparks);
        ProccessScore(pointsOnHit);
        if (isAlive && HP <= 0)
        {
            PerishLikeADog();
        }
    }

    private void PerishLikeADog()
    {
        isAlive = false;
        ProccessScore(pointsOnKill);
        ProccessFX(deathExplosion,deathSFX);
        Destroy(this.gameObject);
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

    private void ProccessFX(ParticleSystem particles, AudioSource audio)
    {
        ParticleSystem spawnedExplosion =
            Instantiate(particles, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedExplosion.transform.parent = spawnAtRuntime.transform;
        AudioSource spawnedAudioSource =
    Instantiate(audio, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedAudioSource.transform.parent = spawnAtRuntime.transform;
    }
    private void ProccessFX(ParticleSystem particles)
    {
        ParticleSystem spawnedExplosion =
            Instantiate(particles, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedExplosion.transform.parent = spawnAtRuntime.transform;

    }
    private void ProccessFX(AudioSource audio)
    {
        AudioSource spawnedAudioSource =
    Instantiate(audio, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedAudioSource.transform.parent = spawnAtRuntime.transform;
    }

    private void ProccessScore(int points)
    {
        sb.IncreaseScore(points);
        sb.UpdateUiScore();
    }
}
