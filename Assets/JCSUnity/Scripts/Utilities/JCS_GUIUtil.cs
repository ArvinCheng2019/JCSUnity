/**
 * $File: JCS_GUIUtil.cs $
 * $Date: 2018-07-16 13:28:22 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright © 2018 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JCSUnity
{
    /// <summary>
    /// Store all the GUI related utilities function here.
    /// </summary>
    public class JCS_GUIUtil
    {
        /// <summary>
        /// Returns item vlaue by index.
        /// </summary>
        /// <param name="dd"> Dropdown object. </param>
        /// <param name="index"> item name. </param>
        /// <returns></returns>
        public static string Dropdown_GetItemValue(Dropdown dd, int index)
        {
            return dd.options[index].text;
        }

        /// <summary>
        /// Get the current selected value of the Dropdown object.
        /// </summary>
        /// <param name="dd"> drop down object. </param>
        /// <returns> current selected text value. </returns>
        public static string Dropdown_GetSelectedValue(Dropdown dd)
        {
            return Dropdown_GetItemValue(dd, dd.value);
        }

        /// <summary>
        /// Return the index of item in the dropdown's item.
        /// If not found, return -1.
        /// </summary>
        /// <param name="dd"> Dropdown object. </param>
        /// <param name="itemName"> item name. </param>
        /// <returns>
        /// Index of the item value found.
        /// If not found, will returns -1.
        /// </returns>
        public static int Dropdown_GetItemIndex(Dropdown dd, string itemName)
        {
            for (int index = 0;
                index < dd.options.Count;
                ++index)
            {
                if (itemName == Dropdown_GetItemValue(dd, index))
                    return index;
            }

            return -1;
        }

        /// <summary>
        /// Set the value to the target item.
        /// </summary>
        /// <param name="dd"> dropdown object. </param>
        /// <param name="itemName"> name of the item. </param>
        /// <returns>
        /// true : found the item and set it succesfully.
        /// false : did not find the item, failed to set.
        /// </returns>
        public static bool Dropdown_SetSelection(Dropdown dd, string itemName)
        {
            int index = Dropdown_GetItemIndex(dd, itemName);

            // If not found, will return -1.
            if (index == -1)
                return false;

            dd.value = index;

            return true;
        }

        /// <summary>
        /// Set the selection to target index.
        /// </summary>
        /// <param name="dd"> dropdown object. </param>
        /// <param name="selection"> selection id. </param>
        public static void Dropdown_SetSelection(Dropdown dd, int selection)
        {
            dd.value = selection;
        }

        /// <summary>
        /// Refresh the current selection.
        /// </summary>
        /// <param name="dd"> dropdown object. </param>
        public static void Dropdown_RefreshSelection(Dropdown dd)
        {
            int currentSelectionId = dd.value;

            if (currentSelectionId != 0)
                Dropdown_SetSelection(dd, 0);
            else
            {
                // We use something else.
                // 
                // NOTE(jenchieh): Glady, negative one does not 
                // occurs error.
                Dropdown_SetSelection(dd, -1);
            }
            Dropdown_SetSelection(dd, currentSelectionId);
        }

        /// <summary>
        /// Add an option to dropdown.
        /// </summary>
        /// <param name="dd"> dropdown object. </param>
        /// <param name="inText"> input text. </param>
        /// <returns> Dropdown pointer. </returns>
        public static Dropdown Dropdown_AddOption(Dropdown dd, string inText)
        {
            dd.options.Add(
                new Dropdown.OptionData() { text = inText });

            return dd;
        }
    }
}
