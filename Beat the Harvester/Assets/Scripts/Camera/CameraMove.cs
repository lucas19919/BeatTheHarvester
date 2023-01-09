using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] SpriteRenderer r;
    [SerializeField] float ZoomStep, minSize, maxSize;

    Vector3 StartPosition;
    float sceneMinX, sceneMinY, sceneMaxX, sceneMaxY;

    private void Awake()
    {
        sceneMinX = r.transform.position.x - r.bounds.size.x - 8.5f;
        sceneMaxX = r.transform.position.x + r.bounds.size.x + 8.5f;

        sceneMinY = r.transform.position.y - r.bounds.size.y - 1.5f;
        sceneMaxY = r.transform.position.y + r.bounds.size.y + 1.5f;

        cam.orthographicSize += 12;
    }

    void Update()
    {
        PanCamera();
        Zoom();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 Difference = StartPosition - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = CameraBounds(cam.transform.position + Difference);
        }
    }

    private void Zoom()
    {
        float Zoom = cam.orthographicSize;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Zoom += ZoomStep;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Zoom -= ZoomStep;
        }

        cam.orthographicSize = Mathf.Clamp(Zoom, minSize, maxSize);
        cam.transform.position = CameraBounds(cam.transform.position);
    }

    private Vector3 CameraBounds(Vector3 ScenePosition)
    {
        float camH = cam.orthographicSize;
        float camW = cam.orthographicSize * cam.aspect;

        float minX = sceneMinX + camW;
        float maxX = sceneMaxX - camW;
        float minY = sceneMinY + camH;
        float maxY = sceneMaxY - camH;

        float targetX = Mathf.Clamp(ScenePosition.x, minX, maxX);
        float targetY = Mathf.Clamp(ScenePosition.y, minY, maxY);

        return new Vector3(targetX, targetY, ScenePosition.z);
    }
}
