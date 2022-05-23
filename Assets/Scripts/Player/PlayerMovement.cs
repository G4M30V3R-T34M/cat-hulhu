using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSettingsScriptable playerSettings;

    Animator animator;
    Camera mainCamera;

    private void Awake() {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Move();
    }

    private void Move() {
        float frontMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");

        if (frontMovement == 0 && sideMovement == 0) {
            animator.SetFloat("frontMovement", 0);
            animator.SetFloat("sideMovement", 0);
        } else {
            float theta = Mathf.Atan2(sideMovement, frontMovement) * Mathf.Rad2Deg;

            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(GetMousePosition());
            theta += TanAngleDeg(mousePosition);

            animator.SetFloat("frontMovement", Mathf.Sin(theta * Mathf.Deg2Rad));
            animator.SetFloat("sideMovement", -1 * Mathf.Cos(theta * Mathf.Deg2Rad));
        }

        /*
        animator.SetFloat("frontMovement", frontMovement);
        animator.SetFloat("sideMovement", sideMovement);
        */

        if (frontMovement != 0f || sideMovement != 0) {
            Vector3 movement = new Vector3(sideMovement, frontMovement, 0);
            Translate(movement);
        }

    }

    private Vector3 GetMousePosition() {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    private float TanAngleDeg(Vector3 position) {
        return Mathf.Atan2((position.y - transform.position.y), (position.x - transform.position.x)) * Mathf.Rad2Deg;
    }

    private void Translate(Vector3 direction)
    {
        transform.Translate(direction * playerSettings.speed * Time.deltaTime, Space.World);
    }
}
