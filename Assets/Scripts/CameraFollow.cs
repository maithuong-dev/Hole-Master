using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraOffset;
    private Transform ballTransform, winTransform;

    void Awake()
    {
        ballTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (winTransform == null)
        {
            winTransform = GameObject.FindGameObjectWithTag("Done").transform;
        }

        if (ballTransform == null || winTransform == null)
            Debug.Log("Transforms not found!");

        if (transform.position.y > ballTransform.position.y + 2f && transform.position.y > winTransform.position.y + 6f)
        {
            cameraOffset = new Vector3(transform.position.x, ballTransform.position.y + 2f, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, cameraOffset.y, transform.position.z);
    }
}
