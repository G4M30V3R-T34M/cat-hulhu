using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CameraSettingsScriptable cameraSettings;

    private bool followPlayer;
    private Camera camera;

    private Vector3 screenBounds;

    void Start()
    {
        camera = Camera.main;
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
        Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 x = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        print(x);
        Vector3 direction = mousePosition - this.transform.position;
        if (player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(direction * cameraSettings.speed * Time.deltaTime);
        }
    }
}
