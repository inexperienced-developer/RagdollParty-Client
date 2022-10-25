using InexperiencedDeveloper.Core.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private Transform _transform;
    private Transform _playerTransform;
    private bool aqcuired = false;
    public GameObject player;
    public GameObject righthand;
    [SerializeField] int sizeInHand = 2;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    [SerializeField] private float maxDistance = 100f;
    private SpringJoint joint;
    private float grappleLerp;

    public float grappleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        _transform = GetComponent<Transform>();
        lr = GetComponent<LineRenderer>();
        _playerTransform = player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (aqcuired && Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }

        else if (aqcuired && Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

        if (!aqcuired)
        {
            _transform.Rotate(0, 0.5f, 0);
        }

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void OnTriggerEnter(Collider other)
    {

        aqcuired = true;
        transform.parent = righthand.transform;

        Vector3 newPos = righthand.transform.position;
        transform.position = newPos;
        transform.localScale = Vector3.one * sizeInHand;

        
    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void StartGrapple()
    {
        grappleLerp = 0;
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(_playerTransform.position, grapplePoint);


            //The distance grapple will try to keep from grapple point.
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Mess around with these values more
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;

        Vector3 tempGrapplePoint = Vector3.Lerp(transform.position, grapplePoint, grappleLerp);
        grappleLerp += Time.deltaTime * grappleSpeed;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, tempGrapplePoint);
    }

}
