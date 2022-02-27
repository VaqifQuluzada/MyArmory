using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPieceSoundEffectController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
    }
}
