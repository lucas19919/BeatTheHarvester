using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySteering : MonoBehaviour
{
    [SerializeField] Transform FieldPos;

    Vector3 currentPos;
    Vector3 DirectionV;
    float degrees;
    Quaternion Rotation;
    
    private void Start()
    {
        Aim(FieldPos.position);
    }

    public void Aim(Vector3 EnemyPos)
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        DirectionV = (EnemyPos - this.transform.position).normalized;

        Debug.DrawLine(EnemyPos, this.transform.position, Color.red, 200f);

        degrees = Mathf.Acos(DirectionV.y / Mathf.Abs(DirectionV.magnitude)) * Mathf.Rad2Deg;
        Rotation = Quaternion.Euler(0, 0, EnemyPos.x > this.transform.position.x ? 360 - degrees : degrees);

        this.transform.rotation = Rotation;
    }
}
