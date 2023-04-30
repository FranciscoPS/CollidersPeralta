using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using System.Threading.Tasks;

public class HarryController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator harryAnimator;
    [SerializeField] private Camera m_camera;
    [SerializeField] private float rotationSpeed;

    private Vector3 originalSize;
    private static readonly int Speed = Animator.StringToHash("Speed");

    void Start()
    {
        originalSize = transform.localScale;
    }

    void Update()
    {
        Move(GetMovementInput());
        Rotate(GetRotationInput());
    }

    public Vector3 GetOriginalSize() {
        return originalSize;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }

    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }

    private Vector3 GetMovementInput()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }

    private void Move(Vector3 p_inputMovement)
    {
        var transform1 = transform;
        transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                               (speed * Time.deltaTime);
        harryAnimator.SetFloat(Speed, p_inputMovement.magnitude);
    }
}