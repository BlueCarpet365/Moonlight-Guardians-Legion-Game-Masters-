using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    [System.Serializable]
    public class Building
    {
        public GameObject GameObject;
        public Collectible.ItemType ItemType;
        public int Cost;
    }

    public LayerMask layerMaskToIgnore;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Button buildWood;
    [SerializeField] private Button buildStone;
    [SerializeField] private Button stopBuild;
    private bool isBuilding;
    [SerializeField] private Building[] buildings;
    private Building selectedBuilding;

    private void Start()
    {
        selectedBuilding = buildings[0];
        buildWood.onClick.AddListener(BuildWood);
        buildStone.onClick.AddListener(BuildStone);
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

                selectedBuilding.GameObject.transform.position = hitPosition;

                if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    StopBuilding();

                    if (inventory.CanBuild(selectedBuilding.ItemType, selectedBuilding.Cost) && hit.transform.tag == "BuildArea")
                    {
                        inventory.AddResource(selectedBuilding.ItemType, -selectedBuilding.Cost);
                        GameObject newBuilding = Instantiate(selectedBuilding.GameObject, hitPosition, Quaternion.identity);
                        newBuilding.GetComponent<BuildingHealth>().startHealth = 100f;
                        newBuilding.SetActive(true);
                    }
                }
            }
        }
    }

    private void BuildWood()
    {
        selectedBuilding.GameObject.SetActive(false);
        selectedBuilding = buildings[0];
        isBuilding = true;
        selectedBuilding.GameObject.SetActive(true);
        stopBuild.gameObject.SetActive(true);
    }

    private void BuildStone()
    {
        selectedBuilding.GameObject.SetActive(false);
        selectedBuilding = buildings[1];
        isBuilding = true;
        selectedBuilding.GameObject.SetActive(true);
        stopBuild.gameObject.SetActive(true);
    }

    private void StopBuilding()
    {
        isBuilding = false;
        selectedBuilding.GameObject.SetActive(false);
        stopBuild.gameObject.SetActive(false);
        buildWood.gameObject.SetActive(true);
        buildStone.gameObject.SetActive(true);
    }
}
