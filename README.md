# Reservations

## Arquitectura hexagonal

Para este proyecto por varias razones clave que considero fundamentales para garantizar la escalabilidad, mantenibilidad y flexibilidad a largo plazo del sistema.

* Independencia de la infraestructura: Una de las principales ventajas de la arquitectura hexagonal es que permite que la lógica de negocio esté completamente aislada de los detalles de infraestructura. Esto me facilita realizar cambios en el sistema sin afectar la funcionalidad central, como el uso de diferentes bases de datos, servicios de mensajería o APIs externas, sin necesidad de modificar la lógica de negocio.
* Facilita las pruebas: Al tener una capa de dominio desacoplada de las implementaciones de infraestructura (por ejemplo, la base de datos o los servicios externos), es mucho más fácil realizar pruebas unitarias. Puedo testear la lógica de negocio de forma aislada, lo que incrementa la calidad del código y asegura que la aplicación se comporte correctamente bajo diferentes escenarios.
* Escalabilidad y adaptabilidad: La arquitectura hexagonal promueve un diseño más flexible, permitiendo que nuevos adaptadores (interfaces con el mundo exterior) se añadan sin tener que tocar la lógica interna del sistema. Esto es esencial para proyectos a largo plazo, ya que permite integrar nuevas tecnologías o cambiar las existentes con un mínimo impacto en el sistema.
* Mejor organización del código: Esta arquitectura fomenta una estructura más limpia y organizada, separando claramente la lógica de negocio de las interfaces y las implementaciones externas. Esto hace que el código sea más fácil de entender, mantener y extender a medida que el proyecto crece.
* Adaptabilidad a cambios futuros: En el entorno actual, los requisitos del sistema pueden cambiar rápidamente debido a nuevas tecnologías o necesidades de negocio. La arquitectura hexagonal facilita la adaptación a estos cambios, ya que los "puertos" y "adaptadores" pueden ser modificados o reemplazados sin que sea necesario refactorizar toda la base de código.

## Decisiones técnicas

* Uso de PostgreSQL como base de datos:
Opté por utilizar PostgreSQL debido a su robustez, fiabilidad y rendimiento. Es una base de datos relacional madura que soporta una gran cantidad de transacciones simultáneas, es fácilmente escalable y tiene una excelente capacidad de manejo de datos complejos. Además, su soporte de funciones avanzadas como transacciones ACID, índices y operaciones complejas hace que sea una opción sólida para proyectos a largo plazo.
Uso del patrón Result:
Implementé el patrón Result para manejar las respuestas de las operaciones de manera más estructurada y controlada. Este patrón me permite encapsular tanto los resultados exitosos como los errores de forma coherente. De esta forma, evito el uso de excepciones para flujos de control y, en su lugar, gestiono los resultados de manera explícita, facilitando la detección de errores, mejorando la legibilidad del código y haciendo que el manejo de fallos sea más claro y predecible.

* Uso de migraciones:
Decidí utilizar migraciones para gestionar los cambios en la base de datos. Esto proporciona una forma controlada y versionada de modificar el esquema de la base de datos sin tener que hacer cambios manuales. Las migraciones facilitan el trabajo en equipo, ya que cada cambio en la base de datos se registra y se puede aplicar de manera coherente en diferentes entornos de desarrollo y producción. Esto también ayuda a mantener la integridad del esquema de datos a medida que el proyecto evoluciona.
Contratos (Interfaces):
Para promover un diseño desacoplado y flexible, utilicé contratos (interfaces) para definir la comunicación entre los componentes de la aplicación. Esto permite que las implementaciones de los servicios puedan ser intercambiables sin afectar a la lógica de negocio. El uso de interfaces también facilita la creación de pruebas unitarias, ya que puedo simular comportamientos y aislar los componentes al realizar las pruebas.

* Inyección de dependencias (Dependency Injection):
Implementé inyección de dependencias (DI) para gestionar las dependencias entre los componentes de manera eficiente. DI me permite separar las responsabilidades y crear instancias de clases de forma más flexible, sin tener que gestionar manualmente las dependencias. Esto mejora la escalabilidad y la mantenibilidad del proyecto, ya que facilita la incorporación de nuevas funcionalidades sin introducir cambios significativos en el código existente.

* Autenticación JWT (JSON Web Token):
Para gestionar la autenticación y autorización de los usuarios, opté por utilizar JWT (JSON Web Tokens). Este enfoque proporciona una forma segura y eficiente de manejar la autenticación basada en tokens, permitiendo la autenticación sin necesidad de almacenar el estado de las sesiones en el servidor. JWT es escalable, se adapta bien a aplicaciones distribuidas y proporciona un mecanismo de autenticación basado en estándares ampliamente adoptados, lo que mejora la seguridad y la interoperabilidad.