﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using BasicUtils;

var sentence = "i am sorry but i did not like it nor will i wear it as it is too big  looks funny on me";
sentence = sentence.RemoveMultipleSpaces().RemoveSymbols();


var ngrams = MlTools.GetNgramsFromString(sentence,3);
var ngrams2 = MlTools.GetNgramsFromString2(sentence, 3);

// display ngrams
Console.WriteLine("Ngrams:");
Console.WriteLine("---------------------------");
foreach(string n in ngrams)
    Console.WriteLine(n);
Console.WriteLine("---------------------------");
Console.WriteLine("---------------------------");

// display ngrams
Console.WriteLine("Ngrams2:");
Console.WriteLine("---------------------------");
foreach (string n in ngrams2)
    Console.WriteLine(n);
Console.WriteLine("---------------------------");
Console.WriteLine("---------------------------");

// display stop words removed
Console.WriteLine("Stop Words:");
Console.WriteLine("---------------------------");

var sentenceWithoutStopwords = sentence.RemoveStopWords();
Console.WriteLine(sentenceWithoutStopwords);

Console.WriteLine("---------------------------");
Console.WriteLine("Press Any Key To End");
Console.WriteLine("---------------------------");
Console.ReadKey();
    