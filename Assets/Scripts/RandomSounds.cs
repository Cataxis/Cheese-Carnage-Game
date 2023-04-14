using System.Collections;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] private float minTime = 5f;
    [SerializeField] private float maxTime = 10f;
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySounds());
    }

    private IEnumerator PlaySounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.Play();
        }
    }
}
