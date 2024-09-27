using UnityEngine;
namespace TCS.TestSystems.ExampleSystems {
    public class LoggerManagerExample : MonoBehaviour {
        void Start() {
            // Enable logging for PlayerController
            LoggerManager.EnableLogger<PlayerController>();

            // Disable logging for EnemyAI
            LoggerManager.DisableLogger<EnemyAI>();

            // Set custom colors for loggers
            LoggerManager.SetLoggerColor<PlayerController>(Color.green);
            LoggerManager.SetLoggerColor<EnemyAI>(Color.red);

            // Enable multiple loggers at once
            LoggerManager.EnableLoggers(typeof(PlayerController), typeof(EnemyAI));

            // Disable all loggers globally
            // LoggerManager.DisableAllLoggers();

            // Enable all loggers globally
            // LoggerManager.EnableAllLoggers();
        }

        void Update() {
            // Example of dynamically disabling a logger based on some condition
            if (Input.GetKeyDown(KeyCode.E)) {
                LoggerManager.DisableLogger<PlayerController>();
                Debug.Log("PlayerController logging has been disabled via LoggerManager.");
            }

            if (Input.GetKeyDown(KeyCode.P)) {
                LoggerManager.EnableLogger<PlayerController>();
                Debug.Log("PlayerController logging has been enabled via LoggerManager.");
            }
        }
    }
}