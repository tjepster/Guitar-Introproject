using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    public float Timer = 0.2f;
    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
