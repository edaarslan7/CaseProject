using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleHelper : MonoBehaviour
{
    [SerializeField] ObjectPool clickParticlePool;

    public void OnClicked(Transform transform)
    {
        Particle particle = clickParticlePool.GetItem() as Particle;
        particle.SetActiveWithPosition(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
}
