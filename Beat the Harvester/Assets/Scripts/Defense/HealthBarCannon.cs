using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCannon : MonoBehaviour
{
    [SerializeField] GameObject Char;
    [SerializeField] Slider slider;    
    
    CannonBehavior behavior;

    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        behavior = Char.GetComponent<CannonBehavior>();
    }

    private void Update()
    {
        if (behavior != null)
            slider.value = behavior.Health;
        else
            slider.value = 50;

        fill.color = gradient.Evaluate(behavior.Health);
    }
}
