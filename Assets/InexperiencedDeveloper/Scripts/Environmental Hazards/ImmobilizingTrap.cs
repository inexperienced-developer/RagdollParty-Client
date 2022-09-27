using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobilizingTrap : Trap
{

    private bool padActive = true;
    private List<Collider> immobilizedColliders = new List<Collider>();
    [SerializeField] private int escapeTime = 3;
    [SerializeField] private LayerMask characterLayer;


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<Ball>()) return;

        if (collider.gameObject.layer == 6)
        {
            
            Ball[] parent = collider.GetComponentsInParent<Ball>();
            Debug.Log(parent.Length);

            if (parent.Length > 0)
            {
                Debug.Log("TRAPPED");
                padActive = false;
                Activate(parent[0].GetComponent<Rigidbody>());
                immobilizedColliders.Add(parent[0].GetComponent<SphereCollider>());
            }

        }

    }


    private void Update()
    {

        EscapeMethod();

    }

    private void EscapeMethod()
    {

        if (padActive == false && Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("YOU ARE FREE!");
            foreach (Collider c in immobilizedColliders)
            {
                c.GetComponent<Rigidbody>().isKinematic = false;
            }

            
            StartCoroutine(EscapeTimer(escapeTime));
        }
       
    }

    private IEnumerator EscapeTimer(int escapeTime)
    {
        yield return new WaitForSeconds(escapeTime);
        padActive = true;
    }

    public override void Activate(Rigidbody rb)
    {
        rb.isKinematic = true;
        Vector3 newPos = transform.position;
        newPos.y += 0.5f;
        rb.transform.position = newPos;
    }
}
