using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //rotates the object when the user drags their finger across the screen
    //variables
    public float speed = 1f;  // Rotation speed
    private float _screenWidth;  // Width of the screen
    private float _screenHeight;  // Height of the screen
    private Vector3 _mouseReference;  // Position of the mouse on the screen
    private Quaternion _objectRotation;  // Rotation of the object
    private float _lastMouseX;  // Mouse X last frame
    private float _lastMouseY;  // Mouse Y last frame
    private float _mouseX;  // Mouse X this frame

    private float _mouseY;  // Mouse Y this frame

    void Start()
    {
        // Get the screen width
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        //rotates the image to face the camera based on the cameras rotation
        transform.rotation = Camera.main.transform.rotation;
        //stores the rotation of the object
        _objectRotation = transform.rotation;
        // Set the mouse reference
        _mouseReference = Input.mousePosition;
    }

    //updates per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //sets the rotation of the object to the last rotation of the object
                transform.rotation = _objectRotation;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //set the last mouse position to the current mouse position
                _lastMouseX = _mouseX;
                _lastMouseY = _mouseY;
            }
            else
            {
                //get the mouse position on the screen
                _mouseX = Input.mousePosition.x;
                _mouseY = Input.mousePosition.y;

                //if the mouse position is not the same as the last frame
                if (_lastMouseX != _mouseX || _lastMouseY != _mouseY)
                {
                    //get the difference between the mouse position and the last frame
                    float deltaX = _mouseX - _lastMouseX;
                    float deltaY = _mouseY - _lastMouseY;

                    //rotate the object on the x axis
                    transform.Rotate(Vector3.up * deltaX * speed, Space.World);
                    //rotate the object on the y axis
                    transform.Rotate(Vector3.left * deltaY * speed, Space.World);

                    //set the last mouse position to the current mouse position
                    _lastMouseX = _mouseX;
                    _lastMouseY = _mouseY;

                    //stores the rotation of the object
                    _objectRotation = transform.rotation;
                }
            }
        }
    }
}
