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

## Don’t repeat yourself (DRY)

Según este principio toda "pieza de información" nunca debería ser duplicada debido a que la duplicación incrementa la dificultad en los cambios y evolución posterior, puede perjudicar la claridad y crear un espacio para posibles inconsistencias.

Cuando el principio DRY se aplica de forma eficiente los cambios en cualquier parte del proceso requieren cambios en un único lugar. Por el contrario, si algunas partes del proceso están repetidas por varios sitios, los cambios pueden provocar fallos con mayor facilidad si todos los sitios en los que aparece no se encuentran sincronizados.

## Keep it simple, stupid! (KISS)

El principio KISS establece que la mayoría de sistemas funcionan mejor si se mantienen simples que si se hacen complejos; por ello, la simplicidad debe ser mantenida como un objetivo clave del diseño, y cualquier complejidad innecesaria debe ser evitada.

#### Consideraciones del principo
- Mantenga sus métodos pequeños. Un método nunca debe tener más de 40-50 líneas.
- Un método solo debe resolver un pequeño problema, no muchos casos de uso.
- Si tiene muchas condiciones en el método, divídalas en métodos más pequeños.


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

```C#

// Incorrecto
public class Order
{
    private string Number { get; set; }

    private readonly List<OrderDetail> _details;

    public Order(string number)
    {
        Check.NotNull(number, nameof(number));

        _details = new List<OrderDetail>();
    }

    public virtual void AddDetail(string description, int quantity, decimal price)
    {
        var orderDetail = OrderDetail.Create(description, quantity, price);

        _details.Add(orderDetail);

        Write($"Order #{Number} - Detail: ", orderDetail.ToString()));
    }     

    private void Write(string message)
    {
        Console.WriteLine(message);
    }   
}

// Correcto
public class Order
{
    private ILogger _logger;
    private readonly List<OrderDetail> _details;

    public string Number { get; set; }

    public Order(string number)
    {
        Check.NotNull(number, nameof(number));

        _logger = NullLogger.Instance;
        _details = new List<OrderDetail>();
    }

    public virtual void AddDetail(string description, int quantity, decimal price)
    {
        var orderDetail = OrderDetail.Create(description, quantity, price);

        _details.Add(orderDetail);

        _logger.Write(string.Concat($"Order #{Number} - Detail: ", orderDetail.ToString()));
    }        
}

public class Logger : ILogger
{
    public Logger() { }

    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}

```

### Principio de abierto/cerrado (OCP)

Una entidad de software debería estar abierta a la extensión pero cerrada a modificación.

##### Consideraciones del principio

1. Se suele resolver usando *polimorfismo*.
2. Cuando se dice que una *clase está abierta*, es porque **se puede extender**.
3. Implica agregar nuevas clases y métodos.
4. Los nuevos desarrollos, no afectarán las clases existentes.
5. Si una clase fue desarrollada, probada y revisada, constituye un riesgo modificarla nuevamente.
6. El principio no impide resolver *bugs* en las súper clases. 

```C#

// Cerrado a la modificación y abierto a la extensión
public class Product
{ 
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Product(string code, string name, string description)
    {
        Check.NotNull(code, nameof(code));
        Check.NotNull(name, nameof(name));

        Code = code;
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Code} {Name}";
    }
}

// Contexto actual
class Program
{
    static void Main(string[] args)
    {
        var product = new Product(
            "000001", 
            "50 Sombras de Gray", 
            "Libro para adultos");

        var order = new Order("123456");
        order.AddDetail(product.ToString(), 1, 10.60M);
    }
}

// Extensión de la clase Product
public class BookProduct : Product
{
    public string Isbn { get; set; }
    public string Author { get; set; }

    public BookProduct(string code, string name, string description, string isbn, string author)
        : base(code, name, description)
    {
        Check.NotNull(isbn, nameof(isbn));
        Check.NotNull(author, nameof(author));

        Isbn = isbn;
        Author = author;
    }

    public override string ToString()
    {
        return $"{ base.ToString() } (Isbn: {Isbn} - Autor: {Author})";
    }
}

// Contexto actualizado
class Program
{
    static void Main(string[] args)
    {
        var product = new BookProduct(
            "000001", 
            "50 Sombras de Gray", 
            "Libro para adultos", 
            "823474", 
            "Pedro Moreno");

        var order = new Order("123456");
        order.AddDetail(product.ToString(), 1, 10.60M); 
    }
}

```

### Principio de sustitución de Liskov

Cuando extendamos una clase, hay que recordar que debemos ser capaces de pasar objetos de una subclase, en lugar de un objeto de la super clase, y no romper el código en el cliente. Lo que significa, que el código en la subclase deberia seguir siendo compatible con el comportamiento en implementado en la super clase.

##### Consideraciones del principio

Al sobre escribir un método, extienda el comportamiento base en lugar de reemplazarlo por algo más. Para esto es necesario establecer las siguientes reglas:

- Asegurar que el tipo de retorno en el método de la subclase, coincida o sea un subtipo del tipo de retorno en el método en la superclase.
- Los tipos de parámetros en el método de la subclase deberían ser más abstractos, que los parametros utilizados en el método la superclase.
- El método en la subclase no debería lanzar tipos de excepciones que el método en la super clase no lance. En otras palabras, los tipos de excepciones deben coincidir o ser subtipos de los que el método base pueda lanzar. El resultado se debe al hecho de que los bloques **try-catch** en el código del cliente apuntan a tipos específicos de excepciones que el método base es probable que arroje.
- El método en la subclase no debería fortalecer las condiciones previas impuestas en el método base de la super clase.
- El método en la subclase no debería debilitar las condiciones posteriores impuestas en el método base de la super clase.
- Las invariantes de una superclase deben conservarse. Es decir, un objeto tiene sentido y ese sentido no puede ser trasgiversado en las subclases. Esta regla sobre los invariantes, es la más fácil de infringir porque es posible que malinterpretes o no te des cuenta de todos los invariantes de una clase compleja. Por lo tanto, la forma más segura de extender una clase es introducir nuevos campos y métodos, y no meterse con ningún miembro existente de la superclase.
- Una subclase no debería cambiar los valores de los campos privados de la superclase.

```C#




```

### Principio de segregación por interfaz

Los clientes no deberían verse obligados a depender de los métodos que no usan.

##### ¿Cómo detectar si estamos violando este principio?

Al implementar una interfaz ves que uno o varios de los métodos no tienen sentido y hace falta dejarlos vacíos o lanzar excepciones. 

##### Consideraciones del principio

- Debe dividir las interfaces "gordas" en otras más granulares y específicas, ya que el punto importante es que se implementen todos los métodos definidos por esas interfaces correctamente.
- Una clase puede implementar varias interfaces, pero se recomienda que solo se implemente una.
- Utilice las interfaces para desacoplar módulos entre si.

```C#

```

### Principio de inversion de dependencias

Las clases de alto nivel no deberían depender de las clases de bajo nivel. Ambos deberían depender de abstracciones. Abstracciones no deberían depender de los detalles. Los detalles deben depender de abstracciones

- Las **clases de bajo nivel**, son aquellas que contienen la implementación basica.
- Las **clases de alto nivel** contienen una lógica empresarial compleja que dirige a las **clases de bajo nivel** a algo.

##### ¿Cómo detectar si estamos violando este principio?

- Cuando se realiza cualquier instanciación compleja dentro de las **clases de alto nivel**.

##### Consideraciones del principio

- Debemos describir con interfaces las operaciones de bajo nivel. Las clases de bajo nivel implementan estas interfaces.
- Las **clases de alto nivel** deben depender de 
interfaces, en lugar de clases concretas de bajo nivel.
- Las dependencias en las **clases de alto nivel**, se resuelven en los constructores ó propiedades.

```C#

```

## You Aren't Gonna Need It (YAGNI)

Yagni originalmente es un acrónimo que significa *"No lo vas a necesitar"*.Es una declaración sobre algunas capacidades que presumimos como necesidades de software para el futuro y que no deberían construirse ahora porque *"no las necesitamos"*. En otras palabras, se refiere a potenciar el "diseño incremental o evolutivo" de un software.

##### Consideraciones del Principio

_YAGNI_ solo se aplica a las capacidades integradas en el software para admitir una presunta característica, no se aplica al esfuerzo por hacer que el software sea más fácil de modificar.

## General Responsibility Assignment Software Patterns (GRASP)

GRASP originalmente es un acrónimo que significa *"patrones de software de asignación de responsabilidad general"*. Proporciona un medio para resolver problemas organizacionales y ofrece una forma común de hablar sobre conceptos abstractos. El patrón de diseño establece responsabilidades para objetos y clases en el diseño de programas orientados a objetos.

_GRASP_  clasifica los problemas y sus soluciones juntas como patrones. Con estos problemas y soluciones bien definidos, se pueden aplicar en otros casos similares. _GRASP_ asigna siete tipos de roles a clases y objetos con el fin de delinear claramente las responsabilidades. Estos roles son:










