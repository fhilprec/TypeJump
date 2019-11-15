using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.position = new Vector3(0, 2.5f, target.position.z-10);
    }
}
