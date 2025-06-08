# BasicUtils

A modern, modular collection of utility classes and extension methods for .NET 8 and .NET 9 projects.  
BasicUtils is designed to simplify common programming tasks such as string manipulation, console operations, CSV handling, object type checking, logging, and basic machine learning text processing.

---

## Project Organization

- **BasicUtils**
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
```
"Hello, World!".p(); // Prints to console without a line feed 
"Hello, World!".pl(); // Prints to console with a line feed
"Hello, World!".Print(); // Prints with timestamp (default) 
"Hello, World!".Print(showTimeStamp: false, textColor: ConsoleColor.Green); // Prints in green, no timestamp
"Hello, World!".PrintLine(); // Prints with line feed and timestamp (default) 
"Hello, World!".PrintLine(showTimeStamp: false); // Prints with line feed, no timestamp 
"Hello, World!".PrintLine(showTimeStamp: true, textColor: ConsoleColor.Yellow); // Prints in yellow with timestamp
```


### User Input
```
"Press any key to continue...".PressAnyKey(); // Shows prompt and waits for key press
string name = "Enter your name: ".PrintForInput(); // Prompts and reads user input
```

### String Cleaning
```
string cleaned = "Hello, 123!".RemoveNumbers(); // "Hello, !" 
string noPunct = "Hello, world!".RemovePunctuation(); // "Hello world" 
string noSymbols = "A+B=C!".RemoveSymbols(); // "ABC"
string noTabs = "Hello\tWorld".RemoveTabs(); // "Hello World" 
string singleSpaced = "A   B   C".RemoveMultipleSpaces(); // "A B C"
```

### Stop Words
`string filtered = "this is a test of the system".RemoveStopWords(); // "test system"`

### String Utilities
`string repeated = "abc".Repeat(3); // "abcabcabc"`

### Random String Generation
```
// (Assuming you expose a public method for random string generation) 
string randomAlpha = StringExtensions.CreateRandomString(10, StringExtensions.RandomStringSettings.AlphaOnly); 
string randomAll = StringExtensions.CreateRandomString(16, StringExtensions.RandomStringSettings.AlphaNumericSpecialWithSpaces);
```

> **Note:** Some random string generation methods may be internal or obsolete; use the recommended public API.

---

**Tip:** All extension methods can be called directly on any string instance.

---
## ConsoleTools Usage

The `ConsoleTools` class provides static methods for managing console foreground and background colors, allowing you to cache, restore, and set colors for improved console UI control.

To use these methods, add `using BasicUtils;` to your file.

### Color Management

```
// Cache the current foreground and background colors 
ConsoleTools.CacheForeColor(); 
ConsoleTools.CacheBgColor();

// Set new colors 
ConsoleTools.SetForeColor(ConsoleColor.Yellow); 
ConsoleTools.SetBgColor(ConsoleColor.DarkBlue);
// ... perform console output ...
// Restore the original colors 
ConsoleTools.RestoreCachedForeColor(); 
ConsoleTools.RestoreCachedBgColor();
```
---

**Tip:** These utilities help maintain consistent console appearance, especially when outputting colored text or building interactive console applications.

---

## CsvTools Usage

The `CsvTools` class provides methods for reading, writing, and processing CSV files, both synchronously and asynchronously.  
To use these methods, add `using BasicUtils;` to your file.

### Loading CSV Data
```
// Load all rows from a CSV file (as arrays of strings) 
var rows = CsvTools.Load("data.csv");

// Load CSV data with a custom delimiter and skip header 
var rowsNoHeader = CsvTools.Load("data.csv", delimiter: ';', hasHeader: false);

// Asynchronously load CSV data 
var rowsAsync = await CsvTools.LoadAsync("data.csv");
```


### Saving CSV Data
```
// Save a list of string arrays to a CSV file 
CsvTools.Save("output.csv", rows);

// Save with a custom delimiter 
CsvTools.Save("output.csv", rows, delimiter: ';');

// Asynchronously save CSV data await 
CsvTools.SaveAsync("output.csv", rows);
```

### Working with Raw CSV Lines
```
// Load raw lines from a CSV file (as strings) 
string[] lines = CsvTools.LoadRawCsv("data.csv");

// Asynchronously load raw lines 
string[] linesAsync = await CsvTools.LoadRawCsvAsync("data.csv");
```

### Extracting Headers
```
// Load raw lines from a CSV file (as strings) 
string[] lines = CsvTools.LoadRawCsv("data.csv");

// Asynchronously load raw lines 
string[] linesAsync = await CsvTools.LoadRawCsvAsync("data.csv");
```

```
// Get headers from a CSV file 
string[] headers = CsvTools.GetHeadersFromFile("data.csv");

// Asynchronously get headers 
string[] headersAsync = await 
CsvTools.GetHeadersFromFileAsync("data.csv");

// Get headers from a raw CSV string array 
string[] headersFromRaw = CsvTools.GetHeadersFromRawCsv(lines);
```

---

**Tip:**  
- All methods support custom delimiters (default is `,`).
- Asynchronous methods are ideal for large files or UI applications.
- Use `hasHeader: false` if your CSV does not include a header row.


---

## DateTimeTools Usage

The `DateTimeTools` class provides extension methods for formatting elapsed time and stopwatch durations, making it easy to display time intervals in a human-readable format.

To use these methods, add `using BasicUtils;` to your file.

### Formatting Elapsed Time

```
long ticks = 1234567890; string elapsed = ticks.ElapsedTime(); // "00:20:34:56" (HH:MM:SS:MS)
```


### Formatting Stopwatch Durations
```
var sw = new System.Diagnostics.Stopwatch(); 
sw.Start(); 

// ... perform some work ... 

sw.Stop(); 
string formatted = sw.TimeFormatted(); // "00:00:01:23" (HH:MM:SS:MS)
```

---

**Tip:**  
- These methods are useful for logging, benchmarking, and displaying durations in console or UI applications.
- The format is always `"HH:MM:SS:MS"` for consistency.

--- 
## LogTools Usage

The `LogTools` class provides simple file-based logging functionality, allowing you to write timestamped log entries to text files for diagnostics, auditing, or general application logging.

To use these methods, add `using BasicUtils;` to your file.

### Writing Log Entries

```
LogTools.WriteToLog(@"C:\Logs", "Application started."); 
LogTools.WriteToLog(@"C:\Logs", $"Error occurred at {DateTime.Now}: {ex.Message}");
```

- Each log entry is written to a file named with the current date (e.g., `06082025.txt`) in the specified directory.
- Entries are separated by a line of equal signs and include a timestamp for each message.
- If the log file does not exist, it is created automatically; otherwise, entries are appended.

**Tip:**  
- Use a dedicated log directory to keep your log files organized.
- LogTools is ideal for lightweight logging needs in console and utility applications.

---

## MenuTools Usage

The `MenuTools` class provides utilities for creating and managing interactive console menus, making it easy to build user-friendly command-line interfaces.

To use these methods, add `using BasicUtils;` to your file.

### Example Usage
```
// Define menu options 
var options = new List<string> { "Option 1", "Option 2", "Option 3", "Exit" };

// Display a simple menu and get the user's selection 
int selectedIndex = MenuTools.ShowMenu("Main Menu", options);

// Act on the user's choice 
switch (selectedIndex) 
{ 
	case 0: 
		// Handle Option 1 
		break; 
	case 1: 
		// Handle Option 2 
		break; 
	case 2: 
		// Handle Option 3 
		break; 
	case 3: 
		// Exit 
		break; 
}
```
---

**Tip:**  
- MenuTools helps you quickly build navigable console menus for scripts, utilities, and interactive applications.
- You can customize menu prompts, handle user input, and extend menu logic as needed.

---

## MlTools Usage

The `MlTools` class provides a static list of common English stop words for use in text processing and natural language applications.  
This is useful for filtering out non-informative words when performing tasks such as tokenization, keyword extraction, or building machine learning models.

To use these methods, add `using BasicUtils;` to your file.

### Accessing the Stop Words List

```
var stopWords = MlTools.StopWordsList; 
if (stopWords.Contains("the")) { // "the" is a stop word }
```


### Example: Removing Stop Words from Text

```
var words = "this is a test of the system".Split(' '); 
var filtered = words.Where(word => !MlTools.StopWordsList.Contains(word)); 
string result = string.Join(" ", filtered); // "test system"
```


**Tip:**  
- The stop words list is provided as a static string array for fast lookups.
- Use this list to improve the quality of text analysis, search, and machine learning features by ignoring common words.

---

## ObjectsTools Usage

The `ObjectsTools` class provides utility methods for type checking and type name detection, making it easy to determine the type of an object at runtime and perform robust type validation.

To use these methods, add `using BasicUtils;` to your file.

### Type Checking and Type Name Detection

```
// Determine the type name of an object 
string typeName = ObjectsTools.GetTypeName(123.45); // "double"

// Check if an object is a specific type 
bool isInt = ObjectsTools.IsInt("123");         

bool isLong = ObjectsTools.IsLong(123L);        

bool isDouble = ObjectsTools.IsDouble("3.14");  

bool isFloat = ObjectsTools.IsFloat(1.23f);     

bool isDecimal = ObjectsTools.IsDecimal("9.99");

bool isDateTime = ObjectsTools.IsDateTime("2025-06-08"); 

bool isBool = ObjectsTools.IsBool(true);        

bool isChar = ObjectsTools.IsChar('A');         

bool isString = ObjectsTools.IsString("hello"); 

bool isCurrency = ObjectsTools.IsCurrency("$12.34"); 
```


**Tip:**  
- These methods are useful for dynamic data validation, parsing, and runtime type analysis.
- All methods are static and can be called directly from the class.
- `GetTypeName` returns a string such as `"int"`, `"double"`, `"DateTime"`, or `"unknown"` for unrecognized types.

---

## SettingsTools Usage

The `SettingsTools` class provides methods for loading application settings from JSON files into dictionaries or strongly-typed objects, making configuration management simple and robust.

To use these methods, add `using BasicUtils;` to your file.

### Loading Settings as a Dictionary

```
// Load settings from a JSON file into a dictionary 
var settings = SettingsTools.LoadSettings("appsettings.json"); 
string apiKey = settings["ApiKey"];
```


### Loading Settings as a Strongly-Typed Object

```
// Define a settings class 

public class MySettings 
{ public string ApiKey { get; set; } public int Timeout { get; set; } }

// Load settings from a JSON file into a strongly-typed object 

var mySettings = SettingsTools.LoadSettings<MySettings>("appsettings.json"); 
string apiKey = mySettings.ApiKey; 
int timeout = mySettings.Timeout;
```
---

**Tip:**  
- Use strongly-typed objects for compile-time safety and IntelliSense support.
- Use the dictionary approach for dynamic or loosely-typed configuration scenarios.
- The JSON file should be well-formed and match the structure of your settings class if using strong typing.
- Don't be a moron and store credintials in these settings

---

## MathTools Usage

## GenerateShuffledArray Usage

The `GenerateShuffledArray` method in `MathUtils` creates an array of random integers within a specified range, with options for the number of values and whether duplicates are allowed.

To use this method, add `using BasicUtils.MathTools;` to your file and create an instance of `MathUtils`.

### Method Signature
```
public int[] GenerateShuffledArray( int minValue = 0, int maxValue = 1, int count = 1, bool allowDuplicates = false)
```


### Parameters

- `minValue` (int): The minimum value (inclusive) for generated numbers.
- `maxValue` (int): The maximum value (inclusive) for generated numbers.
- `count` (int): The number of integers to generate.
- `allowDuplicates` (bool): If `true`, duplicate values are allowed; if `false`, all values are unique.

### Returns

- An array of shuffled integers according to the specified parameters.

### Exceptions

- `ArgumentException` if:
  - `minValue` is greater than `maxValue`
  - `count` is negative
  - `count` exceeds the number of unique values in the range when `allowDuplicates` is `false`

### Example Usage
```csharp
using BasicUtils.MathTools;
var mathUtils = new MathUtils();
// Generate 5 unique random numbers between 1 and 10 int[] uniqueNumbers = mathUtils.GenerateShuffledArray(1, 10, 5, false);
// Generate 8 random numbers between 0 and 3, allowing duplicates int[] numbersWithDuplicates = mathUtils.GenerateShuffledArray(0, 3, 8, true);
```

---

**Tip:**  
- Use `allowDuplicates: false` to ensure all values are unique.
- For large ranges or counts, consider performance and exception handling.
