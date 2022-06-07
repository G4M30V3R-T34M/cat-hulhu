using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSizeLimit : MonoBehaviour
{
    [SerializeField] int limit;
    [SerializeField] TMP_InputField inputField;

    private void Start() {
        inputField.characterLimit = limit;
    }
}
