# Sistema de Gestion de Agencia de Publicidad

Proyecto academico en ASP.NET Core MVC con Entity Framework Core y SQLite para administrar:

- Clientes
- Campanas
- Disenadores
- Entregables

La aplicacion esta organizada como una solucion simple y facil de mantener, con una estructura clara para revisar, extender y reutilizar sus componentes principales.

## Caracteristicas

- CRUD completo para las cuatro entidades principales
- Relacion entre clientes y campanas
- Relacion entre campanas, disenadores y entregables
- Dashboard inicial con resumen de datos
- Migracion inicial con datos semilla
- Base local SQLite

## Tecnologias

- .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap

## Estructura

- `AngularApp3.Server/Models`: entidades del dominio
- `AngularApp3.Server/Data`: contexto de EF Core y datos iniciales
- `AngularApp3.Server/Controllers`: controladores CRUD
- `AngularApp3.Server/Views`: vistas Razor
- `AngularApp3.Server/Views/Home/Index.cshtml`: panel principal

## Como ejecutar

1. Abrir la solucion `AngularApp3.slnx`.
2. Restaurar paquetes NuGet.
3. Ejecutar el proyecto `AngularApp3.Server`.
4. Abrir la aplicacion desde el navegador.

La cadena de conexion usa SQLite local con el archivo `agencia.db`.

## Datos iniciales

La migracion inicial crea tablas y carga datos de ejemplo para que la aplicacion no arranque vacia. Esto permite revisar listas, detalles y formularios desde el inicio.