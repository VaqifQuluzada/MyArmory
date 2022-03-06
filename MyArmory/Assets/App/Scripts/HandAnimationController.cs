using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject GrabHand;

    [SerializeField] private GameObject OpenHand;

    public void GrabHandAnimation(bool isGrabbed)
    {
        GrabHand.SetActive(isGrabbed);

        OpenHand.SetActive(!isGrabbed);
    }
}
