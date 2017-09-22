/**
 * $File: JCS_2DAnimPool.cs $
 * $Date: 2017-04-17 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2017 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JCSUnity
{

    /// <summary>
    /// Pool of 2d animation.
    /// </summary>
    public class JCS_2DAnimPool
        : MonoBehaviour
    {
        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        [Header("** Runtime Variables (JCS_AnimPool) **")]

        [Tooltip("Pool to randomly choose.")]
        [SerializeField]
        private JCS_2DAnimation[] mAnimPool = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Unity's function
        //------------------------------

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// Get a animation from the pool randomly.
        /// </summary>
        /// <returns> animation value. </returns>
        public JCS_2DAnimation GetRandomAnim()
        {
            if (mAnimPool.Length == 0)
                return null;

            int randIndex = JCS_Random.Range(0, mAnimPool.Length);

            return mAnimPool[randIndex];
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}