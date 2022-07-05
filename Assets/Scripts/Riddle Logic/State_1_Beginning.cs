using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fulcrum.ExtensionMethods;

public class State_1_Beginning : State
{
    [SerializeField] private State state_2;
    private bool state_1_finished = false;
    [SerializeField] GameObject[] togglableObject;

    public override State RunCurrentState()
    {
        if (state_1_finished == true)
        {
            return state_2;
        }
        else
        {
            return this;
        }
    }

    public void PlayerCloseToShade()
    {
        state_1_finished = true;
    }

    private void Start()
    {
        togglableObject.ToggleGameObjectArray(false);
    }
}
