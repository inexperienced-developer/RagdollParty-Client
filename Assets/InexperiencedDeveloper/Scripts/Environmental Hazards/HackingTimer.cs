using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HackingTimer : MonoBehaviour
{

    [SerializeField] private LayerMask characterLayer;
    [SerializeField] private float defaultHackTime = 10f;
    private float hackTime;
    private TextMeshProUGUI hackClock;
    private bool isHacking = false;
    private Coroutine hackRoutine;

    private void Start()
    {
        hackTime = defaultHackTime;
        hackClock = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isHacking && hackTime > 0f)
        {

            hackTime -= Time.deltaTime;
            hackClock.text = "Hacking: " + hackTime.ToString();

        }

        if (hackTime <=0)
        {
            Debug.Log("Hack Complete");
            hackTime = 0f;
            hackClock.text = "Hacking: " + hackTime.ToString();
        }

    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<Ball>()) return;

        if (collider.gameObject.layer == 6)
        {
            isHacking = true;
            Debug.Log("Hacking Commencing");
            hackClock.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<Ball>()) return;

        if (other.gameObject.layer == 6)
        {
            isHacking = false;
            hackTime = defaultHackTime;
            hackClock.gameObject.SetActive(false);
        }
       
    }

    private IEnumerator HackTimer()
    {

        while (hackTime > 0f && isHacking == true)
        {
            hackTime -= Time.deltaTime;
            yield return null;
            hackClock.text = "Hacking: " + hackTime.ToString();
        }

        Debug.Log("Hack Complete");
    }

}
