using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BasicUtils;

namespace BasicUtils.Menus
{
    public class Menu
    {
        public string id { get; set; }
        public string menuHeader { get; set; }
        public string menuFooter { get; set; }
        public List<MenuItem> menuItems { get; set; }

        public Menu()
        {
            menuHeader = string.Empty;
            menuFooter = string.Empty;
            menuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            if(menuItems.FindIndex(m => m.id == menuItem.id) == -1)
                menuItems.Add(menuItem);
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
            foreach (MenuItem item in menuItems)
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
            sb.Append(menuHeader);
            sb.Append("\r\n");
            foreach (MenuItem item in menuItems)
            {
                sb.Append(item.ToString());
                sb.Append("\r\n");
            }
            sb.Append(menuFooter);
            
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
            sb.Append(menuHeader);
            sb.Append("\r\n");
            foreach(MenuItem item in menuItems)
            {
                sb.Append(item.ToString());
                sb.Append("\r\n");
            }
            sb .Append(menuFooter);
            sb.Append("\r\n");
            return sb.ToString();
        }
    }
}
