using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Animal
    {
        public GameObject animalPrefab;
        public int hunger;
    }

    public Animal[] animalPrefabs;
    private float spawnRangeX = 10f;
    private float spawnPosZ = 20f;

    [Tooltip("Enables Aggressive Mode (animals spawn on both sides)")]
    public bool isAggressive = false;
    private float spawnLowerZ = 0f;
    private float spawnUpperZ = 15f;
    private float spawnLeftX = -25f;
    private float spawnRightX = 25f;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        if (isAggressive)
        {
            InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
            InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            0,
            spawnPosZ);

        SpawnAnimal(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].animalPrefab.transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            spawnLeftX,
            0,
            Random.Range(spawnLowerZ, spawnUpperZ));

        SpawnAnimal(
            animalPrefabs[animalIndex],
            spawnPos,
            Quaternion.Euler(0, 90, 0));
    }

    void SpawnRandomAnimalRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            spawnRightX,
            0,
            Random.Range(spawnLowerZ, spawnUpperZ));

        SpawnAnimal(
            animalPrefabs[animalIndex],
            spawnPos,
            Quaternion.Euler(0, -90, 0));
    }

    void SpawnAnimal(Animal animal, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedAnimal = Instantiate(animal.animalPrefab, position, rotation);
        spawnedAnimal.GetComponent<DetectCollisions>().Initialize(animal.hunger);
    }
}
