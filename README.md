# Agenda

Sistema de citas para negocios pequeños (barbería, consultorio, spa). El negocio configura sus
servicios, empleados y horarios; el cliente entra a una página pública, ve los turnos libres y
reserva sin crear cuenta.

## Stack

- **Backend:** .NET 10 (LTS), ASP.NET Core Web API, EF Core, SQL Server, JWT, SignalR
- **Frontend:** Angular 22 (standalone, signals)
- **Pruebas:** xUnit, WebApplicationFactory, Testcontainers (SQL Server)
- **Infra:** Docker, docker-compose, GitHub Actions

## Estructura

```
backend/
  src/
    Agenda.Domain/          Entidades y reglas puras (sin dependencias)
    Agenda.Application/     Casos de uso, DTOs, interfaces (depende de Domain)
    Agenda.Infrastructure/  EF Core, SQL Server, correo (depende de Application)
    Agenda.Api/             Controllers, auth, SignalR, composición
  tests/
    Agenda.UnitTests/         Reglas de dominio y casos de uso
    Agenda.IntegrationTests/  API completa contra SQL Server real
frontend/                   Angular: página pública de reservas + panel del negocio
```

## Alcance (MVP)

**Negocio (panel con login)**
- Servicios: nombre, duración, precio, activo/inactivo.
- Empleados: qué servicios presta cada uno.
- Horario semanal por empleado, descansos y días libres.
- Calendario del día/semana que se actualiza en tiempo real cuando entra una cita (SignalR).
- Cambiar el estado de una cita: confirmada, atendida, no asistió, cancelada.

**Cliente (página pública, sin cuenta)**
- Elige servicio → empleado (o "cualquiera") → día → hora libre.
- Deja nombre, correo y teléfono, y recibe la confirmación por correo.
- Recordatorio automático 24 h antes, con link para cancelar.

## Reglas de negocio

1. Un turno libre = horario del empleado − descansos − días libres − citas ya tomadas.
2. Los turnos se ofrecen cada 15 minutos y caben completos (la duración del servicio no se corta).
3. **No hay doble reserva**, ni siquiera si dos clientes reservan el mismo turno al mismo tiempo.
   Se garantiza en la base de datos, no solo en el código.
4. No se reserva en el pasado ni con menos de 1 hora de anticipación.
5. El cliente puede cancelar hasta 2 horas antes, con el link de su correo.
6. Nada se borra: los servicios y empleados se desactivan y las citas cambian de estado.

## Hoja de ruta

| Semana | Entrega |
| --- | --- |
| 1 | Dominio y cálculo de disponibilidad con pruebas unitarias. EF Core + SQL Server + migraciones. |
| 2 | API de reservas (con la prueba de concurrencia), auth JWT del panel, Swagger. |
| 3 | Frontend: página pública de reservas y panel del negocio. SignalR. |
| 4 | Correos y recordatorios (BackgroundService), Docker, GitHub Actions, despliegue y README final. |

## Puesta en marcha

_Pendiente._
