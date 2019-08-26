﻿using System.Collections.Generic;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public interface IManageFacility
    {
        /// <summary>
        /// henter alle gæster fra databasen
        /// </summary>
        /// <returns>Liste af gæster</returns>
        List<Facility> GetAllFacilities();

        /// <summary>
        /// Henter en specifik gæst fra database 
        /// </summary>
        /// <param name="guestNr">Udpeger den gæst der ønskes fra databasen</param>
        /// <returns>Den fundne gæst eller null hvis gæsten ikke findes</returns>
        Facility GetFacilityFromId(int facilityNr);

        /// <summary>
        /// Indsætter en ny gæst i databasen
        /// </summary>
        /// <param name="guest">Gæsten der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool CreateFacility(Facility facility);

        /// <summary>
        /// Opdaterer en gæst i databasen
        /// </summary>
        /// <param name="guest">De nye værdier til gæsten</param>
        /// <param name="guestNr">Nummer på den gæst der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool UpdateFacility(Facility facility, int facilityNr);

        /// <summary>
        /// Sletter en gæst fra databasen
        /// </summary>
        /// <param name="guestNr">Nummer på den gæst der skal slettes</param>
        /// <returns>Den gæst der er slettet fra databasen, returnere null hvis gæsten ikke findes</returns>
        Facility DeleteFacility(int facilityNr);
    }
}