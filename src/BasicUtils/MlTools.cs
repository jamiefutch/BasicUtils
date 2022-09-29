using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUtils
{
    public class MlTools
    {
        public List<string> GetNgramsFromString(string text, int length)
        {
            var ngrams = new HashSet<string>();
            var arr = text.Split(' ');
            if(text.Length > 0)
            {
                for (int i = 0; i < arr.Length - length; i++ )
                {
                    for (int y = i; y <= (arr.Length - 1); y += length)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(arr[y]);
                        try
                        {
                            if (arr[y + 1].Length > 0)
                            {
                                sb.Append(", ");
                                sb.Append(arr[y + 1]);
                            }
                        }
                        catch (Exception e)
                        {
                            // outside the bounds of the array.
                            //  just ignore it
                        }
            
                        try
                        {
                            ngrams.Add(sb.ToString());
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