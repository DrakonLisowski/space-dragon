using System;
using UnityEngine;


public class CircularCoords {
    private float _angle;

    public float radius {
        get; set;
    }

    public float angle {
        get => _angle;
        set {
            _angle = Mathf.Min(Mathf.Max(0, value), 2 * Mathf.PI);
        }
    }

    public CircularCoords(float radius, float angle) {
        this.radius = radius;
        this.angle = angle;
    }

    public Vector2 ToVectorFrom(float centerX, float centerY) {
        float y = radius * Mathf.Sin(angle) + centerY;
        float x = radius * Mathf.Cos(angle) + centerX;
        return new Vector2(x, y);
    }
}
