using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //create a start function to zoom in and out on the object

    }

    // Update is called once per frame
    void Update()
    {
        //Updates per frame to enlarge or shrink the object by pinching or by scrolling the mouse wheel

        //if the user is pinching
        if (Input.touchCount == 2)
        {
            //get the first touch
            Touch touchZero = Input.GetTouch(0);
            //get the second touch
            Touch touchOne = Input.GetTouch(1);

            //get the position of the first touch
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            //get the position of the second touch
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //get the magnitude of the distance between the touches
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            //get the magnitude of the distance between the touches
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //get the difference between the two magnitudes
            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            //zoom in when pinching in and zooms out when pinching out on the object
            transform.localScale += Vector3.one * deltaMagnitudeDiff * 0.01f;
        }
        //if the user is not pinching
        else
        {
            //get the scroll wheel input
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //zoom in and out on the object
            transform.localScale += Vector3.one * scroll * 1f;
        }
        //Gets the maximum length from the center of the object to the edge of the object
        float max = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        //zooms in only to a certain point where the objects edges do not go past the camera when i rotate the object
        //if the maximum length of the object is greater than 1
        if (max > 1)
        {
            //set the maximum length of the object to 1
            transform.localScale = Vector3.one;
        }
        //zooms out only to a certain point where the objects edges do not go past the camera when i rotate the object
        //if the maximum length of the object is less than 0.1
        else if (max < 0.1f)
        {
            //set the maximum length of the object to 0.1
            transform.localScale = Vector3.one * 0.1f;
        }
    }
}
