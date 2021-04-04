using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QualityDropDown : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown dropdown;

    void Awake()
    {

        string[] qualityNames = QualitySettings.names;

        dropdown.options.Clear();

        dropdown.AddOptions(qualityNames.ToList());

        dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
    }
}
