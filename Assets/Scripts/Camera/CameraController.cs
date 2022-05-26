using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CameraSettingsScriptable cameraSettings;

    private bool followPlayer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        followPlayer = Input.GetKey(KeyCode.LeftShift) ? false : true;

        if (followPlayer)
        {
            CameraFollowPlayer();
        } else
        {
            LookAhead();
        }
    }

    private void CameraFollowPlayer()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    private void LookAhead()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 direction = mousePosition - this.transform.position;
        if (player.GetComponentInChildren<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(direction * cameraSettings.speed * Time.deltaTime);
        }
    }
}
