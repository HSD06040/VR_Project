using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;

    private void Update()
    {
        player.transform.position = spawnPoint.position;         
    }
}
