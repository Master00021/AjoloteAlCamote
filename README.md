# Devlog Ajolote al Camote

Primero que nada, este proyecto fue un trabajo para Taller de Diseño de Niveles II, a mediados del 2023. El equipo estuvo conformado por Ray, Camila, Simon y yo. Lo diseñamos entre todos, y yo estuve a cargo del area de la programación. 

Ahora, tomare este proyecto para refactorizarlo y pulirlo.

## Quince de mayo de 2024

Este dia me enfoque en preparar todo el proyecto para su posterior edicion, lo revise por encima para hacerme una idea de como lo habiamos dejado. 

Me di cuenta de que lo tendre que refactorizar completamente, habian muy pocas cosas salvables, algunas logicas que habia hecho hace 9 meses unicamente. Ademas, dentro de Unity, tendre que rehacer los niveles y el como estaban organizados.

## Dieciseis de mayo de 2024

Este dia pude avanzar un poco en la mañana, me dedique a ordenar todos los scripts de forma superficial, ya sea agregando el namespace Game, declarando las clases como 'internal' o 'internal sealed', y otras cosas de orden de sintaxis que utilizo actualmente para ordenar mis trabajos.

Ademas, rehice algunas clases, mejorando la logica y el como las conectare entre si.

## Diecisiete de mayo de 2024

Hoy estuve dedicandome a revisar todos los scripts de la carpeta "Obstacles". Me di cuenta de que la mayoria de los scripts era basicamente la misma logica, y que habia uno en concreto, el de 'Bottle', que podia replicar la logica de todos, por lo tanto, borre todo el resto y cambie 'Bottle' por 'GenericMovement'. 

Por ultimo, cambie un poco la clase padre 'Obstacle', ahora se activa el metodo 'CO_HorizontalMovement' por si mismo, de esta forma, las clases hijas no tienen la responsabilidad de iniciar dicho metodo, evitando confusiones y errores a futuro, por no haber iniciado dicho metodo.

Quede haciendo el movimiento de Onda del script 'VecticalWaveMovement', pero decidi dejarlo hasta aqui hoy, estuve unas dos horas trabajando en el proyecto. 

## Dieciocho de mayo de 2024

Hoy no tuve practicamente tiempo para avanzar en este proyecto, apenas le pude dedicar unos 20 minutos. 

Pude resolver el mal funcionamiento del script 'VerticalWaveMovement'. Termine utilizando el metodo transform.Translate(), en vez de usar el 'transform.positon += valor'.

## Diecinueve de mayo de 2024

Cree el script 'GameLifeCycle' para tener controlado el inicio del juego en si, que servira a futuro cuando tenga que manejar todos los flujos que tendra el videojuego. 

Avance en el movimiento horizontal y vertical del jugador, siendo el vertical el que mas me costo. Al ser un controlador tan simple, no queria que se sintiera "tieso" o "lento". 

Sara01-s (en GitHub) me paso dos scripts en los que ella habia trabajado hace un tiempo en el movimiento vertical de una 'nave'. 

Logre abstraer la idea de ambos y replicarlo, con mis conocimientos en mi codigo, lo cual no fue facil. 

Consiste basicamente en utilizar la gravedad del rigidbody y no aplicarle una fuerza al mismo. 

Me parecio super contra intuitivo, pero a la vez me hizo mucho sentido. Al final, en vez de aplicarle una fuerza para que el gameObject suba, se le aplica dicha fuerza a la gravityScale del rigidbody, y se invierte segun se desee.

Como siempre, hay que guardar la direccion, y multiplicarla con la fuerza que se desee. Luego, modificar la escala de gravedad del rigidbody con dicho valor.

Lo unico que quedaria seria limitar las velocidades del rigidbody.

Hoy estuve avanzando en la Tesis, asique tampoco tuve tanto tiempo hoy, habre estado apenas 1 hora.