using UnityEngine;

public class GuitarEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Beat") 
        {
            collision.gameObject.SetActive(false);
        }
    }
}
