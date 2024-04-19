using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target; // Objeto al que seguirá la cámara

        [SerializeField]
        private float angle; // Ángulo de la cámara respecto al objetivo

        [SerializeField]
        private float distance; // Distancia entre la cámara y el objetivo

        [SerializeField]
        private Vector3 offset; // Desplazamiento respecto al pivote del objetivo

        [SerializeField]
        private float travelTime; // Tiempo de desplazamiento de la cámara hacia la nueva posición

        private void Update()
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = target.position - target.forward * distance;
            desiredPosition += Quaternion.Euler(0, angle, 0) * offset;

            // Orientar la cámara hacia el objetivo
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - desiredPosition, Vector3.up);
            transform.rotation = desiredRotation;

            // Mover la cámara hacia la nueva posición suavemente
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime / travelTime);
        }
    }
}
