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
            Details_of_vehicles details_Of_Vehicles_dal = new Details_of_vehicles();
            details_Of_Vehicles_dal.License_plate = detialsOfVehicles.License_plate;
            details_Of_Vehicles_dal.Type = detialsOfVehicles.Type;
            details_Of_Vehicles_dal.several_places = detialsOfVehicles.Several_places;
            details_Of_Vehicles_dal.Quantity_of_fuel_per_km = detialsOfVehicles.Quantity_of_fuel_per_km;
            return details_Of_Vehicles_dal;
        }

        public static DetialsOfVehicles ConvertVehicleToCommon(Details_of_vehicles detialsOfVehicles)
        {
            return new DetialsOfVehicles(detialsOfVehicles.License_plate, detialsOfVehicles.several_places, detialsOfVehicles.Quantity_of_fuel_per_km, detialsOfVehicles.Type);
        }

        public static Users ConvertUserToDal(this common.DetailsOfUser detailsOfUser)
        {
            Users detailsOfUserDal = new Users();
            detailsOfUserDal.User_s_Id = detailsOfUser.userId;
            detailsOfUserDal.Name_of_user = detailsOfUser.nameOfUser;
            detailsOfUserDal.Address_of_user = detailsOfUser.addressOfUser;
            detailsOfUserDal.Phone_of_user = detailsOfUser.phoneOfUser;
            //do this short
            if (detailsOfUser.permition.Equals("Admin"))
            {
                detailsOfUserDal.Permition = dal.Permition.Admin;
            }
            else if (detailsOfUser.permition.Equals("Secretary"))
            {
                detailsOfUserDal.Permition = dal.Permition.Secretary;
            }
            else if (detailsOfUser.permition.Equals("Driver"))
            {
                detailsOfUserDal.Permition = dal.Permition.Driver;
            }
            //detailsOfUserDal.Permition = detailsOfUser.permition;
            return detailsOfUserDal;
        }

        public static DetailsOfUser ConvertUserToCommon(Users detailOfUserDal)
        {
            //fix to mapper the permition
            return new common.DetailsOfUser(detailOfUserDal.User_s_Id, detailOfUserDal.Name_of_user, detailOfUserDal.Address_of_user, detailOfUserDal.Phone_of_user, common.Permition.Admin);
            
        }
        public static DetailsOfCustomer ConvertCustomerToCommon(Customers customers)
        {
            return new DetailsOfCustomer(customers.Conected_name, customers.Conected_phone, customers.Group_s_code, customers.Group_s_name);
        }

        public static Customers ConvertCustomerToDal(this common.DetailsOfCustomer detailsOfCustomer)
        {
            Customers detailsOfCustomerDal = new Customers();
            detailsOfCustomerDal.Conected_name = detailsOfCustomer.Conected_name;
            detailsOfCustomerDal.Conected_phone = detailsOfCustomer.Conected_phone;
            detailsOfCustomerDal.Group_s_code = detailsOfCustomer.Group_s_code;
            detailsOfCustomerDal.Group_s_name = detailsOfCustomer.Group_s_name;
            return detailsOfCustomerDal;
        }

    }
}
