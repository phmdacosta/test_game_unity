using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera camera = Camera.main; // Camera.main obtém a câmera com a tag MainCamera
        EdgeCollider2D collider = GetComponent<EdgeCollider2D>(); // Colisor das extremidades da tela
        Vector2 cameraBottomLeftNode = camera.ScreenToWorldPoint(new Vector3(0, 0, 0)); // Ponto inferior esquerdo da tela
        Vector2 cameraTopLeftNode = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)); // Ponto superior esquerdo da tela
        Vector2 cameraTopRightNode = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); // Ponto superior direito da tela
        Vector2 cameraBottomRightNode = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)); // Ponto inferior direito da tela
        // Definindo os pontos da tela no colisor
        collider.points = new Vector2[5] { cameraBottomLeftNode, cameraTopLeftNode, cameraTopRightNode, cameraBottomRightNode, cameraBottomLeftNode };
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
