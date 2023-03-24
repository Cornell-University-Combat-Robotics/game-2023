using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{

    public List<Transform> Targets;
    private Camera _camera;

    private void Start() {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate() {
        // move
        var targetBounds = new Bounds(Targets[0].position, Vector3.zero);
        foreach (Transform target in Targets)
        {
            targetBounds.Encapsulate(target.position);
        }
        transform.position = new Vector3(targetBounds.center.x, targetBounds.center.y, -1);
        // zoom
        float newSize = Mathf.Max(targetBounds.size.x, targetBounds.size.y);
    _camera.orthographicSize = Mathf.Max(newSize / 1.5f, 5);
    }
}
