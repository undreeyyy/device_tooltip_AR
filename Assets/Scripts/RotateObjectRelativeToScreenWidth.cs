using UnityEngine;  // Required for Unity

//create a class that rotates the object on drag relative to the scrrn width
public class RotateObjectRelativeToScreenWidth : MonoBehaviour
{
    // Variables
    public float speed = 10f;  // Rotation speed
    private float _screenWidth;  // Width of the screen
    private Vector3 _mouseReference;  // Position of the mouse on the screen
    private Quaternion _startRotation;  // Rotation of the object
    private float _lastMouseX;  // Mouse X last frame
    private float _mouseX;  // Mouse X this frame

    void Start()
    {
        // Get the screen width
        _screenWidth = Screen.width;
    }

    // Update is called once per frame relative to the screen width
    void Update()
    {
        // Check if the mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Set the mouse reference
            _mouseReference = Input.mousePosition;
            // Set the rotation reference
            _startRotation = transform.rotation;
        }
        // stores the last mouse position so the object wont rotate back to its original position  
        else if (Input.GetMouseButtonUp(0))
        {
            _lastMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            // Get the mouse position
            _mouseX = Input.mousePosition.x;
            // Calculate the rotation
            float rotation = (_mouseX - _mouseReference.x) * speed;
            // Rotate the object
            transform.rotation = Quaternion.Euler(_startRotation.eulerAngles.x, _startRotation.eulerAngles.y - rotation, _startRotation.eulerAngles.z);
        }
    }
}