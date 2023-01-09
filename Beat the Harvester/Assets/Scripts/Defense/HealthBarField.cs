using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarField : MonoBehaviour
{
    [SerializeField] GameObject Char;
    [SerializeField] Slider slider;

    FieldHealth behavior;

    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        behavior = Char.GetComponent<FieldHealth>();
    }

    private void Update()
    {
        if (behavior != null) 
            slider.value = behavior.Health;
        else
            slider.value = 1000;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}