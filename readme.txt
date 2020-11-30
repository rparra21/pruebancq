En el proyecto de la web api restful para las respuesta y el manejo de excepciones se utiliza una estructura Json.

Cuando la respuesta es satisfactoria la estructura Json tiene las siguientes propiedades:

tarea = (devuelve el modelo tarea)
codigoEstado = (devuelve el codigo de estado de la respuesta http)
mensaje = (devuelve un mensaje descriptivo de la respuesta) 

Cuando el recurso solicitado no es encontrado la estructura Json tiene las siguientes propiedades:

tarea = (devuelve el modelo tarea)
codigoEstado = (devuelve el codigo de estado de la respuesta http)
mensaje = (devuelve un mensaje descriptivo de la respuesta) 

Cuando ocurre un error en la web api restful la estructura Json tiene las siguientes propiedades:

tarea = (devuelve el modelo tarea)
codigoEstado = (devuelve el codigo de estado de la respuesta http)
mensaje = (devuelve un mensaje descriptivo de la respuesta) 
exception = (devuelve el mensaje de la excepcion)