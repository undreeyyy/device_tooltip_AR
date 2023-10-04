using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ResizeInRealLife : MonoBehaviour
{
    //scales the object to match its real life size in unity units given its real life max length in millimeters
    //relative to the size of the tracked ar image target
    //the object will be scaled to the size of the ar image target

    //variables
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    //the real life size of the object in millimeters
    public float realLifeSize = 1f;
    //the real life size of the ar image target in millimeters
    public float realLifeTargetSize = 1f;
    //the scale of the object relative to the ar image target
    public float scale = 1f;


    //start function
    void Start()
    {
        //get the real life size of the object in millimeters
        float realLifeSize = 0.162f;
        //get the real life size of the ar image target in millimeters
        float realLifeTargetSize = aRTrackedImageManager.trackedImagePrefab.GetComponent<ResizeInRealLife>().scale;
        //get the scale of the object relative to the ar image target
        float scale = realLifeSize / realLifeTargetSize;
        //scale the object to the size of the ar image target
        transform.localScale = Vector3.one * scale;
    }

}
