using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}
