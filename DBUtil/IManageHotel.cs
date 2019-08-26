using System.Collections.Generic;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public interface IManageHotel
    {
        /// <summary>
        /// henter alle gæster fra databasen
        /// </summary>
        /// <returns>Liste af gæster</returns>
        List<Hotel> GetAllHotels();

        /// <summary>
        /// Henter en specifik gæst fra database 
        /// </summary>
        /// <param name="hotelNr">Udpeger den gæst der ønskes fra databasen</param>
        /// <returns>Den fundne gæst eller null hvis gæsten ikke findes</returns>
        Hotel GetHotelFromId(int HotelNr);

        /// <summary>
        /// Indsætter en ny gæst i databasen
        /// </summary>
        /// <param name="hotel">Gæsten der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool Createhotel(Hotel hotel);

        /// <summary>
        /// Opdaterer en gæst i databasen
        /// </summary>
        /// <param name="guest">De nye værdier til gæsten</param>
        /// <param name="guestNr">Nummer på den gæst der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool Updatehotel(Hotel hotel, int hotelNr);

        /// <summary>
        /// Sletter en gæst fra databasen
        /// </summary>
        /// <param name="guestNr">Nummer på den gæst der skal slettes</param>
        /// <returns>Den gæst der er slettet fra databasen, returnere null hvis gæsten ikke findes</returns>
        Hotel Deletehotel(int hotelNr);
    }
}