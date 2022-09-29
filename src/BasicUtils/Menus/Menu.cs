using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BasicUtils;

namespace BasicUtils.Menus
{
    public class Menu
    {
        public string Id { get; set; }
        public string MenuHeader { get; set; }
        public string MenuFooter { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public Menu()
        {
            MenuHeader = string.Empty;
            MenuFooter = string.Empty;
            MenuItems = new List<MenuItem>();
        }

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
