# TCS GameLogger

![License](https://img.shields.io/badge/license-MIT-blue.svg) ![Unity Version](https://img.shields.io/badge/Unity-2023+.3%2B-green.svg) ![Contributions Welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg)

## Overview

![GitHub Issues](https://img.shields.io/github/issues/Ddemon26/TCS-GameLogger) ![GitHub Forks](https://img.shields.io/github/forks/Ddemon26/TCS-GameLogger) ![GitHub Stars](https://img.shields.io/github/stars/Ddemon26/TCS-GameLogger) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Ddemon26/TCS-GameLogger)

**TCS GameLogger** is a utility that enhances the standard Unity `Debug` functionality by wrapping it with additional capabilities for customization and control. It allows developers to create more descriptive log messages, manage log levels dynamically, and apply consistent visual enhancements to different types of logs. This utility also enables runtime control of logging, including toggling logs on or off based on the build type or specific debugging needs.

With **TCS GameLogger**, developers can easily capture, organize, and review log information to better understand game behavior during both development and testing phases. This logging framework is especially useful in identifying and troubleshooting game logic issues efficiently, providing a more flexible alternative to the default Unity logging tools.

The **TCS GameLogger** package includes core runtime components for logging, along with illustrative scripts and test examples. These resources help developers effectively integrate and utilize the logging framework within their Unity projects.

## Features

- **Customizable Logging Wrapper**: Extends Unity's standard `Debug` functionality by allowing customization of log messages, runtime control, and additional features such as color coding for different log types.
- **Simple Integration**: Uses Unity assembly definitions for modularity, allowing seamless integration into existing Unity projects without additional complexity.
- **Global Usage**: `GameLogger` is implemented as a static class, making it easily accessible across your project without manual instantiation. Simply use `GameLogger.<LogType>("message")` to log events.
- **Automatic Initialization**: No manual setup is required; the logging system automatically initializes when used for the first time.
- **Enhanced Console Output**: Adds features like color coding to enhance the standard Unity console output, making logs easier to distinguish and analyze.
- **Centralized Log Management**: Maintains centralized tracking of log entries to simplify access and enhance debugging consistency.
- **Runtime Logging Control**: Allows enabling or disabling logging dynamically during runtime, which is useful for debugging in development builds.
- **Sample Implementations**: Provides example scripts like `EnemyAI` and `PlayerController` to demonstrate how logging can be integrated into game scenarios.
- **Unit Testing**: Includes unit tests to verify that the logging mechanisms function correctly across various scenarios.

## Repository Structure

### TCS GameLogger Directory

This is the principal directory containing all source code and test cases for the logger.

#### Runtime

Contains core logging functionalities, including:

- **`GameLogger.cs`**: The primary static class responsible for logging game-related events. This class allows for direct, global access to all logging methods without the need for explicit instantiation. It provides methods such as `GameLogger.LogMessage()`, `GameLogger.LogWarningMessage()`, and `GameLogger.LogErrorMessage()`, and maintains a central repository for log entries to monitor recent events effectively.
- **`LogEntry.cs`**: Defines the individual log entries, specifying their properties and behaviors.
- **`Logger.cs`**: Manages individual logging operations and serves primarily as an internal utility used by `GameLogger` to facilitate the logging process.
- **`LoggerManager.cs`**: Oversees multiple loggers within the game, ensuring a centralized system that can accommodate the needs of different game components.
- **`Utils`**: Provides utility classes and helper functions that are employed throughout the logging system to enhance its versatility.
- **`TCS.GameLogger.asmdef`**: Unity Assembly Definition file that preserves the modularity and maintainability of runtime components.

#### Tests

Includes unit tests and example scripts that demonstrate how to utilize the logging framework effectively:

- **`EnemyAI.cs`**: Example script simulating enemy behavior, logging pertinent events to illustrate how logs can be integrated into game logic.
- **`ExampleLoggerUser.cs`**: Demonstrates fundamental use cases for logging within a Unity environment, serving as a tutorial for new users.
- **`LoggerManagerExample.cs`**: Illustrates the utilization of `LoggerManager` to handle multiple loggers concurrently.
- **`PlayerController.cs`**: Exemplifies the integration of the logger into player-related actions, showing how player events can be effectively logged.
- **`TCS.GameLogger.Tests.asmdef`**: Assembly Definition for the testing components, logically separating them from the runtime code for better maintainability.

## Installation

To integrate **TCS GameLogger** into your Unity project:

1. Clone or download the repository.
2. Copy the `TCS GameLogger` directory into your Unity project's `Assets` folder.
3. Ensure that you include the necessary assembly definitions to seamlessly integrate it into your existing project structure.

Alternatively, you can use the Unity Package Manager to reference the package directly, provided it is hosted on a supported registry.

## Getting Started

### Logging Events

Here's an example to quickly get you started with **TCS GameLogger**:

1. **Log Events**: Import the `GameLogger` class and use it directly in your game code.

   ```csharp
   using TCS.GameLogger;

   public class GameManager : MonoBehaviour
   {
       void Start()
       {
           // Example of logging a general message
           GameLogger.LogMessage("Game Started");
           
           // Example of logging a warning message
           GameLogger.LogWarningMessage("Low health detected");
           
           // Example of logging an error message
           GameLogger.LogErrorMessage("Critical error occurred");
           
           // Example of logging a debug message
           GameLogger.LogDebugMessage("Debugging initialization complete");
           
           // Example of logging a success message
           GameLogger.LogSuccessMessage("Player completed the level");
           
           // Example of logging an exception
           try
           {
               // Simulate some code that could throw an exception
               throw new System.Exception("Simulated exception");
           }
           catch (System.Exception ex)
           {
               GameLogger.LogException(ex);
           }
       }
   }
   ```

   The logger initializes automatically upon the first invocation of any log method, ensuring a straightforward and hassle-free setup process.

2. **Log Types**: Utilize `LogMessage()`, `LogWarningMessage()`, `LogErrorMessage()`, `LogDebugMessage()`, `LogSuccessMessage()`, and `LogException()` to record distinct types of events directly through the `GameLogger` class. Each log type includes visual enhancements for differentiating between information, warnings, errors, debugging messages, success confirmations, and exceptions.

## Examples

The repository includes example scripts such as `EnemyAI.cs` and `PlayerController.cs` to demonstrate how logging can be integrated into different components of game development. These examples are located in the `Tests` directory and are intended to help users understand the capabilities and flexibility of **TCS GameLogger**.

## Testing

The **Tests** directory contains scripts that function both as examples and as unit tests. These can be executed using Unity's Test Runner to verify the accuracy and reliability of the logging system across various game scenarios.

## Contributing

Contributions are highly encouraged! If you have suggestions for improvements or encounter any issues, please create an issue or submit a pull request. For significant modifications, we recommend initiating a discussion first to ensure alignment with the project's objectives.

Please refer to the `CODEOWNERS` file to determine code ownership and related responsibilities.

## License

This project is licensed under the MIT License. Please see the [LICENSE](LICENSE) file for full details.

## Contact

For any questions, please contact the repository owner or open an issue.

---

Thank you for using **TCS GameLogger**! We hope this utility makes your game development process smoother and debugging more efficient.
