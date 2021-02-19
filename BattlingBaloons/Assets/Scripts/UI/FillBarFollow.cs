using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBarFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float yOffset;

    private void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z);
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z);
    }
}
