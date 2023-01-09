using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlace : MonoBehaviour
{
    [SerializeField] Transform defense;
    [SerializeField] Camera cam;
    [SerializeField] MoneyManager balance;

    public bool toggleMode = false;

    public void Toggle()
    {
        toggleMode = !toggleMode;
    }

    public void Update()
    {
        if (balance.bankBal() >= 10)
            if (toggleMode)
                if (Input.GetMouseButtonDown(1))
                {
                    Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x,cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

                    Instantiate(defense, pos, Quaternion.Euler(0, 0, 0));

                    balance.balMinus(10);
                }
    }
}
