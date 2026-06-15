# Farmacorp POS

## Descripción

Solución desarrollada como prueba técnica para la gestión de productos, categorías, códigos de barra y ventas de Farmacorp POS.

El proyecto fue construido utilizando .NET 10 y Entity Framework Core, aplicando una arquitectura por capas y diversos patrones de diseño para mantener el código desacoplado, escalable y fácil de mantener.

---

## Arquitectura

La solución está compuesta por cuatro proyectos:

```text
FarmacorpPOS.Console
FarmacorpPOS.Application
FarmacorpPOS.Domain
FarmacorpPOS.Infrastructure
```

### FarmacorpPOS.Console

Contiene la interfaz de usuario basada en consola y la configuración inicial de la aplicación.

### FarmacorpPOS.Application

Implementa los casos de uso y servicios de aplicación.

### FarmacorpPOS.Domain

Contiene:

* Entidades
* Interfaces
* Estrategias de negocio
* Reglas del dominio

### FarmacorpPOS.Infrastructure

Implementa:

* Entity Framework Core
* DbContext
* Fluent API
* Repositorios
* Unit of Work

---

## Patrones de Diseño Utilizados

### Repository Pattern

Abstrae el acceso a datos y desacopla la lógica de negocio de la persistencia.

### Unit of Work

Centraliza la persistencia de cambios y coordina múltiples repositorios.

### Strategy Pattern

Permite cambiar dinámicamente las reglas de negocio entre los modos Base y GanaMax.

### Dependency Injection

Facilita la resolución de dependencias y reduce el acoplamiento entre componentes.

### Inversión de Control (IoC)

Las implementaciones concretas son resueltas por el contenedor de dependencias.

---

## Tecnologías

* .NET 10
* Entity Framework Core
* SQL Server
* Visual Studio Community 2026
* Git
* GitHub

---

## Configuración

Editar el archivo:

```json
appsettings.json
```

### Modo Base

```json
{
  "BusinessMode": "Base"
}
```

### Modo GanaMax

```json
{
  "BusinessMode": "GanaMax"
}
```

---

## Reglas de Negocio

### Base

* Precio = costo + 50%
* Descuento = 30%
* Venta permitida cuando stock >= cantidad

### GanaMax

* Precio = costo + 80%
* Descuento = 10%
* Venta permitida únicamente cuando el stock final sea mayor a 10 unidades

---

## Cómo Ejecutar

1. Clonar el repositorio.
2. Configurar la cadena de conexión en `appsettings.json`.
3. Ejecutar las migraciones:

```bash
Update-Database
```

4. Establecer `FarmacorpPOS.Console` como proyecto de inicio.
5. Ejecutar la aplicación.

---

## Funcionalidades

* Registro de productos ERP.
* Registro de categorías.
* Asignación de categorías a productos.
* Registro de códigos de barra.
* Registro de ventas.
* Actualización automática de inventario.
* Reglas de negocio configurables mediante Strategy Pattern.

---

## Autor

Andrés Sarabia
