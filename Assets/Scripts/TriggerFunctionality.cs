using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    MeshRenderer mr;
    public List<AudioClip> clips;
    


    [Header("(Por esto no os preocup�is, no toqu�is nada)")]
    public GameObject brother;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;  
    }
}
