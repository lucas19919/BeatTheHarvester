using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegister : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float currentDistance = 100f;
    float Distance;

    CannonAim aimbot;
    CannonBehavior cannonB;
    EnemyBehavior enemyBehavior;

    private void Start()
    {
        aimbot = GetComponent<CannonAim>();
        cannonB = GetComponent<CannonBehavior>();
    }

    private void TargetEnemy()
    {
        foreach (GameObject enemy in Enemies)
        {
            Distance = new Vector3(
                this.transform.position.x - enemy.transform.position.x,
                this.transform.position.y - enemy.transform.position.y,
                this.transform.position.z - enemy.transform.position.z
            ).magnitude;

            if (Distance < currentDistance)
            {
                aimbot.Aim(enemy.transform.position);
                cannonB.Fire(enemy);
                Distance = currentDistance;
            }
            if (enemy.GetComponent<EnemyBehavior>().Health <= 0)
            {
                currentDistance = 100;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
            TargetEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemies.Remove(collision.gameObject);
        currentDistance = 100;
    }

}
