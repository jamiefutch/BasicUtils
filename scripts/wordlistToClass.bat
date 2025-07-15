@echo off
setlocal enabledelayedexpansion

REM -- Name of input text file
set "INPUT=C:\projects\cloned\google-10000-english\google-10000-english-usa.txt"
REM -- Name of output C# file
set "OUTPUT=WordsList.cs"
REM -- Name of class
set "CLASSNAME=WordsList"


Echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
Echo Building Class File
Echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
Echo

REM -- Start writing the class
echo using System;> "%OUTPUT%"
echo >> "%OUTPUT%"
echo public static class %CLASSNAME% >> "%OUTPUT%"
echo {>> "%OUTPUT%"
echo     public static readonly string[] Words = new string[] {>> "%OUTPUT%"

REM -- Read the input file and build the array
REM -- For each line in the input file
for /f "usebackq delims=" %%A in ("%INPUT%") do (
    set "line=%%A"
    REM -- Split line into words
    for %%W in (!line!) do (
        echo         "%%W",>> "%OUTPUT%"
    )
)

REM -- Remove the last comma
REM -- (Optional: you can use a more advanced script to avoid trailing comma)

REM -- Finish the array and class
echo     };>> "%OUTPUT%"
echo }>> "%OUTPUT%"

echo Done. Output written to %OUTPUT%