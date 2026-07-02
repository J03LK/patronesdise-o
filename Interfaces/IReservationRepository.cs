using System.Collections.Generic;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Interfaces
{
    // Interfaz para el patrón Repository para manejar el almacenamiento de reservas
    public interface IReservationRepository
    {
        // Guarda una nueva reserva en el repositorio
        void Save(Reservation reservation);

        // Busca una reserva por su identificador, retorna null si no se encuentra
        Reservation? GetById(string id);

        // Retorna todas las reservas almacenadas
        IEnumerable<Reservation> GetAll();

        // Actualiza el estado de una reserva existente
        void UpdateStatus(string id, string newStatus);
    }
}
