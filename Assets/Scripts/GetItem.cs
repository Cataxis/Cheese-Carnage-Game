using UnityEngine;

public class GetItem : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese"))
        {
            audioSource.Play();
        }
    }
}
