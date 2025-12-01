using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _firstPersonCameraObj;
    [SerializeField] private CinemachineInputAxisController _firstPersonCinemachineCamera;
    [SerializeField] private CinemachinePanTilt _panTiltCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(_panTiltCamera.PanAxis)
        RotateBody(_panTiltCamera.PanAxis.Value);
    }

    void RotateBody(float yAngle)
    {
        transform.Rotate(new Vector3(0, yAngle, 0));
    }
}
