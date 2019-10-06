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
        public static Details_of_vehicles Convert_vehicles_to__dal(this common.Details_of_vehicles details_Of_Vehicles)
        {
            Details_of_vehicles details_Of_Vehicles_dal = new Details_of_vehicles();
            details_Of_Vehicles_dal.License_plate = details_Of_Vehicles.License_plate;
            details_Of_Vehicles_dal.Type = details_Of_Vehicles.Type;
            details_Of_Vehicles_dal.several_places = details_Of_Vehicles.Several_places;
            details_Of_Vehicles_dal.Quantity_of_fuel_per_km = details_Of_Vehicles.Quantity_of_fuel_per_km;
            return details_Of_Vehicles_dal;
        }

        public static common.Details_of_vehicles Convert_to_common(Details_of_vehicles details_Of_Vehicles_dal)
        {
            common.Details_of_vehicles details_of_viehcles = new common.Details_of_vehicles(details_Of_Vehicles_dal.License_plate, details_Of_Vehicles_dal.several_places, details_Of_Vehicles_dal.Quantity_of_fuel_per_km, details_Of_Vehicles_dal.Type);
            return details_of_viehcles;
        }

        public static dal.Users ConvertUserToDal(this common.DetailsOfUser detailsOfUser)
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

        public static common.DetailsOfUser ConvertUserToCommon(Users detailOfUserDal)
        {
            //fix to mapper the permition
            common.DetailsOfUser detailsOfUser = new common.DetailsOfUser(detailOfUserDal.User_s_Id, detailOfUserDal.Name_of_user, detailOfUserDal.Address_of_user, detailOfUserDal.Phone_of_user, common.Permition.Admin);
            return detailsOfUser;
        }
        public static common.DetailsOfCustomer Convert_customer_to_common(Customers customers)
        {
            common.DetailsOfCustomer detailsOfCustomer = new common.DetailsOfCustomer(customers.Conected_name, customers.Conected_phone, customers.Group_s_code, customers.Group_s_name);
            return detailsOfCustomer;
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
