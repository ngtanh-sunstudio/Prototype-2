using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move Input")]
    public InputAction moveAction;
    public InputAction fireAction;
    private Vector2 moveInput;

    [Header("Configuration")]
    public float speed = 10f;
    public float xRange = 10f;
    public float zLowerBound = -1f;
    public float zUpperBound = 15f;

    [Header("Projectile")]
    public GameObject projectilePrefab;

    void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Check bounds
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -xRange, xRange), 
                transform.position.y, 
                transform.position.z);
        }
        if (transform.position.z < zLowerBound || transform.position.z > zUpperBound)
        {
            transform.position = new Vector3(
                transform.position.x, 
                transform.position.y, 
                Mathf.Clamp(transform.position.z, zLowerBound, zUpperBound)
            );
        }

        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * moveInput.y * Time.deltaTime * speed);
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);

        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }
}
