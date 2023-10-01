using UnityEngine;  // Required for Unity

//create a class that rotates the object on drag relative to the scrrn width
public class RotateObjectHorizontallyVertically : MonoBehaviour
{
    // Variables
    public float speed = 10f;  // Rotation speed
    private float _screenWidth;  // Width of the screen
    private float _screenHeight;  // Height of the screen
    private Vector3 _mouseReference;  // Position of the mouse on the screen
    private Quaternion _startRotation;  // Rotation of the object
    private float _lastMouseX;  // Mouse X last frame
    private float _lastMouseY;  // Mouse Y last frame
    private float _mouseX;  // Mouse X this frame
    private float _mouseY;  // Mouse Y this frame

    void Start()
    {
        // Get the screen width
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }


    // Update is called once per frame relative to the screen
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
            _lastMouseY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            // Get the mouse position
            _mouseX = Input.mousePosition.x;
            _mouseY = Input.mousePosition.y;
            // Calculate rotation based on the mouse position
            float rotationX = (_mouseX - _lastMouseX) * speed;
            float rotationY = (_mouseY - _lastMouseY) * speed;

            transform.rotation = _startRotation * Quaternion.Euler(_startRotation.eulerAngles.x + rotationY, _startRotation.eulerAngles.y - rotationX, _startRotation.eulerAngles.z);
        }
        
    }
}