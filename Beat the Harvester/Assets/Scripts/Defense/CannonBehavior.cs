using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    private EnemyBehavior Behavior;
    private EnemyRegister Register;

    public float Health = 30f;
    float damage = 10;

    private void Start()
    {
        Register = this.GetComponent<EnemyRegister>();
    }

    private void Update()
    {
        if (Health <= 0)
            Destroy(this.gameObject);
    }

    public void Fire(GameObject Target)
    {
        Behavior = Target.GetComponent<EnemyBehavior>();

        StartCoroutine(Combat());
    }

    IEnumerator Combat()
    {
        while (Behavior.Health > 0)
        {
            Behavior.Health -= damage;

            if (Behavior.Health <= 0)
            {
                StopCoroutine(Combat());
            }

            yield return new WaitForSeconds(1);
        }
    }
}


