using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] GameObject Char;
    [SerializeField] Slider slider;    
    
    EnemyBehavior behavior;

    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        behavior = Char.GetComponent<EnemyBehavior>();
    }

    private void Update()
    {
        if (behavior != null)
            slider.value = behavior.Health;
        else
            slider.value = 100;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
