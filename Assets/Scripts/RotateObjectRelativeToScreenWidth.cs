using UnityEngine;  // Required for Unity

//create a class that rotates the object on drag relative to the scrrn width
public class RotateObjectHorizontallyVertically : MonoBehaviour
{
    // Variables
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


    // Update is called once per frame relative to the screen
    void Update()
    {
        // Check if the user uses the mouse or touch input
        if (Input.touchCount == 1)
        {
            // Check if the mouse is pressed
            if (Input.GetMouseButtonDown(0))
            {
                //sets the rotation of the object to the last rotation of the object
                transform.rotation = _objectRotation;
            }
            // stores the last mouse position so the object wont rotate back to its original position  
            else if (Input.GetMouseButtonUp(0))
            {
                //set the last mouse position to the current mouse position
                _lastMouseX = _mouseX;
                _lastMouseY = _mouseY;
            }
            //rotates relative to the screen width (360 degrees) and screen height(180 degrees)
            else if (Input.GetMouseButton(0))
            {
                //get the mouse position on the screen
                _mouseX = Input.mousePosition.x;
                _mouseY = Input.mousePosition.y;

                //if the mouse position is not the same as the last frame
                if (_lastMouseX != _mouseX || _lastMouseY != _mouseY)
                {
                    //get the difference between the mouse position and the last frame
                    float deltaX = _lastMouseX - _mouseX;
                    float deltaY = _lastMouseY - _mouseY;

                    //screen width and height totals to 360 degrees of rotation
                    float rotationX = deltaX * speed * 360 / _screenWidth;
                    float rotationY = deltaY * speed * 180 / _screenHeight;

                    // Rotate the object
                    transform.rotation = Quaternion.Euler(_objectRotation.eulerAngles.x + rotationY, _objectRotation.eulerAngles.y + rotationX, 0);

                    //stores the rotation of the object
                    _objectRotation = transform.rotation;

                    //set the last mouse position to the current mouse position
                    _lastMouseX = _mouseX;
                    _lastMouseY = _mouseY;

                }

            }

        }
    }
}