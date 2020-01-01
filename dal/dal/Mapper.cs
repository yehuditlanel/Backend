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
            DataBaseEntities db = new DataBaseEntities();
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
            DataBaseEntities db = new DataBaseEntities();
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
            if (detailsOfUser.Permition.ToString()=="Admin")
            {
                detailsOfUserDal.Permition = dal.Permition.Admin;
            }
            else if (detailsOfUser.Permition.ToString()=="Secretary")
            {
                detailsOfUserDal.Permition = dal.Permition.Secretary;
            }
            else if (detailsOfUser.Permition.ToString()=="Driver")
            {
                detailsOfUserDal.Permition = dal.Permition.Driver;
            }
            return detailsOfUserDal;
        }

        public static DetailsOfUser ConvertUserToCommon(Users detailOfUserDal)
        {
            common.Permition p;
            if (detailOfUserDal.Permition == dal.Permition.Admin)
                p = common.Permition.Admin;
            else if (detailOfUserDal.Permition == dal.Permition.Driver)
                p = common.Permition.Driver;
            else p = common.Permition.Secretary;
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
            detailsOfCustomerDal.Conected_name = detailsOfCustomer.Conected_name;
            detailsOfCustomerDal.Conected_phone = detailsOfCustomer.Conected_phone;
            detailsOfCustomerDal.Group_s_code = detailsOfCustomer.Group_s_code;
            detailsOfCustomerDal.Group_s_name = detailsOfCustomer.Group_s_name;
            return detailsOfCustomerDal;
        }

    }
}
