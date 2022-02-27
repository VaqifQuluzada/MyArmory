using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    [SerializeField] private int destructionHit;

    [SerializeField] private int currentHitCount;

    [SerializeField] private GameObject destroyedDummyPrefab;

    private AudioSource dummyAudioSource;

    private void Start()
    {
        dummyAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentHitCount >= destructionHit)
        {
            foreach(Collider collider in GetComponents<Collider>())
            {
                collider.enabled = false;
            }

            GameObject destroyedDummyInstance = Instantiate(destroyedDummyPrefab, transform.position, transform.rotation);

            Destroy(destroyedDummyInstance, 5f);

            Destroy(gameObject);

            return;
        }

        dummyAudioSource.Stop();

        dummyAudioSource.Play();

        currentHitCount++;
    }
}
