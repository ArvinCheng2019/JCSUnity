/**
 * $File: JCS_ClimbableManager.cs $
 * $Date: 2017-05-16 19:49:31 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2017 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Manage all Climbable object in the scene. (Under Indie manager)
    /// </summary>
    public class JCS_ClimbableManager
        : MonoBehaviour
    {
        /* Variables */

        public static JCS_ClimbableManager instance = null;

        [Header("** Runtime Variables (JCS_ClimbableManager) **")]

        [Tooltip("Sorting order add up when climable interactable object is infront.")]
        [Range(0, 20)]
        public int SORTING_ORDER_INFRONT_OFFSET = 1;

        [Tooltip("Sorting order reduce up when climable interactable object is behind.")]
        [Range(0, 20)]
        public int SORTING_ORDER_BEHIND_OFFSET = 1;

        /* Setter & Getter */

        /* Functions */

        private void Awake()
        {
            instance = this;
        }
    }
}
