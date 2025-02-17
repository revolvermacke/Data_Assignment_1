using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories
{
    public static class ServiceFactory
    {
        /// <summary>
        /// Skapar en ny ServiceEntity baserat på ett ServiceRegistrationForm.
        /// Eftersom formuläret inte har "Name" så kan vi inte sätta entity.Name här.
        /// Vi utgår från att ServiceId refererar till en redan existerande tjänst.
        /// </summary>
        /// <param name="form">DTO med tjänsteinformation (ServiceId, UnitId, Quantity)</param>
        /// <returns>En ny instans av ServiceEntity (stub eller existerande ID)</returns>
        //public static ServiceEntity CreateEntity(ServiceRegistrationForm form)
        //{
        //    return new ServiceEntity
        //    {
        //        // Antingen 0 om det är en ny tjänst, eller en befintlig ID om du avser uppdatering.
        //        // Ofta används ServiceId för att slå upp en existerande tjänst i databasen.
        //        //Id = form.ServiceId,

        //        // Sätt enhetens ID. 
        //        // I en riktig implementation hämtar du vanligtvis hela UnitEntity från databasen.
        //        Name = form.Se,
        //        UnitId = form.UnitId
        //    };
        //}

        /// <summary>
        /// Överlagrad metod om du vill tvinga in ett explicit id (t.ex. vid en uppdatering).
        /// </summary>
        /// <param name="form">DTO med tjänsteinformation (ServiceId, UnitId, Quantity)</param>
        /// <param name="id">Det id som ska sättas på entiteten</param>
        /// <returns>En instans av ServiceEntity med specificerat id</returns>
        //public static ServiceEntity CreateEntity(ServiceRegistrationForm form)
        //{
        //    return new ServiceEntity
        //    {
        //        Name = form.ServiceName,
        //        UnitId = form.UnitId
        //    };
        //}

        /// <summary>
        /// Mapper en ServiceEntity till en ServiceModel för presentation eller API-svar.
        /// </summary>
        /// <param name="entity">ServiceEntity som ska mappas</param>
        /// <returns>En instans av ServiceModel</returns>
        public static ServiceModel Create(ServiceEntity entity)
        {
            // Anta att entity.Unit är laddad från databasen (eller null-checka om osäker).
            return new ServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,         // Namn hämtas från entiteten i databasen
                Unit = entity.Unit.Unit,
                Price = entity.Price // "Unit" är en sträng i UnitEntity
            };
        }
    }
}
