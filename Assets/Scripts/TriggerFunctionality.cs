using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    MeshRenderer mr;
    public List<AudioClip> clips;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;  
    }
}
