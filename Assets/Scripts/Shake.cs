using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Generate a shake effect on an object.
    public IEnumerator ShakeOnce(float duration, float magnitude)
    {
        // Saving position and elapsed time.
        Vector3 originPos = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Creating new random coordinates.
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Updating position of the object.
            transform.localPosition = new Vector3(x, y, originPos.z);

            // Updating elapsed time.
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Set the position back to it's original values.
        transform.localPosition = originPos;
    }
}
