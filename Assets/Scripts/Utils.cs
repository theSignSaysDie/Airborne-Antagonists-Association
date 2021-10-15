using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b) {
        return (Mathf.Abs(a - b) <= EPSILON);
    }

    public static float Clamp(float value, float min, float max) {
        return Mathf.Max(Mathf.Min(max, value), min);
    }

    public static float AngleDiffPosNeg(float a, float b) {
        float diff = a - b;
        if (diff > 180)
            return diff - 360;
        if (diff < -180)
            return diff + 360;
        return diff;
    }

    public static float UpdateValue(float current, float desired, float change) {
        if (ApproximatelyEqual(current, desired)) {
            current = desired;
        } else if (current < desired) {
            current += change * Time.deltaTime;
        } else {
            current -= change * Time.deltaTime;
        }
        return current;
    }
}
