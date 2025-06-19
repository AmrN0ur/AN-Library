# AN Library Documentation (Beta 1.2.0)

AN Library is a lightweight helper library for C# console applications, providing convenient functions for formatted output, colored text, input management, logging, exception handling, and system/environment information.

---

## Namespace

```csharp
namespace AN
```

---

## 📘 `class console`

A collection of static methods for improving console input/output experience.

### Properties

* `int ConsoleWidth`: Returns the current width of the console window.

### Methods

* `void Text(string text)` — Prints text prefixed with `== `.
* `void Text_1(string text)` — Prints text prefixed with `= `.
* `void TextHead(string text)` — Prints a centered heading with borders.
* `void ColoredText(string str, ConsoleColor textColor, ConsoleColor bgColor)` — Prints colored text.
* `string? Input(ConsoleColor textColor)` — Prompts for user input with specified text color.
* `string GetMultiLines()` — Accepts multiline input until the user types `@END`.
* `int GetOneOrTwo()` — Reads an integer input and ensures it's 1 or 2.
* `void Exit(bool exitConsole)` — Terminates the program (if flag is true).
* `void Error(string errorText)` — Displays error message in red.
* `void Warning(string warningText)` — Displays warning in dark yellow.
* `void Info(string infoMes)` — Displays info message in white.
* `void SuccessMessage(string successText)` — Displays success message in green.
* `string TextCentering(string text)` — Centers multi-line text in the console.
* `void Wait()` — Waits for key press.
* `bool CheckVarType(object var, Type expectedType)` — Type checker.

---

## 📘 `static class logger`

Handles logging to `logs.txt` file with 4 levels: Info, Warning, Error, Debug.

### Methods

* `void LogInfo(string message)`
* `void LogWarning(string message)`
* `void LogError(string message)`
* `void LogDebug(string message)`

Each method logs to the file and optionally prints using `console` methods.

---

## 📘 `static class exceptionHelper`

### Methods

* `void HandleException(Exception ex)` — Logs and prints exception.

---

## 📘 `static class SystemInfo`

Provides system-level information.

### Methods

* `string GetInfo()` — Returns OS name, machine name, user, CLR version.

### Nested Class: `SystemInfo.OS`

* `OSPlatform Platform()` — Returns current OS platform.

---

## 📘 `static class libraryInfo`

Basic metadata about the library.

### Methods

* `string AN_Library_Version()` — Returns version string.
* `string AN_Library_Info()` — Returns developer info.
* `bool IsWork()` — Returns `true` (a test method).

---

## Usage Example

```csharp
AN.console.Text("Hello World");
AN.console.ColoredText("Success", ConsoleColor.Green);
var userInput = AN.console.Input();
AN.logger.LogInfo("Program started");
```

---

## Requirements

* .NET Core / .NET Framework

---

## License

MIT (or as provided in the repository)

---

## Developed by

**Amr Nour**
📞 +20 102 967 1620
📍 Egypt
