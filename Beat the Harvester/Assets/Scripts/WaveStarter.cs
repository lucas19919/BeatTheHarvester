using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    [SerializeField] Transform enemy;

    WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
    }
    public void startWave()
    {
        enemy.gameObject.SetActive(true);
        waveSpawner.Spawn();
        enemy.gameObject.SetActive(false);
    }
}
