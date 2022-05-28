using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRandomColors : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] renderers;

    private void Awake() {
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].color = RandomColor.Generate();
        }
    }
}
