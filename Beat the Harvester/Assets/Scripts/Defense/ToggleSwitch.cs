using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] DefensePlace defensePlace;
    public void Untoggle()
    {
        defensePlace.toggleMode = false;
    }
}
