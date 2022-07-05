using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fulcrum.ExtensionMethods;

public class State_3_Medicine : State
{
    //Global Pos Flag
    private bool medicinePosCorrect;

    //Reference Medicine + Time bool

    public override State RunCurrentState()
    {
        //if Medicine.TimeBool == true && Global Pos Flag == true, then return next State_4_Victory

        return this;
    }

    //Function to be called when Letter enters Socket Interactor
    //public void MedicineInCorrectPosition(bool medicinePosFlag)
    //{
    //    //Set Global Pos Flag to medicinePosFlag
    //
    //}

    public override void ObjectInCorrectPosition(bool objectInPosition)
    {
        //Set Global Pos Flag to letterPosFlag
    }

    void Update()
    {

        //Check if Medicine.TimeBool == true && Global Pos Flag == true
    }
}
