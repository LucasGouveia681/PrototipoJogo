using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Arraste o Plaer para este campo no inspector
    public GameObject player;

    //Distancia entre a camera e a bola
    private Vector3 offset;

    void Start()
    {
        // Calcula a distancia inicial camera -> bola
        offset = transform.position - player.transform.position;
    }

    // LateUpdate roda depois que tudo se moveu no frame.
    void LateUpdate()
    {
        // A câmera vai para a posição da bola + a distancia
        transform.position = player.transform.position + offset;
    }



}
