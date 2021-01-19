using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap : MonoBehaviour {
    public int mapLevels;
    public float delta = 0.1F;
    public GameObject mapRoot {
        get => transform.gameObject;
    }
    public GameObject testEmptySystem;

    private List<CircularCoords> systemsCircularCoords = new List<CircularCoords>();
    private List<Vector2> systemsVectorCoords = new List<Vector2>();

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < mapLevels; i++) {
            systemsCircularCoords.AddRange(GenerateOneSystemLevel(i));
        }
        foreach (var systemCircular in systemsCircularCoords) {
            Vector2 systemVector = systemCircular.ToVectorFrom(mapRoot.transform.position.x, mapRoot.transform.position.y);
            systemsVectorCoords.Add(systemVector);
            Debug.Log(systemVector);
            Instantiate(testEmptySystem, new Vector3(systemVector.x, systemVector.y, 0), new Quaternion(), mapRoot.transform);
        }
    }

    // Update is called once per frame
    void Update() {
    }

    List<CircularCoords> GenerateOneSystemLevel(int level) {
        List<CircularCoords> systems = new List<CircularCoords>();

        if (level == 0) {
            systems.Add(new CircularCoords(0, 0));
            return systems;
        }
        float angles = 2 * (4 * level - 2);
        float angleStep = 2 * Mathf.PI / angles;

        for (int i = 1; i <= angles; i++) {
            float minRadius = level - 1 + delta;
            float maxRadius = level;
            float minAngle = (i - 1) * angleStep + delta;
            float maxAngle = i * angleStep - delta;

            float myRadius = UnityEngine.Random.Range(minRadius, maxRadius);
            float myAngle = UnityEngine.Random.Range(minAngle, maxAngle);

            Debug.Log($"Generating star {i}/{angles} for level {level}");
            Debug.Log($"Minimal radius {minRadius}");
            Debug.Log($"Maximal radius {maxRadius}");
            Debug.Log($"Minimal angle {minAngle}");
            Debug.Log($"Maximal angle {maxAngle}");

            Debug.Log($"My radius {myRadius}");
            Debug.Log($"My angle {myAngle}");


            systems.Add(new CircularCoords(myRadius, myAngle));
        }
        return systems;
    }
}
