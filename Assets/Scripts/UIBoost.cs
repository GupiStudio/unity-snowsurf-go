using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoost : MonoBehaviour
{
    [SerializeField] private Slider boostBar;
    [SerializeField] FloatVariable playerBoost;

    void Update()
    {
        boostBar.value = playerBoost.Value/10;
    }
}
