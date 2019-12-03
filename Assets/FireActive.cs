using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
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
