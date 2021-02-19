using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticlesCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if(!other.CompareTag("Player 1") && !other.CompareTag("Player 2"))
        {
            AudioManager.Instance.PlayParticleColliding();
        }
    }
}
