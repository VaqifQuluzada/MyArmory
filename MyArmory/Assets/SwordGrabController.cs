using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwordGrabController : XRGrabInteractable
{
    protected override void Awake()
    {
        selectEntered.AddListener(onGrabSword);

        selectExited.AddListener(onReleaseSword);

        base.Awake();
    }

    private void onGrabSword(SelectEnterEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<HandAnimationController>().GrabHandAnimation(true);
    }

    private void onReleaseSword(SelectExitEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<HandAnimationController>().GrabHandAnimation(false);
    }
  
}
