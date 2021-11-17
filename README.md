# BasicUtils
--------
A few basic console and text utils that I use when developing / prototyping code.

## Source
[Github Repo](https://github.com/jamiefutch/BasicUtils)

## Nuget
[Nuget: BasicUtils](https://www.nuget.org/packages/BasicUtils/)

## Installation
```
dotnet add package BasicUtils
```
or, using nuget...
```
Install-Package BasicUtils
```

## Usage
--------
### StringExtensions
```
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
            string replacement = "")
```
### ConsoleExtensions
```
CacheForeColor()

CacheBgColor()

RestoreCachedForeColor()

RestoreCachedBgColor()

SetBgColor(ConsoleColor color)

SetForeColor(ConsoleColor color)
```
### DateTimeExtensions
```
ElapsedTime(this long ticks)
```
### LogFile
```
WriteToLog(string LogPath, string LogMsg)
```
### BasicUtils.Threading
```
WaitAll(this IEnumerable<Thread> threads)
```

### License
```
The MIT License ~(MIT)
Copyright © 2020 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```