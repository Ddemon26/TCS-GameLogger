using TCS.TestSystems.Logging;
using UnityEngine;

namespace TCS.TestSystems.GlobalLogger {
    public class ExampleLoggerUser : MonoBehaviour
    {
        void Start()
        {
            // Set the color for this logger
            GameLogger.SetColor<ExampleLoggerUser>(Color.green);

            // Log messages
            GameLogger.Log("ExampleLoggerUser started.");
            GameLogger.LogWarning("This is a warning message.");
            GameLogger.LogError("This is an error message.");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                GameLogger.Log("Logging a message every frame when L is pressed.");
            }
        }
    }
}