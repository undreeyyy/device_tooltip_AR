using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerTrackingImage : MonoBehaviour
{
    //variables
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    [SerializeField] private GameObject[] aRModelsToAnchor;

    private Dictionary<string, GameObject> _aRModels = new Dictionary<string, GameObject>();
    private Dictionary<string, bool> _modelState = new Dictionary<string, bool>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var aRModel in aRModelsToAnchor)
        {
            GameObject newModel = Instantiate(aRModel, Vector3.zero, Quaternion.identity);
            newModel.name = aRModel.name;
            _aRModels.Add(aRModel.name, newModel);
            newModel.SetActive(false);
            _modelState.Add(aRModel.name, false);
        }
    }

    //on enable
    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageFound;
    }

    //on disable
    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageFound;
    }

    //on image found
    private void OnImageFound(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            SpawnARModel(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                SpawnARModel(trackedImage);
            }
            else if (trackedImage.trackingState == TrackingState.Limited)
            {
                // HideARModel(trackedImage);
            }
        }
    }

    //spawn the model

    private void SpawnARModel(ARTrackedImage trackedImage)
    {
        bool isActive = _modelState[trackedImage.referenceImage.name];
        if (!isActive)
        {
            GameObject aRModel = _aRModels[trackedImage.referenceImage.name];
            aRModel.transform.position = trackedImage.transform.position;
            //rotates the model to face the camera
            aRModel.transform.rotation = Camera.main.transform.rotation;
            aRModel.SetActive(true);
            _modelState[trackedImage.referenceImage.name] = true;
        }
        else
        {
            GameObject aRModel = _aRModels[trackedImage.referenceImage.name];
            aRModel.transform.position = trackedImage.transform.position;
        }
    }

    //hide the model
    private void HideARModel(ARTrackedImage trackedImage)
    {
        bool isActive = _modelState[trackedImage.referenceImage.name];
        if (isActive)
        {
            GameObject aRModel = _aRModels[trackedImage.referenceImage.name];
            aRModel.SetActive(false);
            _modelState[trackedImage.referenceImage.name] = false;
        }
    }

}
