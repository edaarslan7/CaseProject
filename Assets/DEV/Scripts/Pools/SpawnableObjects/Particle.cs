using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : SpawnableObject
{
    [SerializeField] ParticleSystem particle;

    public void Play()
    {
        particle.Play();
    }
    private void OnDisable()
    {
        Dismiss();
    }
}
