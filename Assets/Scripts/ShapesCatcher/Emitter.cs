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
        GameObject shape = Instantiate(shapePrefabs[randomShape], transform.position, Quaternion.identity);
        shape.GetComponent<ShapeBehavior>().random = RandomSpawner(512, 0);
        //GameObject shape2 = Instantiate(shapePrefabs[randomShape], transform.position, Quaternion.identity);
        //shape2.GetComponent<ShapeBehavior>().random = RandomSpawner(-512,0);
    }
    public Vector2 RandomSpawner(float angle, float angleMin)
    {
        //float random = Random.value * angle + angleMin;
        float random = Random.Range(angleMin, angle);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }
}
