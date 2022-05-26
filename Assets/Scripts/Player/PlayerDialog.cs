using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;
using TMPro;

public class PlayerDialog : Singleton<PlayerDialog>
{
    Animator animator;

    [SerializeField]
    TextMeshProUGUI text;

    protected override void Awake() {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public void ShowText(string dialog) {
        text.text = dialog;
        animator.SetTrigger("ShowDialog");
    }
}
