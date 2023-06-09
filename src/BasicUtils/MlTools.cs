using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUtils
{
    public static class MlTools
    {
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
    }
}