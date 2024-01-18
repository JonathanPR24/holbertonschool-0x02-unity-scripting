using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate the coin around its x-axis over time
        transform.Rotate(new Vector3(45f, 0f, 0f) * Time.deltaTime);
    }
}
