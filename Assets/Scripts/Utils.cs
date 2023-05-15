using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return Mathf.Abs(a-b) < EPSILON;
    }

    public static float Clamp(float val, float min, float max)
    {
        if(val < min)
            val = min;
        if(val > max)
            val = max;
        return val;
    }

    public static float AngleDiffPosNeg(float a, float b)
    {
        float diff = a - b;
        if(diff > 180)
            return diff - 360;
        if(diff < -180)
            return diff + 360;
        return diff;
    }

    public static float Degrees360(float angleDegrees)
    {
        if(angleDegrees >= 360)
            angleDegrees -= 360;
        if(angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }

    public static bool rocketCollisionDetected(Vector3 pos1, Vector3 pos2, float r1, float r2)
    {
        return Vector3.Distance(pos1, pos2) <= (r1 + r2);
    }

    public static bool cartCollisionDetected(Cart cart1, Cart cart2) {
        float cart1x = cart1.position.x - (cart1.height / 2);
        float cart1z = cart1.position.z - (cart1.width / 2);
        float cart2x = cart2.position.x - (cart2.height / 2);
        float cart2z = cart2.position.z - (cart1.width / 2);

        if(cart1x < cart2x + cart2.height && cart1x + cart1.height > cart2x && cart1z < cart2z + cart2.width && cart1z + cart1.width > cart2z){
            return true;
        }else{
            return false;
        }
    }
}
