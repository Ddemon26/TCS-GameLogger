using TCS.TestSystems.Logging;
using UnityEngine;
namespace TCS.TestSystems.ExampleSystems {
    public class PlayerController : MonoBehaviour {
        void Start() {
            GameLogger.Log("PlayerController initialized.");
        }

        void Update() {
            GameLogger.Log("PlayerController updating.");
        }
    }
}