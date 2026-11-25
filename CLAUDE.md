# Agenda

Sistema de citas para negocios pequeños. Proyecto de portafolio en .NET + Angular. El alcance, las
reglas de negocio y la hoja de ruta están en `README.md`; ese archivo manda.

## Reglas

- **Código en inglés, interfaz en español.** Clases, métodos, tablas y endpoints en inglés; textos
  que ve el usuario en español.
- **Clean Architecture estricta:** `Domain` no depende de nada; `Application` solo de `Domain`;
  `Infrastructure` implementa las interfaces de `Application`; `Api` solo compone. Una prueba de
  arquitectura vigila esto.
- Las reglas de negocio viven en `Domain`/`Application`, nunca en controllers ni en el frontend.
- La regla de "no hay doble reserva" se garantiza en la base de datos, no solo con un `if`. Cualquier
  cambio en la creación de citas debe pasar la prueba de concurrencia.
- Fechas en UTC en la base; la zona horaria del negocio se aplica al mostrar y al calcular turnos.
- Nada se borra: se desactiva o cambia de estado.
- Toda regla nueva lleva su prueba. Los cambios de esquema van por migraciones de EF Core.
- Las decisiones de arquitectura se anotan en `docs/decisiones.md` (D-01 en adelante).
- Se avanza un paso a la vez según la hoja de ruta del README.

## Comandos

- Backend: `cd backend && dotnet build` · `dotnet test` · `dotnet run --project src/Agenda.Api`
- Frontend: `cd frontend && npm start` · `npm test`
