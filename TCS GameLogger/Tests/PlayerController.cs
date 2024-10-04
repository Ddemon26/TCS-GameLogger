using UnityEngine;
namespace TCS.GameLogger.Tests {
    public class PlayerController : MonoBehaviour {
        void Start() {
            GameLogger.Log("PlayerController initialized.");
        }

        void Update() {
            GameLogger.Log("PlayerController updating.");
        }
    }
}