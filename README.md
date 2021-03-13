# QuestionAnswer-Back
Repositorio de ejemplo que emplea Quicker para su desarrollo :) 

Este es una API Web para un sistema de preguntas y respuestas, con opcion de votos y de cuentas de usuario.

# __En desarrollo__

## Requerimientos
La lista de requerimiento con los que se desarrollo este sistema, fue la siguiente:

- Cuentas de usuario: Deben existir cuentas de usuario que admitan: 
  - Email (Agregado)
  - Nombre de usuario (Agregado)
  - Aparte deben existir opciones de: 
    - Cambiar contraseña (Agregado)
    - Actualizar informacion (Agregado)
    - Confirmar correo (Agregado)
    - Bloqueo de cuentas (Agregado)
- Categorias: El sistema debe incluir categorias para las preguntas (Completo)
- Preguntas: El sistema debe incluir la posibilidad de agregar preguntas, exactamente estas incluyen los siguientes datos:  
  - Pregunta (Agregado)
  - Creator (Agregado)
  - Categoria (Agregado)
  - Solo los usuarios registrados pueden hacer preguntas
- Respuestas: El sistema debe incluir la posibilidad de agregar respuestas a las preguntas. Incluyen los siguientes datos: 
  - Respuesta (Agregado)
  - Creator
  - Pregunta relacionada (Agregado)
  - Cualquier usuario, registrado o no, puede hacer respuestas
    - Pero si no esta registrado, son anonimas, y no es posible eliminarlas o editarlas, salvo que seas administrador.
- Votos: Debe existir la opcion de agregar votos a las preguntas y respuestas. 
  - Solo los usuarios registrados pueden votar
  - Maximo una vez por cuenta.

## Caracteristicas
Para el desarrollo de esto, se ha usado
- Asp.net Core
- EntityFramework
- Identity
- Quicker
- AutoMapper
- DataAnnotations

