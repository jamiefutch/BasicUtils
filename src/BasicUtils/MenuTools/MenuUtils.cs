#pragma warning disable CS1587 // XML comment is not placed on a valid language element
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
using System.Text.Json;

using BasicUtils;

namespace BasicUtils.MenuTools;

/// <summary>
/// utility class for managing and creating menus in the console
/// </summary>
public class MenuUtils : IDisposable
{
    /// <summary>
    /// menu list (items)
    /// </summary>
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
        if(menus.FindIndex(m => m.Id == menu.Id) == -1)
            menus.Add(menu);
        else
            $"menu id: {menu.Id}  not found".Print();
    }

    /// <summary>
    /// returns menu from menus list
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Menu GetMenu(string id)
    {
        var menu = menus.Find(m => m.Id == id);
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


    /// <summary>
    /// Releases all resources used by the <see cref="BasicUtils.MenuTools.MenuUtils"/> instance.
    /// </summary>
    /// <remarks>
    /// This method disposes of all menus in the <see cref="menus"/> list, clears the list, 
    /// and suppresses finalization of the object. It should be called when the instance 
    /// is no longer needed to free up resources.
    /// </remarks>
    public void Dispose()
    {
        if (menus != null)
        {
            foreach (var menu in menus) menu?.Dispose();

            menus.Clear();
            menus = null;
        }

        GC.SuppressFinalize(this);
    }
}