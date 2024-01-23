using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Assign the player GameObject in the Inspector
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Adjust this offset in the Inspector

    void Update()
    {
        if (player != null)
        {
            // Set the camera's position to the player's position plus the offset
            transform.position = player.transform.position + offset;
        }
    }
}
