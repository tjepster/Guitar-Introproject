using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{

    // this does not work yet but the methods should start and stop the particle effect
    public ParticleSystem fire;
    public void StartTheFire()
    {
        fire.Play(true);
    }
    public void StopTheFire()
    {
        fire.Play(false);
    }
}
