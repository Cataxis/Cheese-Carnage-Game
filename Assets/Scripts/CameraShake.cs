using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject enemy;
    public float shakeIntensity = 0.05f;
    public float shakeDuration = 0.2f;
    public float minShakeDistance = 2f;

    private Vector3 originalPos;
    private bool isShaking = false;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
        if (enemy.activeInHierarchy && distanceToEnemy <= minShakeDistance && !isShaking)
        {
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        isShaking = true;

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

        isShaking = false;
    }
}


