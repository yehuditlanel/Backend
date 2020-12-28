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
        public static Type_of_vehicles ConvertVehiclesIoDal(this common.VehicleType detialsOfVehicles)
        {
            DataBaseEntities db = new DataBaseEntities();
            Type_of_vehicles type_of_vehicles = new Type_of_vehicles();
            type_of_vehicles.Id = detialsOfVehicles.Code;
            type_of_vehicles.Count = detialsOfVehicles.Count;
            type_of_vehicles.Description = detialsOfVehicles.Description;

            return type_of_vehicles;
        }

        public static VehicleType  ConvertVehicleToCommon(Type_of_vehicles detialsOfVehicles)
        {
            DataBaseEntities db = new DataBaseEntities();
            //string type = db.Type_of_vehicles.Where(v => v.Id == detialsOfVehicles.Type).Select(c => c.Description).FirstOrDefault();
            return new VehicleType(detialsOfVehicles.Id, detialsOfVehicles.Count, detialsOfVehicles.Description);
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
            DataBaseEntities db = new DataBaseEntities();
            string groupName = db.Customers.Where(c => c.Group_s_code == travels.Group_s_code).Select(c => c.Group_s_name).FirstOrDefault();
            return new DetailsOfTravel(travels.Travel_s_code,travels.Collection_or_dispersing,travels.Destination_or_source,travels.Hour,travels.Frequency,travels.Date_of_begin,travels.Date_of_end,groupName,travels.Latitude,travels.Longitude);
        }
        public static Travels ConvertTravelToDal(this common.DetailsOfTravel detailsOfTravel)
        {
            DataBaseEntities db = new DataBaseEntities();
            Travels detailsOfTravelDal = new Travels();
            detailsOfTravelDal.Travel_s_code = detailsOfTravel.TravelCode;
            detailsOfTravelDal.Collection_or_dispersing = detailsOfTravel.CollectionOrDispersing;
            detailsOfTravelDal.Destination_or_source = detailsOfTravel.DestinationOrSource;
            detailsOfTravelDal.Hour = detailsOfTravel.Hour;
            detailsOfTravelDal.Frequency = detailsOfTravel.Frequency;
            detailsOfTravelDal.Date_of_begin = detailsOfTravel.DateOfBegin;
            detailsOfTravelDal.Date_of_end = detailsOfTravel.DateOfEnd;
            int groupCode = db.Customers.Where(c => c.Group_s_name == detailsOfTravel.GroupName).Select(c => c.Group_s_code).FirstOrDefault();
            detailsOfTravelDal.Group_s_code = groupCode;
            detailsOfTravelDal.Latitude = detailsOfTravel.Latitude;
            detailsOfTravelDal.Longitude = detailsOfTravel.Longitude;
            return detailsOfTravelDal;
        }
        public static DetailsOfTrack ConvertTrackToCommon(Track_to_travel track)
        {
            DataBaseEntities db = new DataBaseEntities();
            string Description = db.Type_of_vehicles.Where(v => v.Id == track.Type).Select(v => v.Description).FirstOrDefault();
            return new DetailsOfTrack(track.Track_s_code,track.Travel_s_code,Description,track.Date_of_travel,track.Hour_of_begin);
        }
        public static Track_to_travel ConvertTrackToDal(this common.DetailsOfTrack detailsOfTrack)
        {
            DataBaseEntities db = new DataBaseEntities();
            int codeVehicle = db.Type_of_vehicles.Where(d => d.Description == detailsOfTrack.Type).Select(d => d.Id).FirstOrDefault();
            Track_to_travel detailsOfTrackDal = new Track_to_travel();
            detailsOfTrackDal.Track_s_code = detailsOfTrack.TrackCode;
            detailsOfTrackDal.Travel_s_code = detailsOfTrack.TravelCode;
            detailsOfTrackDal.Type = codeVehicle;
            detailsOfTrackDal.Date_of_travel = detailsOfTrack.DateOfTravel;
            detailsOfTrackDal.Hour_of_begin = detailsOfTrack.HourOfBegin;
            return detailsOfTrackDal;
        }
        public static Station ConvertPassengerToCommon(Passengers passengers)
        {
            return new Station(passengers.Passenger_s_code.ToString(), passengers.Passenger_s_name, passengers.Passenger_s_address,passengers.Latitude,passengers.Longitude);
        }
        public static Passengers ConvertPassengerToDal(this Station detailsOfPassenger)
        {
            Passengers detailsOfPassengerDal = new Passengers();
            //detailsOfPassengerDal.Passenger_s_code = detailsOfPassenger.PassengerId;
            detailsOfPassengerDal.Passenger_s_name = detailsOfPassenger.Name;
            detailsOfPassengerDal.Passenger_s_address = detailsOfPassenger.Address;
            detailsOfPassengerDal.Longitude = detailsOfPassenger.Longitude;
            detailsOfPassengerDal.Latitude = detailsOfPassenger.Latitude;

            return detailsOfPassengerDal;
        }
        public static VehicleType ConvertTypeVehicleToCommon(Type_of_vehicles type_Of_Vehicles)
        {
            return new VehicleType(type_Of_Vehicles.Id, type_Of_Vehicles.Count, type_Of_Vehicles.Description);
        }
    }
}
