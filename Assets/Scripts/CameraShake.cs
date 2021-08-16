using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public static CameraShake Instance;

    void Awake()
    {
        originalPosition = transform.localPosition;

        if (Instance == null)
            Instance = this;
    }

    public static void Shake(float duration, float amount)
    {
        Instance.StopAllCoroutines();
        Instance.StartCoroutine(Instance.ShakeRoutine(duration, amount));
    }

    public IEnumerator ShakeRoutine(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
