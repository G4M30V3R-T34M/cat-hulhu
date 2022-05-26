using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSettingsScriptable playerSettings;
    [SerializeField] Transform spriteTransform;

    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        Move();
    }

    private void Move() {
        float frontMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");

        if (frontMovement != 0f || sideMovement != 0) {
            Vector3 movement = new Vector3(sideMovement, frontMovement, 0);
            Translate(movement);
        }

        MovementAnimation(frontMovement, sideMovement);
    }

    private void MovementAnimation(float frontMovement, float sideMovement) {
        if (frontMovement == 0 && sideMovement == 0) { 
            animator.SetFloat("frontMovement", 0);
            animator.SetFloat("sideMovement", 0);
        } else {
            float theta = Mathf.Atan2(sideMovement, frontMovement) * Mathf.Rad2Deg;
            theta += spriteTransform.rotation.eulerAngles.z;

            animator.SetFloat("frontMovement", Mathf.Sin(theta * Mathf.Deg2Rad));
            animator.SetFloat("sideMovement", -1 * Mathf.Cos(theta * Mathf.Deg2Rad));
        }
    }

    private void Translate(Vector3 direction) {
        transform.Translate(direction * playerSettings.speed * Time.deltaTime, Space.World);
    }
}
