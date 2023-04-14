using UnityEngine;

public class PrissionStartGame : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float timeSpawnEnemy = 60f;
    [SerializeField] private GameObject particlesClosePrission;

    void Start()
    {
        Invoke("SpawnEnemy", timeSpawnEnemy);
        Invoke("Alarm", timeSpawnEnemy - 4f);
        Destroy(this.gameObject, timeSpawnEnemy + .2f);
    }

    public void SpawnEnemy()
    {
        Enemy.SetActive(true);
        particlesClosePrission.SetActive(true);
    }

    public void Alarm()
    {
        alarm.Play();
    }

}
