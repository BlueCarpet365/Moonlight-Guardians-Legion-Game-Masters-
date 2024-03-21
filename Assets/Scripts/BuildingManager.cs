using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public LayerMask layerMaskToIgnore;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject building;
    [SerializeField] private Button buildWood;
    [SerializeField] private Button stopBuild;
    private bool isBuilding;

    private void Start()
    {
        buildWood.onClick.AddListener(StartBuilding);
        stopBuild.onClick.AddListener(StopBuilding);
    }

    private void Update()
    {
        if (isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMaskToIgnore))
            {
                Vector3 hitPosition = hit.point;

                building.transform.position = hitPosition + Vector3.up;

                if (Input.GetMouseButtonDown(0))
                {
                    StopBuilding();

                    if (inventory.CanBuild(Collectible.ItemType.Wood, 2) && hit.transform.tag == "BuildArea")
                    {
                        inventory.AddResource(Collectible.ItemType.Wood, -2); 
                        GameObject newBuilding = Instantiate(building, hitPosition + Vector3.up, Quaternion.identity);
                        newBuilding.SetActive(true);
                    }
                }
            }
        }
    }

    private void StartBuilding()
    {
        isBuilding = true;
        building.SetActive(true);
        buildWood.gameObject.SetActive(false);
        stopBuild.gameObject.SetActive(true);
    }

    private void StopBuilding()
    {
        isBuilding = false;
        building.SetActive(false);
        stopBuild.gameObject.SetActive(false);
        buildWood.gameObject.SetActive(true);
    }
}
