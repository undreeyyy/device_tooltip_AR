using UnityEngine;  // Required for Unity

//create a class that rotates the object on drag relative to the scrrn width
public class RotateObjectHorizontallyVertically : MonoBehaviour
{
    // Variables
    public float speed = 1f;  // Rotation speed
    private float _screenWidth;  // Width of the screen
    private float _screenHeight;  // Height of the screen
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
        // Check if the user uses the mouse or touch input
        if (Input.touchCount == 1)
        {
            if (Input.GetMouseButton(0))
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

                    //screen width and height totals to 360 degrees of rotation
                    float rotationX = deltaX * speed * 360 / _screenWidth;
                    float rotationY = deltaY * speed * 360 / _screenHeight;

                    // Rotate the object
                    transform.rotation = Quaternion.Euler(_startRotation.eulerAngles.x + rotationY, _startRotation.eulerAngles.y + rotationX, 0);

                    //set the last mouse position to the current mouse position
                    _lastMouseX = _mouseX;
                    _lastMouseY = _mouseY;

                }

            }
        }
    }
}