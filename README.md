# Práctica 2 - Introducción a los Scripts en Unity

## Crear un script para el personaje que lo desplace por la pantalla, sin aplicar simulación física.
* Agregar un campo público que permita graduar la velocidad del movimiento desde el inspector de objetos.
* Estar a la escucha de si el usuario ha utilizado los ejes virtuales. Elegir cuáles se va a permitir utilizar: flechas, wasd.
* El recorrido virtual realizado con los controladores (teclas) debe ser proporcional a lo que se desplaza el jugador:
* Si sólo pulsa una vez, corresponderá a una unidad, Unity asigna +1 o -1 según la dirección del movimiento
* Si se mantiene pulsado, el jugador debe avanzar en un movimiento continuo, así que Unity asigna un valor entre 0 y 1 ó 0 y -1
* Una vez que tenemos la proporción del desplazamiento, este también debe ser proporcional a la velocidad que hemos establecido para el objeto. El objeto debe cumplir los siguientes requisitos en el movimiento:
* Se debe mover exclusivamente en el plano XZ de su sistema de referencia (su suelo)
* El avance se debe producir hacia adelante. 
* Elegir otros ejes virtuales para el giro y girar al jugador sobre el eje OY (up).

> Inicialmente había que poner una esfera que redujera la velocidad del cubo. Como ya lo teníamos implementado lo comentamos también.


![demo.gif](demo.gif)

## Explicación

Para utilizar el script que hemos desarrollado, `PlayerSquareMovement.cs`, se tiene que añadir como componente al Gameobject que queramos controlar.

Primero, en la función `Update()` se recoge el __input__ del usuario con los métodos `Input.GetAxis` para cada eje de movimiento (desplazamiento en horizontal, desplazamiento en vertical, y giro).

Después, se utilizan los métodos `transform.Translate` y `transform.Rotate` para aplicar el movimiento, dependiendo también de algunas variables como la __velocidad__ de desplazamiento o de giro.

Aparte, con los métodos `OnTriggerEnter()` y `OnTriggerExit` podemos detectar si ha __colisionado con un obstáculo__ (En base a la Tag que tenga asignada), y reducir la velocidad de movimiento del jugador.
