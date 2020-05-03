using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform dinoSpawnCenter;
    public List<GameObject> smallDinoPrefabs;
    public List<GameObject> hugeDinoPrefabs;

    public int smallDinoCount;
    public int hugeDinoCount;
    public int dinoSpawnRadius;

    private Transform dinoParent;
    private List<GameObject> smallDinos;
    private List<GameObject> hugeDinos;

    void Start()
    {
        dinoParent = transform;

        smallDinos = new List<GameObject>();
        hugeDinos = new List<GameObject>();

        SpawnDinos();
    }

    void SpawnDinos()
    {
        for (int i = 0; i < smallDinoCount; i++)
        {
            Vector3 randomPosition = Helpers.GetRandomNavPosition(dinoSpawnCenter.position, dinoSpawnRadius, -1);
            GameObject newSmallDino = Instantiate(GetRandomSmallDinoPrefab(), randomPosition, Quaternion.identity, dinoParent);

            smallDinos.Add(newSmallDino);
        }

        for (int i = 0; i < hugeDinoCount; i++)
        {
            Vector3 randomPosition = Helpers.GetRandomNavPosition(dinoSpawnCenter.position, dinoSpawnRadius, -1);
            GameObject newHugeDino = Instantiate(GetRandomHugeDinoPrefab(), randomPosition, Quaternion.identity, dinoParent);

            hugeDinos.Add(newHugeDino);
        }
    }

    GameObject GetRandomSmallDinoPrefab()
    {
        return smallDinoPrefabs[Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * smallDinoPrefabs.Count)];
    }

    GameObject GetRandomHugeDinoPrefab()
    {
        return hugeDinoPrefabs[Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * hugeDinoPrefabs.Count)];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dinoSpawnRadius);
    }
}
