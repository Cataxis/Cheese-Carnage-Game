using UnityEngine;
using TMPro;

public class GetCheese : MonoBehaviour
{
    private CheeseManager cheeseManager;
    public GameManager timeManager;
    private TextMeshProUGUI cheeseText;
    private AudioSource getCheeseSound;

    private void Start()
    {
        cheeseManager = FindObjectOfType<CheeseManager>();
        cheeseText = GameObject.FindGameObjectWithTag("cheeseText").GetComponent<TextMeshProUGUI>();
        UpdateCheeseText();
        timeManager = FindObjectOfType<GameManager>();
        getCheeseSound = GetComponent<AudioSource>();
    }

    private void UpdateCheeseText()
    {
        cheeseText.text = "" + cheeseManager.totalCheeses;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cheeseManager.totalCheeses--;
            Debug.Log("" + cheeseManager.totalCheeses);
            UpdateCheeseText();

            if (cheeseManager.totalCheeses <= 0)
            {
                if (timeManager != null)
                {
                    timeManager.StopTimer();
                }
            }

            Destroy(this.gameObject);
        }
    }

}
