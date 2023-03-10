using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [SerializeField] private float spawnTimeInterval;

    public GameObject[] shapePrefabs;
    public GameObject[] specialShapePrefabs;

    private void Start()
    {
        InvokeRepeating("SpawnShape", spawnTimeInterval, spawnTimeInterval);
    }
    private void SpawnShape()
    {
        if (Timer.Instance.timerIsRunning)
        {
            int randomShape = Random.Range(0, shapePrefabs.Length);
            GameObject shape = shapePrefabs[randomShape];
            if (Mathf.FloorToInt(Timer.Instance.timeRemaining) % 25 == 0)
            {
                randomShape = Random.Range(0, specialShapePrefabs.Length);
                shape = specialShapePrefabs[randomShape];
            }
            GameObject shapeRight = Instantiate(shape, new Vector2(transform.position.x + 20, transform.position.y), Quaternion.identity);
            shapeRight.GetComponent<ShapeBehavior>().random = RandomSpawner(Mathf.PI / 2, 3 * Mathf.PI / 2);
            GameObject shapeLeft = Instantiate(shape, new Vector2(transform.position.x - 20, transform.position.y), Quaternion.identity);
            shapeLeft.GetComponent<ShapeBehavior>().random = RandomSpawner(-Mathf.PI / 2, Mathf.PI / 2);
        }
    }
    public Vector2 RandomSpawner(float angleMin, float angle)
    {
        float random = Random.Range(angleMin, angle);
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }
}
