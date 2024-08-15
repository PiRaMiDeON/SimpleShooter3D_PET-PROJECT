using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _xRotation;
    [SerializeField] private float _yRotation;

    [SerializeField] private float _topClamp;
    [SerializeField] private float _downClamp;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_topClamp, _downClamp);

        _yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
