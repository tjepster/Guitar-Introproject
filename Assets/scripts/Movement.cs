using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.fixedDeltaTime);
    }
}
