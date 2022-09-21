using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    [SerializeField] private float liftForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("NYOOM");
            Launch(other);
    }

    private void Launch(Collider collider)
    {
        collider.GetComponent<Rigidbody>().AddForce(transform.up * liftForce, ForceMode.Impulse);
    }

}
