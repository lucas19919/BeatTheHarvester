using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    static float balance = 50f;

    Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        txt.text = "Gold: " + balance.ToString();
    }

    public float bankBal()
    {
        return balance;
    }

    public void balPlus(float income)
    {
        balance += income;
    }

    public void balMinus(float loss)
    {
        balance -= loss;
    }
}
