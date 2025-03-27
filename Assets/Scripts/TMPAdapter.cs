using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPAdapter : MonoBehaviour
{
    private TextMeshProUGUI textField;

    public void Awake()
    {
        textField = base.GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string val)
    {
        textField.text = val;
    }
}
