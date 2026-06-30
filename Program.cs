using System;
using HotelReservationSystem.Interfaces;
using HotelReservationSystem.Patterns;
using HotelReservationSystem.Patterns.Observer;
using HotelReservationSystem.Patterns.Repository;
using HotelReservationSystem.Patterns.Strategy;

namespace HotelReservationSystem
{
    // Main program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            // Initialize the repository using the interface
            IReservationRepository repository = new ReservationRepository();
            
            // Initialize the service injecting the repository
            ReservationService service = new ReservationService(repository);

            // Print start header
            Console.WriteLine("--- SISTEMA DE GESTIÓN DE RESERVAS DE HOTEL ---");
            Console.WriteLine();

            // Paso 1: Suscribir los 3 observadores: GuestNotifier, HousekeepingNotifier, AuditLogNotifier.
            Console.WriteLine("1. Suscribiendo observadores...");
            // Create Guest notifier
            IReservationObserver guestNotifier = new GuestNotifier();
            // Create Housekeeping notifier
            IReservationObserver housekeepingNotifier = new HousekeepingNotifier();
            // Create AuditLog notifier
            IReservationObserver auditLogNotifier = new AuditLogNotifier();

            // Subscribe guest notifier
            service.SubscribeObserver(guestNotifier);
            // Subscribe housekeeping notifier
            service.SubscribeObserver(housekeepingNotifier);
            // Subscribe audit log notifier
            service.SubscribeObserver(auditLogNotifier);
            
            Console.WriteLine("Observadores suscritos exitosamente.\n");

            // Paso 2: Crear RES-001: huésped "Laura Gómez", habitación simple, temporada baja, 3 noches.
            Console.WriteLine("2. Creando reserva RES-001...");
            // Use low season strategy
            IPricingStrategy lowSeason = new LowSeasonPricing();
            // Create the reservation using the service
            service.CreateReservation("RES-001", "Laura Gómez", "Simple", 3, lowSeason);
            Console.WriteLine("Reserva RES-001 creada en estado Pendiente.\n");

            // Paso 3: Crear RES-002: huésped "Pedro Salas", habitación doble, temporada alta, 2 noches.
            Console.WriteLine("3. Creando reserva RES-002...");
            // Use high season strategy
            IPricingStrategy highSeason = new HighSeasonPricing();
            // Create the reservation using the service
            service.CreateReservation("RES-002", "Pedro Salas", "Doble", 2, highSeason);
            Console.WriteLine("Reserva RES-002 creada en estado Pendiente.\n");

            // Paso 4: Crear RES-003: huésped "Carmen Ruiz", habitación suite, temporada feriado, 5 noches.
            Console.WriteLine("4. Creando reserva RES-003...");
            // Use holiday season strategy
            IPricingStrategy holidaySeason = new HolidaySeasonPricing();
            // Create the reservation using the service
            service.CreateReservation("RES-003", "Carmen Ruiz", "Suite", 5, holidaySeason);
            Console.WriteLine("Reserva RES-003 creada en estado Pendiente.\n");

            // Paso 5: Cambiar el estado de RES-001 a Confirmado.
            Console.WriteLine("5. Cambiando estado de RES-001 a Confirmado...");
            // Update status via service
            service.UpdateReservationStatus("RES-001", "Confirmado");
            Console.WriteLine();

            // Paso 6: Cambiar el estado de RES-001 a Ingresado.
            Console.WriteLine("6. Cambiando estado de RES-001 a Ingresado (Check-In)...");
            // Update status via service
            service.UpdateReservationStatus("RES-001", "Ingresado");
            Console.WriteLine();

            // Paso 7: Cambiar el estado de RES-002 a Cancelado.
            Console.WriteLine("7. Cambiando estado de RES-002 a Cancelado...");
            // Update status via service
            service.UpdateReservationStatus("RES-002", "Cancelado");
            Console.WriteLine();

            // Paso 8: Desuscribir HousekeepingNotifier del sistema.
            Console.WriteLine("8. Desuscribiendo HousekeepingNotifier del sistema...");
            // Unsubscribe the observer
            service.UnsubscribeObserver(housekeepingNotifier);
            Console.WriteLine("HousekeepingNotifier desuscrito.\n");

            // Paso 9: Cambiar el estado de RES-003 a Confirmado y verificar que HousekeepingNotifier ya no recibe la notificación.
            Console.WriteLine("9. Cambiando estado de RES-003 a Confirmado (Verificando que no notifica a limpieza)...");
            // Update status via service
            service.UpdateReservationStatus("RES-003", "Confirmado");
            Console.WriteLine();

            // Paso 10: Mostrar el resumen final de las 3 reservas con todos sus datos.
            Console.WriteLine("10. Mostrando el resumen final de las reservas...");
            Console.WriteLine(new string('-', 80));
            // Retrieve all reservations
            var allReservations = service.GetAllReservations();
            
            // Loop through each reservation and print its details
            foreach (var res in allReservations)
            {
                // Print reservation summary line
                Console.WriteLine($"Reserva: {res.Id} | Huésped: {res.GuestName} | Tipo: {res.RoomType} | Noches: {res.Nights} | Precio Base: ${res.BasePrice} | Precio Total: ${res.TotalPrice} | Estado: {res.Status}");
            }
            Console.WriteLine(new string('-', 80));

            Console.WriteLine("\n--- FIN DEL PROGRAMA ---");
        }
    }
}
