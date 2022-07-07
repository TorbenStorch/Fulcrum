/*-------------------------------------------------------
Creator: Philipp Petry
Project: Fulcrum
Last change: 17-06-2022
Topic: Adds rotating magic sigils to the game object. 
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Rotation : MonoBehaviour
{
    [SerializeField] GameObject magicOut;
    [SerializeField] GameObject magicMid;
    [SerializeField] GameObject magicInner;
    [SerializeField] Vector3 rot;
    [SerializeField] float rotationSpeed;
    [SerializeField] float fadeSpeed;

    [SerializeField] Material matOut, matMid, matInner;

    [SerializeField] TimeScrolling scrollingScript;
    private float rotationDefault;
    private float fastRotationSpeed;
    private bool startFadingIn, startFadingOut;

    void Start()
    {
        rotationDefault = rotationSpeed;
        fastRotationSpeed = rotationSpeed * 3;
        materialSetup();
    }

    void Update()
    {
        if (scrollingScript._rayCastScript._rayCastHit == true && scrollingScript._rayCastScript.isGrabbed == true)
        {
            startFadingIn = true;
            startFadingOut = false;
            rotationSpeed = scrollingScript._controllerRotZ;
        }
        else
        {
            startFadingOut = true;
            startFadingIn = false;
            rotationSpeed = rotationDefault;
        }

        magicOut.transform.Rotate(rot * rotationSpeed * Time.deltaTime);
        magicMid.transform.Rotate(rot * - rotationSpeed * Time.deltaTime);
        magicInner.transform.Rotate(rot * rotationSpeed * 3 * Time.deltaTime);        

        #region alpha fade
        Color color = matOut.color;

        if (startFadingIn && !startFadingOut)
        {
            if (color.a < 1)
            {
                color.a += fadeSpeed;
                matOut.color = color;
                matMid.color = color;
                matInner.color = color;
                //Debug.Log(color.a);
            }
            else
            {
                startFadingIn = false;
            }
        }

        if (startFadingOut && !startFadingIn)
        {
            if (color.a > 0.0f)
            {
                color.a -= fadeSpeed;
                matOut.color = color;
                matMid.color = color;
                matInner.color = color;
                //Debug.Log(color.a);
            }
            else
            {
                color.a = 0;
                matOut.color = color;
                matMid.color = color;
                matInner.color = color;
                startFadingOut = false;
            }
        }
        #endregion

    }


    private void materialSetup()
    {
        //matOut = gameObject.transform.GetChild(0).GetComponent<Material>();
        //matMid = gameObject.transform.GetChild(1).GetComponent<Material>();
        //matInner = gameObject.transform.GetChild(2).GetComponent<Material>();

        Color colorOut = matOut.color;
        colorOut.a = 0f;
        matOut.color = colorOut;

        Color colorMid = matMid.color;
        colorMid.a = 0f;
        matMid.color = colorMid;

        Color colorInner = matInner.color;
        colorInner.a = 0f;
        matInner.color = colorInner;
    }
}
