using System.Collections;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float followSpeed = 4f;
    public float y0ffset = 1f;
    public Transform target; // will return the position of the player
    public float shakeDuration;
    public AnimationCurve shakeCurve;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + y0ffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    public IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float shakeTimer = 0f;
        while (shakeTimer < shakeDuration)
        {
            shakeTimer += Time.deltaTime;
            float strength = shakeCurve.Evaluate(shakeTimer / shakeDuration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
