using System.Collections;
using InexperiencedDeveloper.Utils.Log;
using System.Collections.Generic;
using InexperiencedDeveloper.ActiveRagdoll;
using UnityEngine;

public class ApplyRagdollPhysics : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("Script was added to ragdoll");

        GetComponent<Player>().Init();
    }

}
