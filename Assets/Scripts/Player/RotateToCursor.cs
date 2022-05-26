using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(GetMousePosition());
        transform.eulerAngles = new Vector3(0, 0, TanAngleDeg(mousePosition));
    }

    private Vector3 GetMousePosition()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - mainCamera.transform.position.z);
    }

     /// <summary>
     /// Return the angle in degrees whose Tan is y/x of a Vector3
     /// </summary>
     /// <returns> Tangent in dregrees </returns>
     /// <param name="position">Vector3 of which we want to make the tangent</param>
    private float TanAngleDeg(Vector3 position)
    {
        return Mathf.Atan2((position.y - transform.position.y), (position.x - transform.position.x)) * Mathf.Rad2Deg;
    }
}
