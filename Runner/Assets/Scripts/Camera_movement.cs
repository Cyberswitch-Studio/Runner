using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y, player.position.z) + offset;
    }
}