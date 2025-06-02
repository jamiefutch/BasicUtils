# BasicUtils

A modern, modular collection of utility classes and extension methods for .NET 8 and .NET 9 projects.  
BasicUtils is designed to simplify common programming tasks such as string manipulation, console operations, CSV handling, object type checking, logging, and basic machine learning text processing.

---

## Project Organization

- - **BasicUtils**
  - `ConsoleTools` – Console color management (cache, restore, set).
  - `CsvTools` – Synchronous and asynchronous CSV file loading, saving, and header extraction.
  - `DateTimeTools` – Elapsed time and stopwatch formatting.
  - `LogTools` – Simple file-based logging with timestamped entries.
  - `MathTools` – Basic mathematical utilities for common operations.
  - `MenuTools` – Console menu creation and management utilities.
  - `MlTools` – Internal static list of common English stop words for text processing.
  - `ObjectsTools` – Type checking and type name utilities for .NET objects.
  - `SettingsTools` – Load application settings from JSON files into dictionaries or strongly-typed objects.
  - `StringsTools` – String manipulation, console output helpers, random string generation, and input utilities.
  - `ThreadingTools` – Basic threading utilities for task management and cancellation.


> **Note:** Obsolete methods (such as `MlTools.GetNgramsFromString`) are not documented here. Use the latest APIs in the `ML` namespace.

---

## Getting Started

1. **Add the project or source files to your .NET 8 or .NET 9 solution.**
2. **Reference the `BasicUtils` namespace in your code:**

## StringExtensions Usage

The `StringExtensions` class provides a variety of extension methods for string manipulation, console output, and utility operations.  
To use these methods, add `using BasicUtils;` to your file.

### Console Output
"Hello, World!".p(); // Prints to console without a line feed "Hello, World!".pl(); // Prints to console with a line feed
"Hello, World!".Print(); // Prints with timestamp (default) 
"Hello, World!".Print(showTimeStamp: false, textColor: ConsoleColor.Green); // Prints in green, no timestamp
"Hello, World!".PrintLine(); // Prints with line feed and timestamp (default) 
"Hello, World!".PrintLine(showTimeStamp: false); // Prints with line feed, no timestamp 
"Hello, World!".PrintLine(showTimeStamp: true, textColor: ConsoleColor.Yellow); // Prints in yellow with timestamp

### User Input
"Press any key to continue...".PressAnyKey(); // Shows prompt and waits for key press
string name = "Enter your name: ".PrintForInput(); // Prompts and reads user input

### String Cleaning
string cleaned = "Hello, 123!".RemoveNumbers(); // "Hello, !" 
string noPunct = "Hello, world!".RemovePunctuation(); // "Hello world" 
string noSymbols = "A+B=C!".RemoveSymbols(); // "ABC" 
string noTabs = "Hello\tWorld".RemoveTabs(); // "Hello World" 
string singleSpaced = "A   B   C".RemoveMultipleSpaces(); // "A B C"

### Stop Words
string filtered = "this is a test of the system".RemoveStopWords(); // "test system"

### String Utilities
string repeated = "abc".Repeat(3); // "abcabcabc"

### Random String Generation
// (Assuming you expose a public method for random string generation) 
string randomAlpha = StringExtensions.CreateRandomString(10, StringExtensions.RandomStringSettings.AlphaOnly); 
string randomAll = StringExtensions.CreateRandomString(16, StringExtensions.RandomStringSettings.AlphaNumericSpecialWithSpaces);

> **Note:** Some random string generation methods may be internal or obsolete; use the recommended public API.

---

**Tip:** All extension methods can be called directly on any string instance.