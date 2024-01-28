using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    MeshRenderer mr;
    public List<AudioClip> clips;
    


    [Header("(Por esto no os preocupéis, no toquéis nada)")]
    public GameObject brother;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;  
    }
}
