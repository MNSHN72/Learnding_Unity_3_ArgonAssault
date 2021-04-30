using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem spawnedExplosion =
            Instantiate(deathExplosion,this.GetComponent<Transform>().position,Quaternion.identity);
        spawnedExplosion.transform.parent = parent;


        Destroy(this.gameObject);
    }
}
