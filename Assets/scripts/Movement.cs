using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public int speed = 100;
    void Start()
    {
        rb.AddForce(0, 0, -speed, ForceMode.VelocityChange);
    }
}