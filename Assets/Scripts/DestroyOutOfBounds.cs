using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBoundZ = 20f;
    private float lowerBoundZ = -10f;
    private float xRange = 25f;

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.z > upperBoundZ)
        // {
        //     Destroy(gameObject);
        // }

        // if (transform.position.z < lowerBoundZ)
        // {
        //     Debug.Log("Game Over!");
        //     Destroy(gameObject);
        // }

        if (transform.position.z > upperBoundZ
            || transform.position.z < lowerBoundZ
            || transform.position.x > xRange
            || transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
    }
}
