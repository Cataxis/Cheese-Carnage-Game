using TMPro;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    private MazeSpawner mazeSpawner;
    public int totalCheeses;

    [SerializeField]
    private TextMeshProUGUI coinsText;

    private void Start()
    {
        Invoke(nameof(CountCheese), .1f);
        UpdateCoinsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese"))
        {
            Destroy(other.gameObject);
            totalCheeses--;
            UpdateCoinsText();
            Debug.Log("" + totalCheeses);
        }
    }

    private void CountCheese()
    {
        mazeSpawner = FindObjectOfType<MazeSpawner>();
        if (mazeSpawner != null)
        {
            foreach (Transform child in mazeSpawner.transform)
            {
                if (child.CompareTag("Cheese"))
                {
                    totalCheeses++;
                }
            }
        }
        
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.SetText("" + totalCheeses);
    }
}
