# TCS Game Logger

[![Join our Discord](https://img.shields.io/badge/Discord-Join%20Us-7289DA?logo=discord&logoColor=white)](https://discord.gg/knwtcq3N2a)
![Discord](https://img.shields.io/discord/1047781241010794506)
![GitHub Forks](https://img.shields.io/github/forks/Ddemon26/TCS-GameLogger)
![GitHub Contributors](https://img.shields.io/github/contributors/Ddemon26/TCS-GameLogger)
![GitHub Stars](https://img.shields.io/github/stars/Ddemon26/TCS-GameLogger)
![GitHub Repo Size](https://img.shields.io/github/repo-size/Ddemon26/TCS-GameLogger)

## Overview

TCS Game Logger is a versatile logging system designed for Unity-based games and applications. The system allows developers to efficiently log in-game events, user actions, and other critical information for debugging or analytic purposes. It supports multiple loggers, rich text formatting, and structured log entries, making it a powerful tool for game developers.

### Key Features

- **Multiple Loggers**: Support for managing different types of logs via the `LoggerManager`.
- **Rich Text Support**: Log entries can be formatted using Unity's rich text system, allowing color coding and formatting in the logs.
- **Flexible Logging**: Log any kind of event in the game such as player actions, enemy behaviors, or system errors.
- **Modular Design**: Separate components for handling log entries, logger management, and rich text formatting utilities.
- **Test Suite**: Includes example scripts and tests, such as `EnemyAI` and `PlayerController`, to demonstrate practical use cases.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/Ddemon26/TCS-GameLogger.git
    ```
2. Add the cloned repository to your Unity project's `Assets` folder.

3. Include the necessary assembly definition references in your project if required (e.g., `TCS.GameLogger.asmdef`).

## Usage

### Basic Logger Setup

1. **Initialize the Logger:**

   To begin logging, you can instantiate and use the `GameLogger` class:
    ```csharp
    using TCS.GameLogger;

    public class ExampleLoggerUser : MonoBehaviour {
        void Start() {
            GameLogger logger = new GameLogger();
            logger.Log("Game Started!");
        }
    }
    ```

2. **Logging with Rich Text Formatting:**

   You can format log entries using the rich text utilities provided:
    ```csharp
    using TCS.GameLogger.Utils;

    GameLogger logger = new GameLogger();
    string formattedText = RichTextExtensions.Colorize("Important Message", "#FF0000"); // Red text
    logger.Log(formattedText);
    ```

3. **Managing Multiple Loggers:**

   The `LoggerManager` allows you to handle multiple loggers for different subsystems in your game:
    ```csharp
    using TCS.GameLogger;

    LoggerManager loggerManager = new LoggerManager();
    loggerManager.AddLogger("AI", new GameLogger());
    loggerManager.AddLogger("Player", new GameLogger());

    loggerManager.GetLogger("AI").Log("Enemy AI Initialized");
    loggerManager.GetLogger("Player").Log("Player has entered the game");
    ```

## Examples

Several example scripts are included to demonstrate the usage of the logging system in real game scenarios:

- **Enemy AI Logger (`EnemyAI.cs`)**: Logs enemy behavior such as movement and attack patterns.
- **Player Controller Logger (`PlayerController.cs`)**: Logs player actions like movement, health changes, and interactions.
- **Logger Manager Example (`LoggerManagerExample.cs`)**: Demonstrates how to manage and use multiple loggers within your game.

## Contribution

Contributions to TCS Game Logger are welcome! Feel free to open issues, submit PRs, or join the [Discord community](https://discord.gg/knwtcq3N2a) to discuss new features or bug reports.

---

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.