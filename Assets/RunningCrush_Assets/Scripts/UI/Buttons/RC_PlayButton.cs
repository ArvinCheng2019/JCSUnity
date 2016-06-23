﻿/**
 * $File: RC_PlayButton.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information $
 *		                Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using JCSUnity;
using System;

public class RC_PlayButton 
    :  JCS_Button
{
    private JCS_2DSlideScreenCamera mSlideCamera = null;

    private void Awake()
    {
        // OPTIMIZE(JenChieh): if the game is too slow.
        //                  this can be one thing we need to optimize.
        mSlideCamera = GameObject.Find("JCS_2DSlideScreenCamera").GetComponent<JCS_2DSlideScreenCamera>();
    }

    public override void JCS_ButtonClick()
    {
        if (mSlideCamera == null)
        {
            JCS_GameErrors.JcsErrors(
                "RC_PlayButton", 
                -1, 
                "No JCS_2DSlideScreenCamera in the scene...");
            return;
        }

        // move top
        mSlideCamera.SwitchScene(JCS_2D4Direction.TOP);
    }
}
