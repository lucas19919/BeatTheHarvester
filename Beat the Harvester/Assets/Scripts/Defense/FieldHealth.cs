using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldHealth : MonoBehaviour
{
    public float Health = 100;

    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
