/*-------------------------------------------------------
Creator: Philipp Petry
Project: Fulcrum
Last change: 22-06-2022
Topic: Shoots Raycast from Hand that gets all Scrolling relevant values from the object
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Raycast : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 direction;
    private  GameObject targetObject;

    public bool isGrabbed;
    public SkinnedMeshRenderer targetRenderer;
    public Material targetMaterial;

    [SerializeField] LayerMask layerMask;

    [HideInInspector]
    public bool _rayCastHit;

    void Start()
    {
        //direction = new Vector3(0, -90, 0);
        direction = Vector3.forward;
    }

    void Update()
    {
        origin = transform.position;
        direction = Vector3.forward;

        RaycastHit hit;
        if (Physics.Raycast(origin, transform.TransformDirection(direction), out hit, 100f, layerMask))
        {
            targetObject = hit.transform.gameObject;
            targetObject.TryGetComponent(out TearInteractable targetInteractable);
            Debug.Log("Object Found: " + targetObject.name);
            isGrabbed = targetInteractable.isGrabbed;
            if (isGrabbed)
            {
                targetRenderer = targetObject.GetComponent<SkinnedMeshRenderer>();
                targetMaterial = targetRenderer.sharedMaterial;
                Debug.Log("Grab Successful ");
            }

            Debug.Log("Raycast Hit");
            //Debug.Log(hit.point);
            _rayCastHit = true;
            Debug.DrawRay(origin, transform.TransformDirection(direction) * hit.distance, Color.red);
        }
        else
        {
            _rayCastHit = false;
            Debug.DrawRay(origin, transform.TransformDirection(direction) * 100f, Color.blue);
        }

    }
}
