//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using InexperiencedDeveloper.Extensions;

//namespace InexperiencedDeveloper.ActiveRagdoll
//{
//    public class LaunchPad : Trap
//    {

//        private float liftForce;
//        [SerializeField] private GameObject Player;
//        private float accelTime;
//        [SerializeField] private float lerpDuration;
//        [SerializeField] private float startValue;
//        [SerializeField] private float endValue;
//        private bool padActivated = false;
        


//        private void OnTriggerEnter(Collider other)
//        {
//            accelTime = 0f;
//            liftForce = 0f;
//            padActivated = true;

//            if (other.tag == "Player")
//            {
//                Debug.Log("NYOOM");
//                StartCoroutine(Launch(other));
//            }

//        }

//        private float CalculateAccleration()
//        {

//            if (padActivated)
//            {
//                liftForce = Mathf.Lerp(startValue, endValue, accelTime / lerpDuration);
//                accelTime += Time.deltaTime;
//                return liftForce;
//            }

//            padActivated = false;
//        }

//        private IEnumerator Launch(Collider collider)
//        {
//            //collider.GetComponent<Rigidbody>().AddForce(transform.up * liftForce, ForceMode.Acceleration);

//            yield return new WaitForSeconds(lerpDuration);
//            Rigidbody[] bodies = collider.gameObject.GetComponentsInChildren<Rigidbody>();
//            foreach (Rigidbody bodypart in bodies)
//            {

//                bodypart.AddForce(transform.up * CalculateAccleration(), ForceMode.Acceleration);

//            }

//        }

//        public override void Activate(Rigidbody Rb)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}