using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static class Difficulty
    {
        public const float EASY_MULTIPLIER = 1.5f;
        public const float NORMAL_MULTIPLIER = 1.0f;
        public const float HARD_MULTIPLIER = 0.7f;
    }
    
    public static class RewardSettings
    {
        public const int BASE_ENEMY_REWARD = 50;
        public const int BASE_POLICE_REWARD = 500;
        public const int MISSION_COMPLETION_REWARD = 100;
    }
    
    public static class PlayerSettings
    {
        public const float DEFAULT_HEALTH = 100f;
        public const float DEFAULT_MOVE_SPEED = 10f;
        public const float DEFAULT_ROTATION_SPEED = 5f;
    }
    
    public static class EnemySettings
    {
        public const float DEFAULT_HEALTH = 100f;
        public const float DEFAULT_MOVE_SPEED = 5f;
        public const float DETECTION_RANGE = 30f;
        public const float SHOOT_RANGE = 20f;
    }
    
    public static class PoliceSettings
    {
        public const float DEFAULT_HEALTH = 80f;
        public const float DEFAULT_CHASE_SPEED = 8f;
        public const float SHOOT_RANGE = 15f;
        public const int MAX_POLICE_COUNT = 10;
        public const float SPAWN_DISTANCE = 50f;
    }
}
