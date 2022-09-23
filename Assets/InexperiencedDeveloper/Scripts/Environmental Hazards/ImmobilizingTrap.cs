using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobilizingTrap : MonoBehaviour
{

    private bool hasEscaped = true;
    private new Collider collider;
    [SerializeField] private int escapeTime = 3;


    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("TRAPPED");
        if (collider.tag == "Player" && hasEscaped == true)
        {
            hasEscaped = false;
            this.collider = collider;
            RestrictMovement();
        }

    }

    private void RestrictMovement()
    {

        collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void Update()
    {

        EscapeMethod(collider);

    }

    private void EscapeMethod(Collider collider)
    {

        if (collider == null)
        {
            Debug.Log("Something wrong with collider here...");
            return;
        }

        if (hasEscaped == false && Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("YOU ARE FREE!");
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine(EscapeTimer(escapeTime));
        }
       
    }

    private IEnumerator EscapeTimer(int escapeTime)
    {
        yield return new WaitForSeconds(escapeTime);
        hasEscaped = true;
    }

}
