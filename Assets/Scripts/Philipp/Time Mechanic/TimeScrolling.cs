/*-------------------------------------------------------
Creator: Philipp Petry
Project: Fulcrum
Last change: 01-07-2022
Topic: Adjusts Blendshape Value according to the controller rotation
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScrolling : MonoBehaviour
{
    public SkinnedMeshRenderer _tearRenderer;
    public float _blendValue;
    public float _controllerRotZ;
    public Raycast _rayCastScript;

    private GameObject controllerRight;

    void Start()
    {
        controllerRight = this.gameObject;
    }

    void Update()
    {
        _controllerRotZ = controllerRight.transform.rotation.z * 100;
        _blendValue = _controllerRotZ;
        

        if (_rayCastScript._rayCastHit == true && _rayCastScript.isGrabbed == true)
        {
            _tearRenderer = _rayCastScript.targetRenderer;

            if (_blendValue >= 0)
            {
                _tearRenderer.SetBlendShapeWeight(1, _blendValue);
                _rayCastScript.targetMaterial.SetFloat("_BlendToPast", _blendValue/100);
            }
            else if (_blendValue < 0)
            {
                _tearRenderer.SetBlendShapeWeight(0, _blendValue - 2 * _blendValue);
                _rayCastScript.targetMaterial.SetFloat("_BlendToFuture", (_blendValue - 2 * _blendValue) / 100);
            }
        }

        // Debug.Log("Blend to Past Value: " + _rayCastScript.targetMaterial.GetFloat("_BlendToPast").ToString());
        // Debug.Log("Blend to Past Future: " + _rayCastScript.targetMaterial.GetFloat("_BlendToFuture").ToString());
        // Debug.Log("controller rotation z = " + _blendValue / 100);
    }
}
