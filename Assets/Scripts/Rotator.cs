using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        transform.Rotate(new UnityEngine.Vector3(0, (speed * Time.deltaTime) * -1f, 0));
    }
}
