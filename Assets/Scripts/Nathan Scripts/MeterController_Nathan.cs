/**
 * MeterController_Nathan.cs
 * By Nathan Boles
 * 
 * This script is intended to be attached to a meter HUD object, where it'll control and scale depending 
 * on how an attached script decides.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController_Nathan : MonoBehaviour
{
	[Tooltip("The Slider component this script directly controls")]
	[SerializeField] Slider slider;
	[Tooltip("Create a gradient that will replace the color of the fill image")]
	[SerializeField] Gradient gradient;
	[Tooltip("The image that scales depending on how filled the scale is. Should be the same as the Fill Rect in the Slider component.")]
	[SerializeField] Image fill;

	/// <summary>
	/// This sets the maximum value of the slider
	/// </summary>
	/// <param name="maxValue">The value to set the maximum slider value at</param>
	public void setMaxValue(float maxValue)
	{
		slider.maxValue = maxValue;
	}

	/// <summary>
	/// This simply fully fills the meter to the maximum value
	/// Useful for healthbar or stuff that is desired to start at full
	/// </summary>
	public void fillMeterToMax()
	{
		slider.value = slider.maxValue;
		fill.color = gradient.Evaluate(1f);
	}

	/// <summary>
	/// Changes the value of the Meter's slider to that of the value given
	/// Call this when numbers change to have the Meter change appropriately
	/// </summary>
	/// <param name="value">The value to set the current slider value at</param>
	public void setMeter(float value)
	{
		slider.value = value;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
