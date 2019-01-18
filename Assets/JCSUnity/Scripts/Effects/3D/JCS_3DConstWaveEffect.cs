/**
 * $File: JCS_3DConstWaveEffect.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;


namespace JCSUnity
{
    /// <summary>
    /// Effect that does constant wave.
    /// </summary>
    public class JCS_3DConstWaveEffect
        : JCS_UnityObject
    {
        /*******************************************/
        /*            Public Variables             */
        /*******************************************/

        /*******************************************/
        /*           Private Variables             */
        /*******************************************/

        [Header("** Runtime Varialbes (JCS_3DConstWaveEffect) **")]

        [Tooltip("Transform type to apply effect with.")]
        [SerializeField]
        private JCS_TransformType mTransformType = JCS_TransformType.POSITION;

        [Tooltip("Effect local position/eulerAngles instead of global one?")]
        [SerializeField]
        private bool mEffectLocal = false;

        [Tooltip("as play on awake!")]
        [SerializeField]
        private bool mEffect = false;

        [Tooltip("How much force goes up and down.")]
        [SerializeField]
        private float mAmplitude = 0.1f;

        [Tooltip("How fast the wave move up and down.")]
        [SerializeField]
        private float mFrequency = 2.0f;

        // time to run the sine/cosine wave.
        private float mTime = 0.0f;

        [Tooltip("Effect on which axis.")]
        [SerializeField]
        private JCS_Axis mAxis = JCS_Axis.AXIS_Y;


        [Header("- Randomize Setting (JCS_3DConstWaveEffect)")]

        [Tooltip("Randomize a bit the amplitude value at start.")]
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float mRandomizeAmplitudeAtStart = 0.0f;

        [Tooltip("Randomize a bit the frequency value at start.")]
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float mRandomizeFrequencyAtStart = 0.0f;

        /*******************************************/
        /*           Protected Variables           */
        /*******************************************/

        /*******************************************/
        /*             setter / getter             */
        /*******************************************/
        public bool Effect { get { return this.mEffect; } set { this.mEffect = value; } }
        public bool EffectLocal { get { return this.mEffectLocal; } set { this.mEffectLocal = value; } }
        public float Amplitude { get { return this.mAmplitude; } set { this.mAmplitude = value; } }
        public float Frequency { get { return this.mFrequency; } set { this.mFrequency = value; } }
        public JCS_Axis Axis { get { return this.mAxis; } set { this.mAxis = value; } }
        public JCS_TransformType TransformType { get { return this.mTransformType; } set { this.mTransformType = value; } }

        public float RandomizeAmplitudeAtStart { get { return this.mRandomizeAmplitudeAtStart; } set { this.mRandomizeAmplitudeAtStart = value; } }
        public float RandomizeFrequencyAtStart { get { return this.mRandomizeFrequencyAtStart; } set { this.mRandomizeFrequencyAtStart = value; } }

        /*******************************************/
        /*            Unity's function             */
        /*******************************************/
        protected override void Awake()
        {
            base.Awake();

            RandomizeAmplitude();
            RandomizeFrequency();
        }

        private void Update()
        {
            if (!mEffect)
            {
                mTime = 0.0f;
                return;
            }

            Vector3 newVal = GetVector3ByTransformType();

            switch (mAxis)
            {
                case JCS_Axis.AXIS_X:
                    {
                        newVal.x += (mAmplitude * Mathf.Cos(mTime * mFrequency)) * Time.deltaTime;
                    }
                    break;
                case JCS_Axis.AXIS_Z:
                    {
                        newVal.z += (mAmplitude * Mathf.Cos(mTime * mFrequency)) * Time.deltaTime;
                    }
                    break;
                case JCS_Axis.AXIS_Y:
                    {
                        newVal.y += (mAmplitude * (Mathf.Cos(mTime * mFrequency))) * Time.deltaTime;
                    }
                    break;
            }

            SetVector3ByTransformType(newVal);

            mTime += Time.deltaTime;
        }

        /*******************************************/
        /*              Self-Define                */
        /*******************************************/
        //----------------------
        // Public Functions

        /// <summary>
        /// Get the one of the transform type by passing the 
        /// JCS_TransformType enum.
        /// </summary>
        /// <returns> local pos/eulerAngle? </returns>
        public Vector3 GetVector3ByTransformType(bool local = false)
        {
            Vector3 val = Vector3.zero;

            switch (mTransformType)
            {
                case JCS_TransformType.POSITION:
                    {
                        if (!local)
                            val = Position;
                        else
                            val = LocalPosition;
                    }
                    break;
                case JCS_TransformType.ROTATION:
                    {
                        if (!local)
                            val = EulerAngles;
                        else
                            val = LocalEulerAngles;
                    }
                    break;
                case JCS_TransformType.SCALE:
                    val = LocalScale;
                    break;
            }

            return val;
        }

        /// <summary>
        /// Set the new vector3 value to one of the transform type.
        /// </summary>
        /// <param name="newVal"> New vector3 value . </param>
        /// <param name="local"> local pos/eulerAngle? </param>
        public void SetVector3ByTransformType(Vector3 newVal, bool local = false)
        {
            switch (mTransformType)
            {
                case JCS_TransformType.POSITION:
                    {
                        if (!local)
                            this.Position = newVal;
                        else
                            this.LocalPosition = newVal;
                    }
                    break;
                case JCS_TransformType.ROTATION:
                    {
                        if (!local)
                            this.EulerAngles = newVal;
                        else
                            this.LocalEulerAngles = newVal;
                    }
                    break;
                case JCS_TransformType.SCALE:
                    this.LocalScale = newVal;
                    break;
            }
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

        /// <summary>
        /// Randomize a bit of amplitude value.
        /// </summary>
        private void RandomizeAmplitude()
        {
            if (mRandomizeAmplitudeAtStart == 0.0f)
                return;

            mAmplitude += JCS_Random.Range(-mRandomizeAmplitudeAtStart, mRandomizeAmplitudeAtStart);
        }

        /// <summary>
        /// Randomize a bit of frequency value.
        /// </summary>
        private void RandomizeFrequency()
        {
            if (mRandomizeFrequencyAtStart == 0.0f)
                return;

            mFrequency += JCS_Random.Range(-mRandomizeFrequencyAtStart, mRandomizeFrequencyAtStart);
        }

    }
}
