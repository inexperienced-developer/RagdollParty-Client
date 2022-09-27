using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InexperiencedDeveloper.Extensions;

namespace InexperiencedDeveloper.ActiveRagdoll
{
    public class LaunchPad : Trap
    {

        [SerializeField] private float liftForce = 10f;


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("NYOOM");
            if (other.tag == "Player")
            {
                Launch(other);
            }

        }

        private void Launch(Collider collider)
        {
            collider.GetComponent<Rigidbody>().SafeAddForce(transform.up * liftForce, ForceMode.Impulse);
        }

        public override void Activate(Rigidbody Rb)
        {
            throw new NotImplementedException();
        }
    }

}