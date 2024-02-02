using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public void low()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void med()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void high()
    {
        QualitySettings.SetQualityLevel(2);
    }
}
