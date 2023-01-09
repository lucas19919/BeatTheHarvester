using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject HarvesterEnemy;
    [SerializeField] MoneyManager moneyManager;
    
    int waveNumber = 0;
    Quaternion Rotation = Quaternion.Euler(0, 0, 0);
    public static bool waveActive = false;

    private void Update()
    {
        if (1 == GameObject.FindGameObjectsWithTag("Enemy").Length)
            waveActive = false;

        if (waveNumber == 3 && GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
        {
            SceneManager.LoadScene("WinScreen");
        }

    }

    public void Spawn()
    {
        waveNumber++;
        
        if (waveNumber == 1 && waveActive == false)
        {
            waveActive = true;
            
            Vector3[] wave1 =
            {
                new Vector3(0, 12, 0),
                new Vector3(0, -12, 0),
                new Vector3(12, 0, 0),
                new Vector3(-12, 0, 0),
            };

            foreach (Vector3 wave in wave1)
            {
                Instantiate(HarvesterEnemy, wave, Rotation);
            }
        }
        
        if (waveNumber == 2 && waveActive == false)
        {
            waveActive = true;

            Vector3[] wave2 =
            {
                new Vector3(0, 12, 0),
                new Vector3(0, -12, 0),
                new Vector3(12, 0, 0),
                new Vector3(-12, 0, 0),
                new Vector3(6, 6, 0),
                new Vector3(6, -6, 0),
                new Vector3(-6, 6, 0),
                new Vector3(-6, -6, 0),
            };

            foreach (Vector3 wave in wave2)
            {
                Instantiate(HarvesterEnemy, wave, Rotation);
            }
        }

        if (waveNumber == 3 && waveActive == false)
        {
            waveActive = true;

            Vector3[] wave3 =
            {
                new Vector3(0, 12, 0),
                new Vector3(0, -12, 0),
                new Vector3(12, 0, 0),
                new Vector3(-12, 0, 0),
                new Vector3(6, 6, 0),
                new Vector3(6, -6, 0),
                new Vector3(-6, 6, 0),
                new Vector3(-6, -6, 0),
                new Vector3(8, 0, 0),
                new Vector3(0, 8, 0),
                new Vector3(-8, 0, 0),
                new Vector3(0, -8, 0),
            };

            foreach (Vector3 wave in wave3)
            {
                Instantiate(HarvesterEnemy, wave, Rotation);
            }

            moneyManager.balPlus(40);
        }
    }
}
