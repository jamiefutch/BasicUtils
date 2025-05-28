# BasicUtils

A few basic console and text utilities for .NET, useful for development and prototyping.

## Installationdotnet add package BasicUtilsor, using nuget...Install-Package BasicUtils


## Usage

### StringExtensions

Extension methods for string manipulation and console interaction:

Print(this string output, 
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)

PrintLine(this string output,
            bool showTimeStamp = true,
            ConsoleColor textColor = ConsoleColor.White)

PressAnyKey(this string prompt, 
            bool showTimeStamp = true)

Input(this string inputPrompt,
            bool showTimeStamp = false,
            ConsoleColor textColor = ConsoleColor.White)

RemovePunctuation(this string text,
            string replacement = "")

RemoveSymbols(this string text,
            string replacement = "")

RemoveNumbers(this string text,
            string replacement = "")### ConsoleExtensionsCacheForeColor()

CacheBgColor()

RestoreCachedForeColor()

RestoreCachedBgColor()

SetBgColor(ConsoleColor color)

SetForeColor(ConsoleColor color)### DateTimeExtensionsElapsedTime(this long ticks)

TimeFormatted(this Stopwatch sw)### LogFileWriteToLog(string LogPath, string LogMsg)### BasicUtils.ThreadingWaitAll(this IEnumerable<Thread> threads)### Menus// add namespace
using BasicUtils.Menus

// create menu
MenuUtils mu = new MenuUtils();
Menu menu  = new Menu();
menu.id = "1";
menu.menuHeader = "Select an option";
menu.menuFooter = "?\t";

// add menu item 1
MenuItem menuItem = new MenuItem();
menuItem.id = "1";
menuItem.title = "item 1";
menu.AddMenuItem(menuItem);

// add menu item 2
menuItem = new MenuItem();
menuItem.id = "2";
menuItem.title = "item 2";
menu.AddMenuItem(menuItem);

// save menu to file
mu.SaveMenusToFile("menus.txt");

// load menu from file
mu.LoadMenusFromFile("menus.txt");

// retrieve menu from menus (by id)
var m = mu.GetMenu("1");

// diplay menu and return user reponse
var response = m.DisplayMenu();
## Csv

The `Csv` class provides support for simple CSV operations.

### Public Methods

- `string[] LoadRawCsv(string path, bool hasHeader = true)`: This method loads the raw CSV file into a string array. If `hasHeader` is true, the first line is skipped.

- `Task<string[]> LoadRawCsvAsync(string path, bool hasHeader = true)`: This is the asynchronous version of the `LoadRawCsv` method.

- `List<string[]> Load(string path, char delimiter = ',', bool hasHeader = true)`: This method loads the CSV file into a list of string arrays. If `hasHeader` is true, the first line is skipped.

- `Task<List<string[]>> LoadAsync(string path, char delimiter = ',', bool hasHeader = true)`: This is the asynchronous version of the `Load` method.

- `void Save(string path, List<string[]> data, char delimiter = ',')`: This method saves a list of string arrays to a CSV file.

- `Task SaveAsync(string path, List<string[]> data, char delimiter = ',')`: This is the asynchronous version of the `Save` method.

- `string[] GetHeadersFromFile(string path, char delimiter = ',')`: This method returns the headers from a CSV file.

- `Task<string[]> GetHeadersFromFileAsync(string path, char delimiter = ',')`: This is the asynchronous version of the `GetHeadersFromFile` method.

- `string[] GetHeadersFromRawCsv(string[] csv, char delimiter = ',')`: This method returns the headers from a raw CSV string array.


## MlTools

### MlTools

Basic machine learning tools:

### Public Methods

- `List<string> GetNgramsFromString(string text, int length)`: This method generates a list of n-grams from a given string. The `text` parameter is the input string from which n-grams are to be generated, and the `length` parameter specifies the number of words in each n-gram.

- `Task<List<string>> GetNgramsFromStringAsync(string text, int length)`: This is the asynchronous version of the `GetNgramsFromString` method. It also generates a list of n-grams from a given string. The `text` parameter is the input string from which n-grams are to be generated, and the `length` parameter specifies the number of words in each n-gram.


## AppSettings

### AppSettings

Utility methods for loading settings from a JSON file:

### Public Methods

- `Dictionary<string,string> LoadSettings(string path)`: This method loads settings from a JSON file. The settings are returned as a dictionary where each key-value pair represents a setting. The `path` parameter specifies the path to the JSON file.

- `T LoadSettings<T>(string path, T settingsType)`: This is a generic method that loads settings from a JSON file. The settings are deserialized into an object of type `T`. The `path` parameter specifies the path to the JSON file, and the `settingsType` parameter is an instance of the `T` type that specifies the type to which the settings should be deserialized.


### Math

Fast modulo operation for large loops:

### LicenseThe MIT License ~(MIT)
Copyright Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.