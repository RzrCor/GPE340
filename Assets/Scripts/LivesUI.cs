using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesUI : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }
    // Changes health UI to display current health
    public void UpdateLivesDisplay(int Lives)
    {
        textComponent.text = "Lives = " + Lives;
    }
}
