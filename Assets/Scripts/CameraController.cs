using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target; // Objeto al que seguir� la c�mara

        [SerializeField]
        private float angle; // �ngulo de la c�mara respecto al objetivo

        [SerializeField]
        private float distance; // Distancia entre la c�mara y el objetivo

        [SerializeField]
        private Vector3 offset; // Desplazamiento respecto al pivote del objetivo

        [SerializeField]
        private float travelTime; // Tiempo de desplazamiento de la c�mara hacia la nueva posici�n

        private void Update()
        {
            // Calcular la posici�n deseada de la c�mara
            Vector3 desiredPosition = target.position - target.forward * distance;
            desiredPosition += Quaternion.Euler(0, angle, 0) * offset;

            // Orientar la c�mara hacia el objetivo
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - desiredPosition, Vector3.up);
            transform.rotation = desiredRotation;

            // Mover la c�mara hacia la nueva posici�n suavemente
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime / travelTime);
        }
    }
}
