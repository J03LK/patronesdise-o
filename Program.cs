using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Patterns;
using HotelReservationSystem.Patterns.Observer;
using HotelReservationSystem.Patterns.Repository;
using HotelReservationSystem.Patterns.Strategy;

namespace HotelReservationSystem
{
    // Clase principal del programa
    class Program
    {
        // Punto de entrada de la aplicación
        static void Main(string[] args)
        {
            // Inicializar el repositorio utilizando la interfaz
            IReservationRepository repository = new ReservationRepository();
            
            // Inicializar el servicio inyectando el repositorio
            ReservationService service = new ReservationService(repository);

            // Imprimir el encabezado de inicio
            Console.WriteLine("--- SISTEMA DE GESTIÓN DE RESERVAS DE HOTEL ---");
            Console.WriteLine();

            // Paso 1: Suscribir los 3 observadores: GuestNotifier, HousekeepingNotifier, AuditLogNotifier.
            Console.WriteLine("1. Suscribiendo observadores...");
            // Crear el observador para huéspedes (GuestNotifier)
            IReservationObserver guestNotifier = new GuestNotifier();
            // Crear el observador para limpieza (HousekeepingNotifier)
            IReservationObserver housekeepingNotifier = new HousekeepingNotifier();
            // Crear el observador para auditoría (AuditLogNotifier)
            IReservationObserver auditLogNotifier = new AuditLogNotifier();

            // Suscribir el observador de huéspedes
            service.SubscribeObserver(guestNotifier);
            // Suscribir el observador de limpieza
            service.SubscribeObserver(housekeepingNotifier);
            // Suscribir el observador de registro de auditoría
            service.SubscribeObserver(auditLogNotifier);
            
            Console.WriteLine("Observadores suscritos exitosamente.\n");

            // Paso 2: Crear RES-001: huésped "Laura Gómez", habitación simple, temporada baja, 3 noches.
            Console.WriteLine("2. Creando reserva RES-001...");
            // Usar la estrategia de temporada baja
            IPricingStrategy lowSeason = new LowSeasonPricing();
            // Crear la reserva utilizando el servicio
            service.CreateReservation("RES-001", "Laura Gómez", "Simple", 3, lowSeason);
            Console.WriteLine("Reserva RES-001 creada en estado Pendiente.\n");

            // Paso 3: Crear RES-002: huésped "Pedro Salas", habitación doble, temporada alta, 2 noches.
            Console.WriteLine("3. Creando reserva RES-002...");
            // Usar la estrategia de temporada alta
            IPricingStrategy highSeason = new HighSeasonPricing();
            // Crear la reserva utilizando el servicio
            service.CreateReservation("RES-002", "Pedro Salas", "Doble", 2, highSeason);
            Console.WriteLine("Reserva RES-002 creada en estado Pendiente.\n");

            // Paso 4: Crear RES-003: huésped "Carmen Ruiz", habitación suite, temporada feriado, 5 noches.
            Console.WriteLine("4. Creando reserva RES-003...");
            // Usar la estrategia de temporada de feriado
            IPricingStrategy holidaySeason = new HolidaySeasonPricing();
            // Crear la reserva utilizando el servicio
            service.CreateReservation("RES-003", "Carmen Ruiz", "Suite", 5, holidaySeason);
            Console.WriteLine("Reserva RES-003 creada en estado Pendiente.\n");

            // Paso 5: Cambiar el estado de RES-001 a Confirmado.
            Console.WriteLine("5. Cambiando estado de RES-001 a Confirmado...");
            // Actualizar estado a través del servicio
            service.UpdateReservationStatus("RES-001", "Confirmado");
            Console.WriteLine();

            // Paso 6: Cambiar el estado de RES-001 a Ingresado.
            Console.WriteLine("6. Cambiando estado de RES-001 a Ingresado (Check-In)...");
            // Actualizar estado a través del servicio
            service.UpdateReservationStatus("RES-001", "Ingresado");
            Console.WriteLine();

            // Paso 7: Cambiar el estado de RES-002 a Cancelado.
            Console.WriteLine("7. Cambiando estado de RES-002 a Cancelado...");
            // Actualizar estado a través del servicio
            service.UpdateReservationStatus("RES-002", "Cancelado");
            Console.WriteLine();

            // Paso 8: Desuscribir HousekeepingNotifier del sistema.
            Console.WriteLine("8. Desuscribiendo HousekeepingNotifier del sistema...");
            // Desuscribir el observador
            service.UnsubscribeObserver(housekeepingNotifier);
            Console.WriteLine("HousekeepingNotifier desuscrito.\n");

            // Paso 9: Cambiar el estado de RES-003 a Confirmado y verificar que HousekeepingNotifier ya no recibe la notificación.
            Console.WriteLine("9. Cambiando estado de RES-003 a Confirmado (Verificando que no notifica a limpieza)...");
            // Actualizar estado a través del servicio
            service.UpdateReservationStatus("RES-003", "Confirmado");
            Console.WriteLine();

            // Paso 10: Mostrar el resumen final de las 3 reservas con todos sus datos.
            Console.WriteLine("\n>>> ESTADO FINAL DE TODAS LAS RESERVAS:");
            
            // Recuperar todas las reservas
            var allReservations = service.GetAllReservations();
            
            // Recorrer cada reserva e imprimir sus detalles
            foreach (var res in allReservations)
            {
                Console.WriteLine();
                Console.WriteLine(new string('-', 36));
                Console.WriteLine($"  RESUMEN DE LA RESERVA {res.Id}");
                Console.WriteLine(new string('-', 36));
                Console.WriteLine($"Huésped: {res.GuestName}");
                Console.WriteLine($"Habitación: {res.RoomType}");
                Console.WriteLine($"Noches: {res.Nights}");
                Console.WriteLine($"Precio Base: ${res.BasePrice:0.00}");
                Console.WriteLine($"Precio Total: ${res.TotalPrice:0.00}");
                Console.WriteLine($"Estado: {res.Status}");
                Console.WriteLine(new string('-', 36));
            }

            Console.WriteLine("\n--- FIN DEL PROGRAMA ---");
        }
    }
}
