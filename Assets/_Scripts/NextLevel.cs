using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    /*
    
    Las cintas VHS NO ser�n llaves, Player presiona "E" para tomar la cinta VHS y pasa al siguiente nivel
    Orden de los niveles:

    1. Guarida con las pantallas apagadas.
       VHS AZUL: TVs Room.
       Di�logo con los paneles: "Desconocida" (Nosila).
       
    2. Ciudad Grande.
       VHS VERDE: Building Cinema.
       Sana est�tica en el bar, pero se activa con Sphere Collider.
       Ataque: Target Shot de botellas de licor que sueltan humo y relentiza al Player.
       Siempre le da al jugador con sus botellas.
       Si alcanza a Player, se repite el nivel.
       NO SE DETIENE PARA ATACAR.

    3. Sala de cine.
       VHS ROJO: Big Screen.
       Jihyo est�tica en un costado, pero se activa con Box Collider.
       Ataque: Skill Shot de cuchillos que matan de un solo golpe.
       Los ataques se pueden esquivar.
       Si le da cuchillazo a Player, se repite el nivel.
       NO SE DETIENE PARA ATACAR.

    4. Guarida con las pantallas encendidas.
       VHS BLANCO: Final Laberinto.
       Nosila est�tica al empezar el nivel, pero se activa con Box Collider m�s tarde
       Nosila persigue a Player por el laberinto.
       Ataque: Mel� a determinada distancia.
       Puede fallar los golpes.
       Si le pega a Player, se repite el nivel.
       S� SE DETIENE PARA ATACAR.
       
    */

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
