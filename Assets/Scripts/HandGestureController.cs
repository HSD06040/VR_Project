using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR;

public class HandGestureController : MonoBehaviour
{
    public GameObject targetObject;
    public Transform handAttachPoint;

    [SerializeField] private MeshFilter markerFilter;
    [SerializeField] private Mesh boxMesh;
    [SerializeField] private Mesh sphereMesh;

    private bool isBox = false;
    private bool isAttached = false;

    private void Update()
    {
        if(isAttached)
        {
            targetObject.transform.position = handAttachPoint.position;
            targetObject.transform.rotation = handAttachPoint.rotation;
        }
    }

    public void MeshChanged()
    {
        if(isBox)
        {
            markerFilter.mesh = sphereMesh;        
            isBox = false;
        }
        else
        {
            markerFilter.mesh = boxMesh;
            isBox = true;
        }
    }

    public void OnGrabGesture()
    {        
        targetObject.transform.SetParent(handAttachPoint);
        targetObject.SetActive(true);
        isAttached = true;
    }

    public void OnReleaseGesture()
    {
        if (!isAttached) return;

        targetObject.transform.SetParent(null);
        targetObject.SetActive(false);
        isAttached = false;
    }
}
