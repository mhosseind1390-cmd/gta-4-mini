using UnityEngine;
using System.Collections.Generic;

public class PoliceManager : MonoBehaviour
{
    public static PoliceManager Instance { get; private set; }
    
    [SerializeField] private GameObject policePrefab;
    [SerializeField] private float spawnDistance = 50f;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private int maxPoliceCount = 10;
    
    private Transform player;
    private float spawnTimer = 0f;
    private List<GameObject> activePolice = new List<GameObject>();
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    
    private void Update()
    {
        if (!player || GameManager.Instance.wantedLevel == 0)
            return;
        
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnInterval)
        {
            SpawnPolice();
            spawnTimer = 0f;
        }
        
        // Clean up dead police
        activePolice.RemoveAll(p => p == null);
    }
    
    public void SpawnPolice()
    {
        if (!player) return;
        
        if (activePolice.Count >= maxPoliceCount)
            return;
        
        if (!policePrefab)
        {
            Debug.LogError("Police prefab not assigned!");
            return;
        }
        
        // Spawn around player
        Vector3 spawnPosition = player.position + Random.onUnitSphere * spawnDistance;
        spawnPosition.y = player.position.y + 0.5f;
        
        GameObject policeObj = Instantiate(policePrefab, spawnPosition, Quaternion.identity);
        activePolice.Add(policeObj);
    }
    
    public void ClearAllPolice()
    {
        foreach (GameObject police in activePolice)
        {
            if (police) Destroy(police);
        }
        activePolice.Clear();
    }
}
