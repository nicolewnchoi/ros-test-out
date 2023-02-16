using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [SerializeField] private float spawnTimeInterval;

    public GameObject[] shapePrefabs;

    private void Start()
    {
        InvokeRepeating("SpawnShape", spawnTimeInterval, spawnTimeInterval);
    }
    private void SpawnShape()
    {
        int randomShape = Random.Range(0, shapePrefabs.Length);
        GameObject shapeRight = Instantiate(shapePrefabs[randomShape], new Vector2(transform.position.x + 20, transform.position.y), Quaternion.identity);
        shapeRight.GetComponent<ShapeBehavior>().random = RandomSpawner(0, 2*Mathf.PI);
        GameObject shapeLeft = Instantiate(shapePrefabs[randomShape], new Vector2(transform.position.x - 20, transform.position.y), Quaternion.identity);
        shapeLeft.GetComponent<ShapeBehavior>().random = RandomSpawner(0, 2 * Mathf.PI);
    }
    public Vector2 RandomSpawner(float angleMin, float angle)
    {
        float random = Random.Range(angleMin, angle);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }
}