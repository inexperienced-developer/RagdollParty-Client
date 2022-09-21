using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodysegmentweight : MonoBehaviour
{
    [SerializeField] float totalRagdollMass = 30f;
    [SerializeField] float ballWeight = 5f;

    public float hipsRatio = 0.1766f;
    public float thighRatio = 0.05383f;
    public float legsRatio = 0.026925f;
    public float footRatio = 0.01615f;
    public float waistRatio = 0.1689f;
    public float chestRatio = 0.2592f;
    public float armRatio = 0.0184f;
    public float forearmRatio = 0.0092f;
    public float handRatio = 0.0055f;
    public float headRatio = 0.1056f;



    // Start is called before the first frame update
    void OnValidate()
    {
        AdjustBodyWeights();
    }

    [ContextMenu("AdjustBodyWeights")]
    private void AdjustBodyWeights()
    {
        GetComponent<Rigidbody>().mass = ballWeight;


        #region Finding Child body segments and set mass as product of body% and total doll weight
        GameObject.Find("Player/testRagdoll/hips").GetComponent<Rigidbody>().mass = (hipsRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.l").GetComponent<Rigidbody>().mass = (thighRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.r").GetComponent<Rigidbody>().mass = (thighRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist").GetComponent<Rigidbody>().mass = (waistRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.l/leg.l").GetComponent<Rigidbody>().mass = (legsRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.r/leg.r").GetComponent<Rigidbody>().mass = (legsRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest").GetComponent<Rigidbody>().mass = (chestRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.l/leg.l/foot.l").GetComponent<Rigidbody>().mass = (footRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/thigh.r/leg.r/foot.r").GetComponent<Rigidbody>().mass = (footRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.l").GetComponent<Rigidbody>().mass = (armRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.r").GetComponent<Rigidbody>().mass = (armRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.l/forearm.l").GetComponent<Rigidbody>().mass = (forearmRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.r/forearm.r").GetComponent<Rigidbody>().mass = (forearmRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.l/forearm.l/hand.l").GetComponent<Rigidbody>().mass = (handRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/arm.r/forearm.r/hand.r").GetComponent<Rigidbody>().mass = (handRatio * totalRagdollMass);

        GameObject.Find("Player/testRagdoll/hips/Body Parts/waist/chest/neck/head").GetComponent<Rigidbody>().mass = (headRatio * totalRagdollMass);
        #endregion

    }
}
