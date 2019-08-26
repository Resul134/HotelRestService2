using System.Collections.Generic;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public interface IManageBooking
    {
        /// <summary>
        /// henter alle gæster fra databasen
        /// </summary>
        /// <returns>Liste af gæster</returns>
        List<Booking> GetAllBookings();

        /// <summary>
        /// Henter en specifik gæst fra database 
        /// </summary>
        /// <param name="bookingNr">Udpeger den gæst der ønskes fra databasen</param>
        /// <returns>Den fundne gæst eller null hvis gæsten ikke findes</returns>
        Booking GetBookingFromId(int BookingNr);

        /// <summary>
        /// Indsætter en ny gæst i databasen
        /// </summary>
        /// <param name="booking">Gæsten der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool CreateBooking(Booking booking);

        /// <summary>
        /// Opdaterer en gæst i databasen
        /// </summary>
        /// <param name="guest">De nye værdier til gæsten</param>
        /// <param name="guestNr">Nummer på den gæst der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool UpdateBooking(Booking booking, int bookingNr);

        /// <summary>
        /// Sletter en gæst fra databasen
        /// </summary>
        /// <param name="guestNr">Nummer på den gæst der skal slettes</param>
        /// <returns>Den gæst der er slettet fra databasen, returnere null hvis gæsten ikke findes</returns>
        Booking DeleteBooking(int BookingNr);
    }
}