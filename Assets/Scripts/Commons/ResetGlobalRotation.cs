using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGlobalRotation : MonoBehaviour
{
    void Start() {
        transform.rotation = Quaternion.identity;
    }
}
