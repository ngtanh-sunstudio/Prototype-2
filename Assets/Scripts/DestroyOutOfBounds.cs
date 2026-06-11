using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBound = 20f;
    private float lowerBound = -10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > upperBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
