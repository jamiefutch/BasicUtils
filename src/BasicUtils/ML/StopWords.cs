#pragma warning disable CS1587 // XML comment is not placed on a valid language element
/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

*** Some Parts of the stop words list is derrived from: 

MIT License

Copyright (c) 2018 .NET Foundation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 
**/

using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicUtils
{
    /// <summary>
    /// Provides a static list of common English stop words for use in text processing and natural language applications.
    /// </summary>
    /// <remarks>
    /// The stop words list is initialized from a combination of sources, including portions derived from the .NET Foundation under the MIT License.
    /// This class is intended for internal use and exposes the <see cref="StopWordsList"/> array for filtering or removing stop words from text.
    /// </remarks>
    public class StopWords : IDisposable
    {
    
        /// <summary>
        /// An array of common English stop words.
        /// </summary>
        public static string[] StopWordsList;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StopWords"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the <see cref="StopWordsList"/> array by invoking the internal method <c>BuildStopWordsList</c>.
        /// </remarks>
        public StopWords()
        {
            StopWordsList = BuildStopWordsList();
        }

        /// <summary>
        /// Retrieves the list of common English stop words.
        /// </summary>
        /// <returns>
        /// An array of strings containing the stop words.
        /// </returns>
        /// <remarks>
        /// This method provides access to the static <see cref="StopWordsList"/> array, 
        /// which is initialized during the construction of the <see cref="StopWords"/> instance.
        /// </remarks>
        public string[] GetStopWordsList()
        {
            return StopWordsList;
        }


        /// <summary>
        /// Builds and returns the array of stop words used by <see cref="StopWordsList"/>.
        /// </summary>
        /// <returns>
        /// An array of strings containing common English stop words.
        /// </returns>
        private static string[] BuildStopWordsList()
        {       
            var sw = new[]
            {   
                "a",
                "about",
                "above",
                "above",
                "across",
                "after",
                "afterwards",
                "again",
                "against",
                "all",
                "almost",
                "alone",
                "along",
                "already",
                "also",
                "although",
                "always",
                "am",
                "among",
                "amongst",
                "amount",
                "an",
                "and",
                "another",
                "any",
                "anyhow",
                "anyone",
                "anything",
                "anyway",
                "anywhere",
                "are",
                "around",
                "as",
                "at",
                "back",
                "be",
                "became",
                "because",
                "become",
                "becomes",
                "becoming",
                "been",
                "before",
                "beforehand",
                "behind",
                "being",
                "below",
                "beside",
                "besides",
                "between",
                "beyond",
                "both",
                "bottom",
                "but",
                "by",
                "call",
                "can",
                "cannot",
                "cant",
                "co",
                "con",
                "could",
                "couldnt",
                "couldn\'t",
                "cry",
                "de",
                "describe",
                "detail",
                "do",
                "done",
                "down",
                "due",
                "during",
                "each",
                "eg",
                "eight",
                "either",
                "eleven",
                "else",
                "elsewhere",
                "empty",
                "enough",
                "etc",
                "even",
                "ever",
                "every",
                "everyone",
                "everything",
                "everywhere",
                "except",
                "few",
                "fifteen",
                "fify",
                "fifty",
                "fill",
                "find",
                "fire",
                "first",
                "five",
                "for",
                "former",
                "formerly",
                "forty",
                "found",
                "four",
                "from",
                "front",
                "full",
                "further",
                "get",
                "give",
                "go",
                "had",
                "has",
                "hasnt",
                "hasn\'t",
                "have",
                "he",
                "hence",
                "her",
                "here",
                "hereafter",
                "hereby",
                "herein",
                "hereupon",
                "hers",
                "herself",
                "him",
                "himself",
                "his",
                "how",
                "however",
                "hundred",
                "ie",
                "if",
                "in",
                "inc",
                "indeed",
                "interest",
                "into",
                "is",
                "it",
                "its",
                "itself",
                "keep",
                "last",
                "latter",
                "latterly",
                "least",
                "less",
                "ltd",
                "made",
                "many",
                "may",
                "me",
                "meanwhile",
                "might",
                "mill",
                "mine",
                "more",
                "moreover",
                "most",
                "mostly",
                "move",
                "much",
                "must",
                "my",
                "myself",
                "name",
                "namely",
                "neither",
                "never",
                "nevertheless",
                "next",
                "nine",
                "no",
                "nobody",
                "none",
                "noone",
                "nor",
                "not",
                "nothing",
                "now",
                "nowhere",
                "of",
                "off",
                "often",
                "on",
                "once",
                "one",
                "only",
                "onto",
                "or",
                "other",
                "others",
                "otherwise",
                "our",
                "ours",
                "ourselves",
                "out",
                "over",
                "own",
                "part",
                "per",
                "perhaps",
                "please",
                "put",
                "rather",
                "re",
                "same",
                "see",
                "seem", 
                "seemed",
                "seeming",
                "seems",
                "serious",
                "several",
                "she",
                "should",
                "show",
                "side",
                "since",
                "sincere",
                "six",
                "sixty",
                "so",
                "some",
                "somehow",
                "someone",
                "something",
                "sometime",
                "sometimes",
                "somewhere",
                "still",
                "such",
                "system",
                "take",
                "ten",
                "than",
                "that",
                "the",
                "their",
                "them",
                "themselves",
                "then",
                "thence",
                "there",
                "thereafter",
                "thereby",
                "therefore",
                "therein",
                "thereupon",
                "these",
                "they",
                "thick",
                "thin",
                "third",
                "this",
                "those",
                "though",
                "three",
                "through",
                "throughout",
                "thru",
                "thus",
                "to",
                "together",
                "too",
                "top",
                "toward",
                "towards",
                "twelve",
                "twenty",
                "two",
                "un",
                "under",
                "until",
                "up",
                "upon",
                "us",
                "very",
                "via",
                "was",
                "we",
                "well",
                "were",
                "what",
                "whatever",
                "when",
                "whence",
                "whenever",
                "where",
                "whereafter",
                "whereas",
                "whereby",
                "wherein",
                "whereupon",
                "wherever",
                "whether",
                "which",
                "while",
                "whither",
                "who",
                "whoever",
                "whole",
                "whom",
                "whose",
                "why",
                "will",
                "with",
                "within",
                "without",
                "would"
            };
            return sw.ToArray();
        }

        /// <summary>
        /// Disposes of the <see cref="StopWords"/> instance, releasing any resources if necessary.
        /// </summary>
        public void Dispose()
        {
            StopWordsList = null; // Clear the stop words list to free memory
        }
    }           
}               