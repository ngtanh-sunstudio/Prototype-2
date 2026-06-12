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
    public int health = 3;
    public int score = 0;
    public float xRange = 10f;
    public float zLowerBound = -1f;
    public float zUpperBound = 15f;

    [Header("Projectile")]
    public GameObject projectilePrefab;

    void Awake()
    {
        health = 3; // Sanity check
        score = 0;
    }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
            health--;
            Debug.Log("Hit! Current Health: " + health);
            if (health < 1)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject);
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current score: " + score);
    }

    void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }
}
