using System.Collections;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] private StackPartController[] stackPartControllers = null;

    public void ShatterAllParts()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }

        foreach (StackPartController part in stackPartControllers)
        {
            if (part != null)
               part.Shatter();
        }
        StartCoroutine(RemoveAllParts());
    }

    private IEnumerator RemoveAllParts()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
