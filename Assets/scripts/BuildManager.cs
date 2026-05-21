using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Tower Prefabs")]
    public GameObject archerTowerPrefab;
    public GameObject mageTowerPrefab;
    public GameObject freezerTowerPrefab;
    public GameObject cannonTowerPrefab;

    [Header("Tower Costs")]
    public int archerCost = 100;
    public int mageCost = 150;
    public int freezerCost = 120;
    public int cannonCost = 200;

    [Header("Layers")]
    public LayerMask pathLayer;

    private GameObject selectedTowerPrefab;
    private int selectedTowerCost;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTowerPrefab == null)
                return;

            Vector3 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.z = 0f;

            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(mousePosition.y);

            BuildTower(mousePosition);
        }
    }

    public void SelectArcherTower()
    {
        selectedTowerPrefab = archerTowerPrefab;
        selectedTowerCost = archerCost;
    }

    public void SelectMageTower()
    {
        selectedTowerPrefab = mageTowerPrefab;
        selectedTowerCost = mageCost;
    }

    public void SelectFreezerTower()
    {
        selectedTowerPrefab = freezerTowerPrefab;
        selectedTowerCost = freezerCost;
    }

    public void SelectCannonTower()
    {
        selectedTowerPrefab = cannonTowerPrefab;
        selectedTowerCost = cannonCost;
    }

    public void BuildTower(Vector3 position)
    {
        if (selectedTowerPrefab == null)
            return;

        if (gameManager.currentGold < selectedTowerCost)
        {
            Debug.Log("Not enough gold");
            return;
        }

        Collider2D hit = Physics2D.OverlapPoint(
            position,
            pathLayer
        );

        if (hit != null)
        {
            Debug.Log("Cannot build on path!");
            return;
        }

        Instantiate(
            selectedTowerPrefab,
            position,
            Quaternion.identity
        );

        gameManager.SpendGold(selectedTowerCost);

        selectedTowerPrefab = null;
    }
}