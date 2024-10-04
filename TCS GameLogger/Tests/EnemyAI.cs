using UnityEngine;

namespace TCS.GameLogger.Tests {
    public class EnemyAI : MonoBehaviour {
        void Start() {
            GameLogger.LogWarning("EnemyAI initialized with potential issues.");
        }

        void Update() {
            GameLogger.LogError("EnemyAI encountered an error.");
        }
    }
}