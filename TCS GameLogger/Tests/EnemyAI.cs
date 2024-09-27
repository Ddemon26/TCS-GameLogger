using UnityEngine;
using TCS.TestSystems.Logging;

namespace TCS.TestSystems.ExampleSystems {
    public class EnemyAI : MonoBehaviour {
        void Start() {
            GameLogger.LogWarning("EnemyAI initialized with potential issues.");
        }

        void Update() {
            GameLogger.LogError("EnemyAI encountered an error.");
        }
    }
}