using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathExplosion;
    [SerializeField] private Transform parent;
    [SerializeField] private int points;

    private bool isAlive = true;
    private ScoreBoard sb;
    private void Start()
    {
        sb = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (isAlive)
        {
            isAlive = false;
            ProccessScore();
            ProccessParticleEffects();
            Destroy(this.gameObject);
        }
    }

    private void ProccessParticleEffects()
    {
        ParticleSystem spawnedExplosion =
            Instantiate(deathExplosion, this.GetComponent<Transform>().position, Quaternion.identity);
        spawnedExplosion.transform.parent = parent;
    }

    private void ProccessScore()
    {
        sb.IncreaseScore(points);
        sb.PrintScoreToConsole();
    }
}
