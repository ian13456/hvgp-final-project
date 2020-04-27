using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform lootSpawnCenter;
    public Transform lootSpawnParent;
    public List<GameObject> itemPrefabs;

    public int lootCount;
    public int lootRadius;

    private List<GameObject> loots;

    void Start()
    {
        loots = new List<GameObject>();

        SpawnLoots();
    }

    void SpawnLoots()
    {
        for (int i = 0; i < lootCount; ++i)
        {
            Vector3 randomPosition = Helpers.GetRandomNavPosition(lootSpawnCenter.position, lootRadius, -1);

            GameObject newLoot = Instantiate(GetRandomItemPrefab(), randomPosition, Quaternion.identity, lootSpawnParent);
            loots.Add(newLoot);
        }
    }

    GameObject GetRandomItemPrefab()
    {
        return itemPrefabs[Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * itemPrefabs.Count)];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lootRadius);
    }
}
