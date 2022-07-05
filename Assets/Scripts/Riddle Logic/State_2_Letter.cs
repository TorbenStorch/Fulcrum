using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fulcrum.ExtensionMethods;

public class State_2_Letter : State
{
    //Global Pos Flag
    private bool letterPosCorrect;

    //Reference Letter + Time bool

    public override State RunCurrentState()
    {
        //if Letter.TimeBool == true && Global Pos Flag == true, then return next State_3_Medicine

        return this;
    }

    //Function to be called when Letter enters Socket Interactor
    //public void LetterInCorrectPosition(bool letterPosFlag)
    //{
    //    //Set Global Pos Flag to letterPosFlag
    //
    //}

    public override void ObjectInCorrectPosition(bool objectInPosition)
    {
        //Set Global Pos Flag to letterPosFlag
    }

    void Update()
    {

        //Check if Letter.TimeBool == true && Global Pos Flag == true
    }
}
