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