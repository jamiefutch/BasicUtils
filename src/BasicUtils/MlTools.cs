﻿/** 
The MIT License (MIT)
Copyright © 2024 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUtils
{
    /// <summary>
    /// some basic machine learning tools
    /// </summary>
    public static class MlTools
    {
        /// <summary>
        /// gets ngrams from a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static List<string> GetNgramsFromString(string text, int length)
        {
            text = text.RemovePunctuation().RemoveSymbols().RemoveMultipleSpaces().Trim();
            var ngrams = new HashSet<string>();
            var arr = text.Split(' ');
            if(text.Length > 0)
            {
                for (int i = 0; i < arr.Length -1 ; i++ )
                {
                    for (int y = i; y <= (arr.Length - 1); y++ )
                    {
                        StringBuilder sb = new StringBuilder();
                        if (y + (length) <= arr.Length)
                        {
                            sb.Append(arr[y]);
                            {
                                if (length > 1)
                                {
                                    for (int j = 1; j <= length - 1; j++)
                                    {
                                        if ((y + j) < arr.Length)
                                        {
                                            sb.Append("|");
                                            sb.Append(arr[y + j]);    
                                        }
                                    }
                                }    
                            }
                        }
                        try
                        {
                            if (sb.Length > 0)
                            {
                                ngrams.Add(sb.ToString());    
                            }
                        }
                        catch (Exception e)
                        {
                            // this means a duplicate was found.  
                            //  so, do nothing 
                        }
                    }
                }
            }
            return ngrams.Count > 0 ? ngrams.ToList<string>()
                    : new List<string>();
        }
        
        /// <summary>
        /// async gets ngrams from a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static async Task<List<string>> GetNgramsFromStringAsync(string text, int length)
        {
            return await Task.Run(() =>
            {
                text = text.RemovePunctuation().RemoveSymbols().RemoveMultipleSpaces().Trim();
                var ngrams = new HashSet<string>();
                var arr = text.Split(' ');
                if (text.Length > 0)
                {
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        for (int y = i; y <= (arr.Length - 1); y++)
                        {
                            StringBuilder sb = new StringBuilder();
                            if (y + (length) <= arr.Length)
                            {
                                sb.Append(arr[y]);
                                {
                                    if (length > 1)
                                    {
                                        for (int j = 1; j <= length - 1; j++)
                                        {
                                            if ((y + j) < arr.Length)
                                            {
                                                sb.Append("|");
                                                sb.Append(arr[y + j]);
                                            }
                                        }
                                    }
                                }
                            }
                            try
                            {
                                if (sb.Length > 0)
                                {
                                    ngrams.Add(sb.ToString());
                                }
                            }
                            catch (Exception e)
                            {
                                // this means a duplicate was found.  
                                //  so, do nothing 
                            }
                        }
                    }
                }
                return ngrams.Count > 0 ? ngrams.ToList<string>()
                        : new List<string>();
            });
        }
    }
}