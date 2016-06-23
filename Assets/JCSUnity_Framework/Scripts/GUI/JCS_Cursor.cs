﻿/**
 * $File: JCS_Cursor.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information $
 *		                Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;


namespace JCSUnity
{

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class JCS_Cursor
        : MonoBehaviour
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables

        private SpriteRenderer mSpriteRenderer = null;
        private Animator mAnimator = null;

        [Header("** Runtime Variables **")]
        [Tooltip("Show the cursor or not.")]
        [SerializeField] private bool mShowCursor = false;
        [Tooltip("Since is the 3D cursor, set where the cursor u want this to be.")]
        [SerializeField] private float mDepth = 5.0f;
        [Tooltip("Recommand that set this very hight so no object can block the cursor.")]
        [SerializeField] private int mOrderLayer = 100;

        [Header("** Animation Settings **")]
        [SerializeField] private JCS_CursorCustomizeType mAnimState = JCS_CursorCustomizeType.NORMAL_SELECT;
        [SerializeField] private RuntimeAnimatorController mNormalSelect = null;
        [SerializeField] private RuntimeAnimatorController mHelpSelect = null;
        [SerializeField] private RuntimeAnimatorController mWorkingInBackground = null;
        [SerializeField] private RuntimeAnimatorController mBusy = null;
        [SerializeField] private RuntimeAnimatorController mPrecisionSelect = null;
        [SerializeField] private RuntimeAnimatorController mTextSelect = null;
        [SerializeField] private RuntimeAnimatorController mHandwriting = null;
        [SerializeField] private RuntimeAnimatorController mUnavaliable = null;
        [SerializeField] private RuntimeAnimatorController mVerticalResize = null;
        [SerializeField] private RuntimeAnimatorController mHorizontalResize = null;
        [SerializeField] private RuntimeAnimatorController mDiagonalResize1 = null;
        [SerializeField] private RuntimeAnimatorController mDiagonalResize2 = null;
        [SerializeField] private RuntimeAnimatorController mMove = null;
        [SerializeField] private RuntimeAnimatorController mAlternateSelect = null;
        [SerializeField] private RuntimeAnimatorController mLinkSelect = null;

        [Header("** Other Settings **")]
        [Tooltip("If the art team do stuff correctly, no need to use this.")]
        [SerializeField] private bool mDoOffset = false;
        [Tooltip("Will cut the image in halft and pivot to top left.")]
        [SerializeField] private Vector2 mOffset = Vector2.zero;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            this.mSpriteRenderer = this.GetComponent<SpriteRenderer>();
            this.mAnimator = this.GetComponent<Animator>();

            Vector2 cursorRect = JCS_UsefualFunctions.GetSpriteRendererRect(mSpriteRenderer);
            mOffset.x = cursorRect.x / 2.0f;
            mOffset.y = cursorRect.y / 2.0f;

            mSpriteRenderer.sortingOrder = mOrderLayer;

#if (UNITY_EDITOR)
            mShowCursor = true;
#endif
        }

        private void LateUpdate()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 mousePos2d = new Vector3(mousePos.x, mousePos.y, mDepth);

            Camera cam = JCS_Camera.main.GetCamera();
            Vector3 mousePos3d = cam.ScreenToWorldPoint(mousePos2d);

            if (mDoOffset)
            {
                mousePos3d.x += mOffset.x;
                mousePos3d.y -= mOffset.y;
            }

            this.transform.position = mousePos3d;
            
            
        }
        private void OnApplicationFocus(bool focusStatus)
        {
            // when get focus do check to not show the cursor
            if (focusStatus)
            {
                Cursor.visible = mShowCursor;
            }
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions
        public void SwitchState(JCS_CursorCustomizeType type)
        {
            RuntimeAnimatorController anim = null;

            bool notFound = false;

            switch (type)
            {
                case JCS_CursorCustomizeType.NORMAL_SELECT:
                    {
                        if (mNormalSelect == null)
                            notFound = true;

                        anim = mNormalSelect;
                    }
                    break;
                case JCS_CursorCustomizeType.HELP_SELECT:
                    {
                        if (mHelpSelect == null)
                            notFound = true;

                        anim = mHelpSelect;
                    }
                    break;
                case JCS_CursorCustomizeType.WORKING_IN_BACKGROUND:
                    {
                        if (mWorkingInBackground == null)
                            notFound = true;

                        anim = mWorkingInBackground;
                    }
                    break;
                case JCS_CursorCustomizeType.BUSY:
                    {
                        if (mBusy == null)
                            notFound = true;

                        anim = mBusy;
                    }
                    break;
                case JCS_CursorCustomizeType.PRECISION_SELECT:
                    {
                        if (mPrecisionSelect == null)
                            notFound = true;

                        anim = mPrecisionSelect;
                    }
                    break;
                case JCS_CursorCustomizeType.TEXT_SELECT:
                    {
                        if (mTextSelect == null)
                            notFound = true;

                        anim = mTextSelect;
                    }
                    break;
                case JCS_CursorCustomizeType.HANDWRITING:
                    {
                        if (mHandwriting == null)
                            notFound = true;

                        anim = mHandwriting;
                    }
                    break;
                case JCS_CursorCustomizeType.UNAVAILABLE:
                    {
                        if (mUnavaliable == null)
                            notFound = true;

                        anim = mUnavaliable;
                    }
                    break;
                case JCS_CursorCustomizeType.VERTICAL_RESIZE:
                    {
                        if (mVerticalResize == null)
                            notFound = true;

                        anim = mVerticalResize;
                    }
                    break;
                case JCS_CursorCustomizeType.HORIZONTAL_RESIZE:
                    {
                        if (mHorizontalResize == null)
                            notFound = true;

                        anim = mHorizontalResize;
                    }
                    break;
                case JCS_CursorCustomizeType.DIAGONAL_RESIZE_1:
                    {
                        if (mDiagonalResize1 == null)
                            notFound = true;

                        anim = mDiagonalResize1;
                    }
                    break;
                case JCS_CursorCustomizeType.DIAGONAL_RESIZE_2:
                    {
                        if (mDiagonalResize2 == null)
                            notFound = true;

                        anim = mDiagonalResize2;
                    }
                    break;
                case JCS_CursorCustomizeType.MOVE:
                    {
                        if (mMove == null)
                            notFound = true;

                        anim = mMove;
                    }
                    break;
                case JCS_CursorCustomizeType.ALTERNATE_SELECT:
                    {
                        if (mAlternateSelect == null)
                            notFound = true;

                        anim = mAlternateSelect;
                    }
                    break;
                case JCS_CursorCustomizeType.LINK_SELECT:
                    {
                        if (mNormalSelect == null)
                            notFound = true;

                        anim = mLinkSelect;
                    }
                    break;

            }

            if (notFound)
            {
                JCS_GameErrors.JcsErrors(
                                "JCS_Cursor",
                                -1,
                                type.ToString() +  " animation does not assign...");
            }

            // set animation
            mAnimator.runtimeAnimatorController = anim;
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
