using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedWeaponController : XRGrabInteractable
{
    //That is the grab points of weapon(Maybe there are more than 1 grab point)
    [SerializeField] private XRSimpleInteractable[] grabPoints;

    private XRBaseInteractor secondHandController;

    //When we rotate hand according to our second hand point, we need to save the initial rotation
    //of first hand to reset its normal rotation back when we release the weapon.
    private Quaternion firstHandInitialRotation;


    private void Start()
    {
        foreach(XRSimpleInteractable grabPoint in grabPoints)
        {
            grabPoint.selectEntered.AddListener(onPlayerGrabbedSecondPoint);

            grabPoint.selectExited.AddListener(onPlayerReleasedGrabPoint);
        }
    }

    private void onPlayerGrabbedSecondPoint(SelectEnterEventArgs arg0)
    {
        secondHandController =(XRBaseInteractor) arg0.interactorObject;
    }

    private void onPlayerReleasedGrabPoint(SelectExitEventArgs arg0)
    {
        secondHandController = null;

        XRBaseInteractor firsthandController = (XRBaseInteractor)interactorsSelecting[0];

        if (firsthandController != null)
        {
            firsthandController.attachTransform.localRotation = firstHandInitialRotation;
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondHandController!=null && interactorsSelecting.Count > 0)
        {
            XRBaseInteractor firstHandController = (XRBaseInteractor)interactorsSelecting[0];

            firstHandController.attachTransform.rotation = Quaternion.LookRotation(secondHandController.attachTransform.position - firstHandController.attachTransform.position);
        }

        base.ProcessInteractable(updatePhase);
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor firstHandInteractor = (XRBaseInteractor)args.interactorObject;

        firstHandInitialRotation = firstHandInteractor.attachTransform.localRotation;

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        XRBaseInteractor firstHandInteractor = (XRBaseInteractor)args.interactorObject;

        secondHandController = null;

        firstHandInteractor.attachTransform.localRotation = firstHandInitialRotation;

        base.OnSelectExited(args);
    }


    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        bool alreadyGrabbedWeapon = interactorsSelecting.Count > 0 && !interactor.Equals(interactorsSelecting[0]);


        return base.IsSelectableBy(interactor) && !alreadyGrabbedWeapon;
    }
}
