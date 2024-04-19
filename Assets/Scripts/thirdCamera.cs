using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdCamera : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset de la c�mara respecto al jugador
    public float rotationSpeed = 5f; // Velocidad de rotaci�n de la c�mara

private void LateUpdate()
{
    if (!target) return; // Si no hay objetivo, no hacemos nada

    // Calcular la rotaci�n de la c�mara basada en la posici�n del jugador
    float horizontalInput = Input.GetAxis("Mouse X");
    Vector3 desiredPosition = target.position + offset;
    Quaternion rotation = Quaternion.Euler(0, horizontalInput * rotationSpeed, 0);
    Vector3 rotatedOffset = rotation * offset;

    // Asignar la posici�n de la c�mara y su mirada hacia el jugador
    transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);
    transform.LookAt(target.position);
}
}
