using UnityEngine;
using System.Collections;

public class VectorMath
{
    /// <summary>
    /// Converts polar to cartesian coordinates
    /// Returns: X,Y Coordinates
    /// </summary>
    /// <param name="_angle">angle of the vector</param>
    /// <param name="_lenght">length of the vector</param>
    /// <returns>X,Y Coordinates</returns>
    public static Vector2 PolarToCartesian(float _angle, float _lenght)
    {
        return new Vector2(_lenght * Mathf.Cos(_angle * Mathf.Deg2Rad), _lenght * Mathf.Sin(_angle * Mathf.Deg2Rad));
    }

    /// <summary>
    /// Converts cartesian to polar vector
    /// Returns: X = angle in degrees. Y = Lenght of the vector
    /// </summary>
    /// <param name="_coordinates">coordinates to convect</param>
    /// <returns>X = angle in degrees. Y = Lenght of the vector</returns>
    public static Vector2 CartesianToPolar(Vector2 _coordinates)
    {

        Vector2 Polar = new Vector2(Mathf.Atan2(_coordinates.y, _coordinates.x) * Mathf.Rad2Deg, Mathf.Sqrt(_coordinates.x * _coordinates.x + _coordinates.y * _coordinates.y));

        if (Polar.x < 0)
        {
            Polar.x += 360;
        }

        return Polar;
    }
}
