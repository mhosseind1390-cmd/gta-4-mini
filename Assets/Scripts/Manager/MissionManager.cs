using UnityEngine;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }
    
    [System.Serializable]
    public class Mission
    {
        public string missionName;
        public string description;
        public int reward;
        public bool completed;
    }
    
    private List<Mission> missions = new List<Mission>();
    private Mission currentMission;
    
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
        InitializeMissions();
    }
    
    private void InitializeMissions()
    {
        missions.Add(new Mission
        {
            missionName = "Bank Robbery",
            description = "Rob the bank and escape",
            reward = 5000,
            completed = false
        });
        
        missions.Add(new Mission
        {
            missionName = "Car Theft",
            description = "Steal the target vehicle",
            reward = 2000,
            completed = false
        });
        
        missions.Add(new Mission
        {
            missionName = "Police Chase",
            description = "Escape from the police",
            reward = 1000,
            completed = false
        });
        
        missions.Add(new Mission
        {
            missionName = "Drug Deal",
            description = "Complete the drug deal",
            reward = 3000,
            completed = false
        });
    }
    
    public void StartMission(int missionIndex)
    {
        if (missionIndex >= 0 && missionIndex < missions.Count)
        {
            currentMission = missions[missionIndex];
            Debug.Log($"Mission Started: {currentMission.missionName}");
        }
    }
    
    public void CompleteMission()
    {
        if (currentMission != null)
        {
            currentMission.completed = true;
            GameManager.Instance.AddMoney(currentMission.reward);
            GameManager.Instance.AddScore(100);
            Debug.Log($"Mission Completed: {currentMission.missionName}");
            currentMission = null;
        }
    }
    
    public Mission GetCurrentMission() => currentMission;
    public List<Mission> GetAllMissions() => missions;
}
