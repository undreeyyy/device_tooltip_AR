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

            //zoom in when pinching in and zooms out when pinching out on the object but only to a certain point where the objects edges do not go past the camera when i rotate the object
            transform.localScale += Vector3.one * deltaMagnitudeDiff * 0.00001f;


            //gets the maximum scale of the object where the object just fits the camera * 2
            float maxScale = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 2;

            //get the minScale of the object by using the original size of the object
            float minScale = Mathf.Min(transform.localScale.x, transform.localScale.y, transform.localScale.z);

            //using the distance the maximum and minimum scale of the object is set so that the object does not go past the camera when i rotate the object
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, minScale, maxScale), Mathf.Clamp(transform.localScale.y, minScale, maxScale), Mathf.Clamp(transform.localScale.z, minScale, maxScale));
        }
        //if the user is not pinching
        else
        {
            //get the scroll wheel input
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //zoom in and out on the object
            transform.localScale += Vector3.one * scroll * 0.001f;
        }
    }
}
