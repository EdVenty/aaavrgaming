using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private float _drawSpeed;
    [SerializeField] private LineRenderer _lineRenderer;

    public GameObject Magnit;

    private Vector3 _targetGrapplePosition;
    private Vector3 _currentGrapplePosition;
    public void DrawRope(Vector3 grapplePosition)
    {
        _lineRenderer.positionCount = 2;
        _targetGrapplePosition = grapplePosition;
        _currentGrapplePosition = Magnit.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentGrapplePosition = Vector3.Lerp(_currentGrapplePosition, _shootPoint.transform.position, Time.deltaTime *_drawSpeed);
        _lineRenderer.SetPosition(0, _shootPoint.transform.position);
        _lineRenderer.SetPosition(1, Magnit.transform.position);
    }
}
