using UnityEngine;

public class FalsePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese"))
        {
            Destroy(other.gameObject);
        }
    }
}
