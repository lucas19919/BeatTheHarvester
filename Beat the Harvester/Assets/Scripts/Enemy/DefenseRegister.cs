using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseRegister : MonoBehaviour
{
    private List<GameObject> Defenses = new List<GameObject>();
    float currentDistance = 100f;

    [SerializeField] EnemyBehavior behavior;
    [SerializeField] EnemySteering enemySteering;

    private void FixedUpdate()
    {
        foreach (GameObject defense in Defenses)
        {
            Vector2 Distance = this.transform.position - defense.transform.position;
            if (defense.CompareTag("Field"))
            {
                behavior.Rush();
                currentDistance = 0;
                return;
            }

            if (Distance.magnitude < currentDistance)
            {
                behavior.Track(defense.transform.position);
                enemySteering.Aim(defense.transform.position);
            }

            currentDistance = Distance.magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Defense") || collision.CompareTag("Field"))
            Defenses.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Defenses.Remove(collision.gameObject);
    }

}
