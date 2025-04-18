/** 
The MIT License (MIT)
Copyright © 2025 Jamie Futch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BasicUtils;

namespace BasicUtils.Menus
{
    /// <summary>
    /// menus class, contains multiple menus
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// /// menu id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// menu header
        /// </summary>
        public string MenuHeader { get; set; }

        /// <summary>
        /// /// menu footer
        /// </summary>
        public string MenuFooter { get; set; }
        
        /// <summary>
        /// menu items
        /// </summary>
        public List<MenuItem> MenuItems { get; set; }

        /// <summary>
        /// menu constructor
        /// </summary>
        public Menu()
        {
            MenuHeader = string.Empty;
            MenuFooter = string.Empty;
            MenuItems = new List<MenuItem>();
        }

        /// <summary>
        /// adds menu item to menu
        /// </summary>
        /// <param name="menuItem"></param>
        public void AddMenuItem(MenuItem menuItem)
        {
            if(MenuItems.FindIndex(m => m.id == menuItem.id) == -1)
                MenuItems.Add(menuItem);
            else
                $"Menu item with id:\t{menuItem.id} already exists".Print();

        }

        /// <summary>
        /// returns the menu items (only) as a string
        /// </summary>
        /// <returns></returns>
        public string ListMenuItems()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MenuItem item in MenuItems)
            {
                sb.Append(item.ToString());
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

        
        /// <summary>
        /// display menu and return user response
        /// </summary>
        /// <param name="includeNewLineAfterPrompt"></param>
        /// <returns></returns>
        public string DisplayMenu(bool includeNewLineAfterPrompt = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(MenuHeader);
            sb.Append("\r\n");
            foreach (MenuItem item in MenuItems)
            {
                sb.Append(item.ToString());
                sb.Append("\r\n");
            }
            sb.Append(MenuFooter);
            
            if(includeNewLineAfterPrompt)
                sb.Append("\r\n");

            Console.Write(sb.ToString());
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// returns the complete menu as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(MenuHeader);
            sb.Append("\r\n");
            foreach(MenuItem item in MenuItems)
            {
                sb.Append(item.ToString());
                sb.Append("\r\n");
            }
            sb .Append(MenuFooter);
            sb.Append("\r\n");
            return sb.ToString();
        }
    }
}
