using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
namespace dal
{
    public static class Mapper
    {
        public static Details_of_vehicles ConvertVehiclesIoDal(this common.DetialsOfVehicles detialsOfVehicles)
        {
            DataBaseEntities1 db = new DataBaseEntities1();
            Details_of_vehicles details_Of_Vehicles_dal = new Details_of_vehicles();
            details_Of_Vehicles_dal.License_plate = detialsOfVehicles.License_plate;
            int type = db.Type_of_vehicles.Where(v => v.Type.Equals(detialsOfVehicles.Type)).Select(c => c.Id).FirstOrDefault();
            details_Of_Vehicles_dal.Type = type;
            details_Of_Vehicles_dal.several_places = detialsOfVehicles.Several_places;
            details_Of_Vehicles_dal.Quantity_of_fuel_per_km = detialsOfVehicles.Quantity_of_fuel_per_km;
            return details_Of_Vehicles_dal;
        }

        public static DetialsOfVehicles ConvertVehicleToCommon(Details_of_vehicles detialsOfVehicles)
        {
            DataBaseEntities1 db = new DataBaseEntities1();
            string type = db.Type_of_vehicles.Where(v => v.Id == detialsOfVehicles.Type).Select(c => c.Type).FirstOrDefault();
            return new DetialsOfVehicles(detialsOfVehicles.License_plate, detialsOfVehicles.several_places, detialsOfVehicles.Quantity_of_fuel_per_km, type);
        }

        public static Users ConvertUserToDal(this common.DetailsOfUser detailsOfUser)
        {
            Users detailsOfUserDal = new Users();
            detailsOfUserDal.User_s_Id = detailsOfUser.UserId;
            detailsOfUserDal.Name_of_user = detailsOfUser.NameOfUser;
            detailsOfUserDal.Address_of_user = detailsOfUser.AddressOfUser;
            detailsOfUserDal.Phone_of_user = detailsOfUser.PhoneOfUser;
            //do this short
            if (detailsOfUser.Role.ToString()=="Admin")
            {
                detailsOfUserDal.Permition = dal.Permition.Admin;
            }
            else if (detailsOfUser.Role.ToString()=="Secretary")
            {
                detailsOfUserDal.Permition = dal.Permition.Secretary;
            }
            else if (detailsOfUser.Role.ToString()=="Driver")
            {
                detailsOfUserDal.Permition = dal.Permition.Driver;
            }
            return detailsOfUserDal;
        }

        public static DetailsOfUser ConvertUserToCommon(Users detailOfUserDal)
        {
            common.Role p;
            if (detailOfUserDal.Permition == dal.Permition.Admin)
                p = common.Role.Admin;
            else if (detailOfUserDal.Permition == dal.Permition.Driver)
                p = common.Role.Driver;
            else p = common.Role.Secretary;
            //fix to mapper the permition
            return new common.DetailsOfUser(detailOfUserDal.User_s_Id, detailOfUserDal.Name_of_user, detailOfUserDal.Address_of_user, detailOfUserDal.Phone_of_user, p);
            
        }
        public static DetailsOfCustomer ConvertCustomerToCommon(Customers customers)
        {
            return new DetailsOfCustomer(customers.Conected_name, customers.Conected_phone, customers.Group_s_code, customers.Group_s_name);
        }

        public static Customers ConvertCustomerToDal(this common.DetailsOfCustomer detailsOfCustomer)
        {
            Customers detailsOfCustomerDal = new Customers();
            detailsOfCustomerDal.Group_s_code = detailsOfCustomer.Group_s_code;
            detailsOfCustomerDal.Conected_name = detailsOfCustomer.Conected_name;
            detailsOfCustomerDal.Conected_phone = detailsOfCustomer.Conected_phone;
            detailsOfCustomerDal.Group_s_name = detailsOfCustomer.Group_s_name;
            return detailsOfCustomerDal;
        }
        public static DetailsOfTravel ConvertTravelToCommon(Travels travels)
        {
            return new DetailsOfTravel(travels.Travel_s_code,travels.Collection_or_dispersing,travels.Destination_or_source,travels.Hour,travels.Frequency,travels.Date_of_begin,travels.Date_of_end);
        }
        public static Travels ConvertTravelToDal(this common.DetailsOfTravel detailsOfTravel)
        {
            Travels detailsOfTravelDal = new Travels();
            detailsOfTravelDal.Travel_s_code = detailsOfTravel.TravelCode;
            detailsOfTravelDal.Collection_or_dispersing = detailsOfTravel.CollectionOrDispersing;
            detailsOfTravelDal.Destination_or_source = detailsOfTravel.DestinationOrSource;
            detailsOfTravelDal.Hour = detailsOfTravel.Hour;
            detailsOfTravelDal.Frequency = detailsOfTravel.Frequency;
            detailsOfTravelDal.Date_of_begin = detailsOfTravel.DateOfBegin;
            detailsOfTravelDal.Date_of_end = detailsOfTravel.DateOfEnd;
            return detailsOfTravelDal;
        }
        public static DetailsOfTrack ConvertTrackToCommon(Track_to_travel track)
        {
            return new DetailsOfTrack(track.Track_s_code,track.Travel_s_code,track.Driver_s_Id,track.License_plate,track.Date_of_travel,track.Hour_of_begin);
        }
        public static Track_to_travel ConvertTrackToDal(this common.DetailsOfTrack detailsOfTrack)
        {
            Track_to_travel detailsOfTrackDal = new Track_to_travel();
            detailsOfTrackDal.Track_s_code = detailsOfTrack.TrackCode;
            detailsOfTrackDal.Travel_s_code = detailsOfTrack.TravelCode;
            detailsOfTrackDal.Driver_s_Id = detailsOfTrack.DriverId;
            detailsOfTrackDal.License_plate = detailsOfTrack.LicensePlate;
            detailsOfTrackDal.Date_of_travel = detailsOfTrack.DateOfTravel;
            detailsOfTrackDal.Hour_of_begin = detailsOfTrack.HourOfBegin;
            return detailsOfTrackDal;
        }
        public static DetailsOfPassenger ConvertPassengerToCommon(Passengers passengers)
        {
            return new DetailsOfPassenger(passengers.Passenger_s_code,passengers.Group_s_code, passengers.Passenger_s_name,passengers.Passenger_s_address);
        }
        public static Passengers ConvertPassengerToDal(this common.DetailsOfPassenger detailsOfPassenger)
        {
            Passengers detailsOfPassengerDal = new Passengers();
            detailsOfPassengerDal.Passenger_s_code = detailsOfPassenger.PassengerCode;
            detailsOfPassengerDal.Group_s_code = detailsOfPassenger.GroupCode;
            detailsOfPassengerDal.Passenger_s_name = detailsOfPassenger.PassengerName;
            detailsOfPassengerDal.Passenger_s_address = detailsOfPassenger.PassengerAddress;
            return detailsOfPassengerDal;
        }

    }
}
