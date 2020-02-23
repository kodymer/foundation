# Principios del Diseño de Software

## Encapsula lo que varia

Debemos identificar todos los aspectos de nuestra aplicación y separar en modulos lo que varia, de lo que llamamos "lo mismo", con el fin de proteger nuestro código de los efectos adversos.

#### Encapsula a nivel de método: 
Si hay lógica que no guarda relación directa con la responsabilidad principal del método original, debes aislar o extraer este comportamiento a otro método, para prevenir futuros cambios en caso de que la lógica se complique

#### Encapsula a nivel de clase: 
Cuando se está agregando y agregando más funcionalidades a un método que debería realizar una simple cosa y estas funcionalidades adicionales necesiten de sus propios campos auxiliares y métodos que eventualmente pueden difuminar la responsabilidad principal de la clase que los contiene. Extraer todo esto a una nueva clase podría hacer las cosas mucho más claras y simples.

## Programa para una interfaz, no una implementación

Programa para una interfaz, no una implementación. Hay que depender de las abstracciones, no de clases concretas.

Esto es muy util cuando se desea que el diseño sea lo suficientemente flexible como para extenderlo fácilmente sin romper ningún código existente. 

A menudo, cuando deseamos que colaboren dos clases, se suele comenzar haciendo que una de ellas dependa de la otra. Sin embargo, hay otra forma más flexible de establecer una colaboración entre los objetos:

1. Determinar exactamente que necesita un objeto, del otro. ¿Que métodos ejecuta?
2. Describe estos métodos en una nueva interfaz o una clase abstracta.
3. Haz que la clase que es una dependencía, implemente esta interfaz.
4. Ahora, haz que la segunda clase dependa de esta interfaz, en vez de una clase concreta.

## Favorece la composición sobre la herencia

La herencia es probablemente la forma más obvia y facil de reusar código entre clases. Desafortunadamente, la herencia viene con advertencias que a menudo se hacen evidentes solo después de que su programa ya tiene toneladas de clases y cambiar algo es bastante difícil. A continuación, les presento una lista de los problemas.

-  Una subclase no puede reducir las interfaz de la super clase, es decir, debe implementar todos los métodos abstractos de la clase principal, incluso si no los va a usar.
-  Cuando se sobreescribe un método, debe asegurarse de que el nuevo método sea compatible con el de la super clase.
- La herencia rompe la encapsulación de la superclase porque los detalles internos de la clase actual están disponibles en la subclase. 
- Las subclases están estrechamente unidas a las superclases. Cualquier cambio en una superclase puede romper la funcionalidad de las subclases.
- Intentar reutilizar el código a través de la herencia puede conducir a crear jerarquías de herencia paralelas. La herencia generalmente tiene lugar en una sola dimensión. Pero siempre que haya dos o más dimensiones, debe crear muchas combinaciones de clases, hinchando la jerarquía de clases a un tamaño ridículo.

Hay una alternativa a la herencia llamada **composición**. Mientras que la herencia representa la relación “es una” entre clases (un automóvil es un transporte), la composición representa la relación “tiene un” (un automóvil tiene un motor).

## SOLID

En ingeniería de software, SOLID (Single responsibility, Open-closed, Liskov substitution, Interface segregation and Dependency inversion) es un acrónimo mnemónico introducido por Robert C. Martin1​2​ a comienzos de la década del 20003​ que representa cinco principios básicos de la programación orientada a objetos y el diseño. Cuando estos principios se aplican en conjunto es más probable que un desarrollador cree un sistema que sea fácil de mantener y ampliar con el tiempo.​ Los principios SOLID son guías que pueden ser aplicadas en el desarrollo de software para eliminar código sucio provocando que el programador tenga que refactorizar el código fuente hasta que sea legible y extensible. Puede ser utilizado con el desarrollo guiado por pruebas o TDD, y forma parte de la estrategia global del desarrollo ágil de software y desarrollo adaptativo de software.


### Principio de responsabilidad única (SRP)

Hace cada clase responsable de una simple parte de la funcionalidad provista por el software. Este principio es Indispensable para proteger nuestro código frente a cambios.

##### ¿Cómo detectar si estamos violando este principio?

1. En una misma clase hay código involucrado perteneciente a dos ó más capas de la arquitectura.
2. Cuando hay presencia de un número elevado de metodos publicos que poco tienen que ver entre ellos. 
3. Cuando una clase tiene un número elevado de líneas.
4. Cuando hay métodos en una clase, que no utilizan todos los campos o propiedades de la misma.
5. Nos cuesta comprobar la funcionalidad de la clase.
6. Cada vez que se escribe una nueva funcionalidad, la misma clase se ve afectada.

### Principio de abierto/cerrado (OCP)

Una entidad de software debería estar abierta a la extensión pero cerrada a modificación.

##### Consideraciones del principio
1. Se suele resolver usando *polimorfismo*.
2. Cuando se dice que una *Clase está abierta*, es porque **se puede extender**.
3. Implica agregar nuevas clases y métodos.
4. Los nuevos desarrollos, no afectarán las clases existentes.
5. Si una clase fue desarrollada, probada y revisada, constituye un riesgo modificarla nuevamente.
6. El principio no impide resolver *bugs* en las súper clases. 







