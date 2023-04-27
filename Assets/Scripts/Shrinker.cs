using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out HarryController player))
        {
            player.TransformSize();
        }
    }

}
