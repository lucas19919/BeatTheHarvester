using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    [SerializeField] Transform FieldPos;

    Vector3 CannonPos;
    Vector3 DirectionV;
    float degrees;
    Quaternion Rotation;
    
    private void Start()
    {
        if (this.gameObject.name != "CornCannon")
            GetComponent<DefensePlace>().enabled = false;
        
        CannonPos = this.transform.position;

        DirectionV = FieldPos.position - CannonPos;

        degrees = Mathf.Acos(DirectionV.y / Mathf.Abs(DirectionV.magnitude)) * Mathf.Rad2Deg;
        Rotation = Quaternion.Euler(0, 0, FieldPos.position.x > CannonPos.x ? 180 - degrees : degrees + 180);

        this.transform.rotation = Rotation;
    }

    public void Aim(Vector3 EnemyPos)
    {
        DirectionV = EnemyPos - CannonPos;

        degrees = Mathf.Acos(DirectionV.y / Mathf.Abs(DirectionV.magnitude)) * Mathf.Rad2Deg;
        Rotation = Quaternion.Euler(0, 0, EnemyPos.x > CannonPos.x ? 360 - degrees : degrees);

        this.transform.rotation = Rotation;
    }
}
