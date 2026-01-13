using UnityEngine;

public class StackPartController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Collider partCollider;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        partCollider = GetComponent<Collider>();
    }

    public void Shatter()
    {
        rigidBody.isKinematic = false;
        partCollider.enabled = false;

        Vector3 forcePoint = transform.parent.position;

        Vector3 subDir = Vector3.up;
        Vector3 dir = (Vector3.up * 1.5f + subDir).normalized;

        float force = Random.Range(20f, 35f);
        float torque = Random.Range(110f, 180f);

        rigidBody.AddForceAtPosition(dir * force, forcePoint, ForceMode.Impulse);
        rigidBody.AddTorque(Vector3.left * torque);
        rigidBody.linearVelocity = Vector3.down;
    }
}