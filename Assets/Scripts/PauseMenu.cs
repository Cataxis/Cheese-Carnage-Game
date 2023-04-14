using SUPERCharacter;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Slider sensitivitySlider;

    [SerializeField]
    private SUPERCharacterAIO playerController;

    [SerializeField]
    [Range(1f, 20f)]
    public float minValue = 1f;

    [SerializeField]
    [Range(1f, 20f)]
    public float maxValue = 20f;


    [SerializeField]
    private bool isPaused = false;

    private float originalTimeScale;

    void Start()
    {
        sensitivitySlider.minValue = minValue;
        sensitivitySlider.maxValue = maxValue;
        sensitivitySlider.value = playerController.Sensitivity;

        pausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        playerController.Sensitivity = sensitivitySlider.value;
    }


    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            originalTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AudioListener.pause = true;
        }

        else
        {
            Time.timeScale = originalTimeScale;
            pausePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            AudioListener.pause = false;
        }
    }

    public void OnSensitivitySliderValueChanged(float value)
    {
        playerController.Sensitivity = sensitivitySlider.value;
    }
}

