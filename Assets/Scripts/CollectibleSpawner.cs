using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnAreaMin;
    [SerializeField] private Transform spawnAreaMax;
    [SerializeField] private int minResource;
    [SerializeField] private int maxResource;
    [SerializeField] private GameObject[] collectibleToSpawn;

    public void SpawnResources()
    {
        int resource = Random.Range(minResource, maxResource + 1);

        for (int i = 0; i < resource; i++)
        {
            float posX = Random.Range(spawnAreaMin.transform.position.x, spawnAreaMax.transform.position.x);
            float posZ = Random.Range(spawnAreaMin.transform.position.z, spawnAreaMax.transform.position.z);

            Vector3 pos = new Vector3(posX, spawnAreaMin.transform.position.y, posZ);

            for (int j = 0; j < collectibleToSpawn.Length; j++)
            {
                GameObject obj = Instantiate(collectibleToSpawn[j], pos + Vector3.up * collectibleToSpawn[j].transform.position.y, collectibleToSpawn[j].transform.rotation);
                obj.SetActive(true);
            }
        }
    }
}
