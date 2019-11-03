using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private GameObject m_GameManager;
    /// <summary>
    ///  Inicializaciones necesarias para conseguir el Game Manager
    /// </summary>
    void Start()
    {
        // Buscamos el GameManager
        m_GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    /// <summary>
    /// En la función de entrada en el trigger, se comprueba que sea
    /// el player el que toca el item.
    /// </summary>
    /// <param name="other">
    /// Objeto que colisiona contra el item (debería ser el player) <see cref="Collider"/>
    /// </param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager gmComp = m_GameManager.GetComponent<GameManager>();
            gmComp.TriggerLoadFinishGame();
        }
    }
    
}
