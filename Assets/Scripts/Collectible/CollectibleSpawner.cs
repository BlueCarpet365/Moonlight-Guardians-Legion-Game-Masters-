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

        for (int i = 0; i < collectibleToSpawn.Length; i++)
        {
            int resource = Random.Range(minResource, maxResource + 1);
            
            for (int j = 0; j < resource; j++)
            {
                float posX = Random.Range(spawnAreaMin.transform.position.x, spawnAreaMax.transform.position.x);
                float posZ = Random.Range(spawnAreaMin.transform.position.z, spawnAreaMax.transform.position.z);

                Vector3 pos = new Vector3(posX, spawnAreaMin.transform.position.y, posZ);
                GameObject obj = Instantiate(collectibleToSpawn[i], pos + Vector3.up * collectibleToSpawn[i].transform.position.y, collectibleToSpawn[i].transform.rotation);
                obj.SetActive(true);
            }
        }
    }
}
