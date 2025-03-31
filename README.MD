# API_AMADEUS

Este proyecto es una API desarrollada en **ASP.NET Core** que implementa una arquitectura de capas para gestionar usuarios administradores y otros recursos relacionados. La API utiliza **Entity Framework Core** para interactuar con la base de datos y está diseñada para ser escalable y fácil de mantener.

---

## **Características**

- Arquitectura de capas:
  - **Capa de Presentación**: Maneja las solicitudes HTTP y expone los endpoints de la API.
  - **Capa de Servicios**: Contiene la lógica de negocio.
  - **Capa de Acceso a Datos**: Gestiona la interacción con la base de datos.
- Autenticación basada en **JWT (JSON Web Tokens)**.
- Uso de **Entity Framework Core** como ORM para la gestión de datos.
- Configuración de redirección HTTPS.
- Soporte para migraciones de base de datos.

---

## **Estructura del Proyecto**

```plaintext
API_AMADEUS/
├── Controllers/          # Controladores que exponen los endpoints de la API
├── Services/             # Lógica de negocio (e.g., UserAdminService)
├── Repositories/         # Acceso a datos (e.g., UserAdminRepository)
├── Models/               # Modelos de datos (e.g., UserAdminModel)
├── Data/                 # Contexto de base de datos (e.g., ApplicationDbContext)
├── [Program.cs](http://_vscodecontentref_/0)            # Configuración principal de la aplicación
├── [appsettings.json](http://_vscodecontentref_/1)      # Configuración de la aplicación (e.g., conexión a la base de datos)
```

## Configuración

1. Clonar el repositorio:
```
git clone <URL_DEL_REPOSITORIO>
cd API_AMADEUS
```
2. Configurar la base de datos:

    Edita el archivo appsettings.json para incluir la cadena de conexión a tu base de datos:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=API_AMADEUS;User Id=tu_usuario;Password=tu_contraseña;"
  }
}
```
3. Instalar las dependencias: Ejecuta el siguiente comando para instalar las dependencias necesarias:
```
dotnet restore
```
4. Ejecutar la aplicación: Inicia el servidor de desarrollo:
```
dotnet run
```

## **Endpoints Principales**

Usuarios Administradores
GET /api/admins
Obtiene la lista de todos los administradores.

POST /api/admins
Crea un nuevo administrador.

PUT /api/admins/{id}
Actualiza un administrador existente.

DELETE /api/admins/{id}
Elimina un administrador.

## **Tecnologías Utilizadas**

ASP.NET Core: Framework para construir la API.

Entity Framework Core: ORM para la interacción con la base de datos.

JWT: Autenticación basada en tokens.

Postgresql: para la base de datos: