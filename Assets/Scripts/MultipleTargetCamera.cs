using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{

    public List<Transform> Targets;
    private Camera _camera;

    private float _targetSize;
    private Vector3 _targetPos;
    private float _interpFactor = 0.05f; // lerp factor

    private void Start() {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate() {
        // skip if no targets
        if (Targets.Count == 0) return;
        // move
        var targetBounds = new Bounds(Targets[0].position, Vector3.zero);
        foreach (Transform target in Targets)
        {
            targetBounds.Encapsulate(target.position);
        }
        _targetPos = new Vector3(targetBounds.center.x, targetBounds.center.y, -1);
        transform.position = Vector3.Lerp(transform.position, _targetPos, _interpFactor);
        // zoom
        _targetSize = Mathf.Max(targetBounds.size.x, targetBounds.size.y);
        _camera.orthographicSize = Mathf.Max(
            Mathf.Lerp(_camera.orthographicSize, _targetSize, 0.3f) / 1.2f,
            8
        );
    }
}
