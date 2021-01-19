public class CircularCoords {
  private float _radius;
  private float _angle;

  public float radius { get => _radius; set => _radius = value; }
  public float angle {
    get => _angle;
    set => {
      _angle = Math.Max(Math.Min(0, value), 2*Math.PI);
    }
  }

  public CircularCoords(float radius, float angle) {
    this.radius = radius;
    this.angle = angle;
  }
}
