using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    public GameObject footsteps;

    public void PlayFootsteps()
    {
        footsteps.SetActive(true);
    }
    public void StopFootsteps()
    {
        footsteps.SetActive(false);
    }

}
