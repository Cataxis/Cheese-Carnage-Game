using UnityEngine;

public class StopTime : MonoBehaviour
{
    public GameManager manager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             manager.StopTimer();
             Destroy(this.gameObject);
        }
    }
}