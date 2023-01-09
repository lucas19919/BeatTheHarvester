using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Transform field;
    [SerializeField] MoneyManager moneyManager;

    CannonBehavior Behavior;
    FieldHealth fieldHealth;
    EnemySteering steering;

    Rigidbody2D rb;

    public float Health = 100f;
    float speed = 1f;
    float damage = 10;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        steering = GetComponent<EnemySteering>();
        Rush();
    }

    private void Update()
    {
        if (Health <= 0)
        {
            moneyManager.balPlus(10);
            Destroy(this.gameObject);
        }

    }
    public void Rush()
    {
        StopCoroutine(CombatDefense());
        rb.velocity = Vector3.zero;
        rb.velocity = (field.position - this.transform.position).normalized * speed;
        steering.Aim(field.position);
    }

    public void Track(Vector3 PreyPos)
    {
        rb.velocity = Vector3.zero;
        
        Vector2 dir = PreyPos - this.transform.position;
        rb.velocity = dir.normalized * speed;
    }

    IEnumerator CombatDefense()
    {
        while (Behavior.Health > 0)
        {
            Behavior.Health -= damage;

            if (Behavior.Health <= 0)
                Rush();

            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator CombatField()
    {
        while (fieldHealth.Health > 0)
        {
            fieldHealth.Health -= damage;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Cows") || !collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = Vector3.zero;
            if (collision.gameObject.CompareTag("Defense"))
            {
                Behavior = collision.gameObject.GetComponent<CannonBehavior>();
                StartCoroutine(CombatDefense());
            }

            if (collision.gameObject.CompareTag("Field"))
            {
                fieldHealth = collision.gameObject.GetComponent<FieldHealth>();
                StartCoroutine(CombatField());
            }
        }
    }
}
