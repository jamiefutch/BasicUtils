using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

using BasicUtils;

namespace BasicUtils.Menus
{
    public class MenuUtils : IDisposable
    {
        public List<Menu> menus { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public MenuUtils()
        {
            menus = new List<Menu>();
        }

        /// <summary>
        /// adds menu from menu list
        /// </summary>
        /// <param name="menu"></param>
        public void AddMenu(Menu menu)
        {
            if(menus.FindIndex(m => m.id == menu.id) == -1)
                menus.Add(menu);
            else
                $"menu id: {menu.id}  not found".Print();
        }

        /// <summary>
        /// returns menu from menus list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu GetMenu(string id)
        {
            var menu = menus.Find(m => m.id == id);
            return menu;
        }

        /// <summary>
        /// save menus to json
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveMenusToFile(string fileName)
        {
            var menusData = JsonSerializer.Serialize(menus);
            try
            {
                File.WriteAllText(fileName, menusData);
            }
            catch (Exception ex)
            {
                $"Error saving menus.\r\n{ex.Message}".Print();
            }            
        }

        /// <summary>
        /// loads menu data from json file
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadMenusFromFile(string fileName)
        {
            try
            {
                var menusData = File.ReadAllText(fileName);
                menus = JsonSerializer.Deserialize<List<Menu>>(menusData);
            }
            catch (Exception ex)
            {
                $"Error reading menus.\r\n{ex.Message}".Print();
            }
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
