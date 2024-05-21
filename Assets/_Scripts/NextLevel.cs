using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    /*
    
    Las cintas VHS NO serán llaves, Player presiona "E" para tomar la cinta VHS y pasa al siguiente nivel
    Orden de los niveles:

    1. Guarida con las pantallas apagadas.
       VHS AZUL: TVs Room.
       Diálogo con los paneles: "Desconocida" (Nosila).
       
    2. Ciudad Grande.
       VHS VERDE: Building Cinema.
       Sana estática en el bar, pero se activa con Sphere Collider.
       Ataque: Target Shot de botellas de licor que sueltan humo y relentiza al Player.
       Siempre le da al jugador con sus botellas.
       Si alcanza a Player, se repite el nivel.
       NO SE DETIENE PARA ATACAR.

    3. Sala de cine.
       VHS ROJO: Big Screen.
       Jihyo estática en un costado, pero se activa con Box Collider.
       Ataque: Skill Shot de cuchillos que matan de un solo golpe.
       Los ataques se pueden esquivar.
       Si le da cuchillazo a Player, se repite el nivel.
       NO SE DETIENE PARA ATACAR.

    4. Guarida con las pantallas encendidas.
       VHS BLANCO: Final Laberinto.
       Nosila estática al empezar el nivel, pero se activa con Box Collider más tarde
       Nosila persigue a Player por el laberinto.
       Ataque: Melé a determinada distancia.
       Puede fallar los golpes.
       Si le pega a Player, se repite el nivel.
       SÍ SE DETIENE PARA ATACAR.
       
    */

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
