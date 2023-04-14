using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    [SerializeField] private float timeAutrodestroy;

    void Start()
    {
        Destroy(this.gameObject, timeAutrodestroy);
    }
}
