using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using dal;
using IronXL;
namespace bll
{
    public class ManagmentOfTravel
    {
        public static List<DetailsOfTravel> GetTravels()
        {
            return ManagementOfTravel.management_of_travel.GetTravels();
        }
        public static List<DetailsOfTravel> GetTravels(int groupCode)
        {
            return ManagementOfTravel.management_of_travel.GetTravels(groupCode);
        }
        public static int AddTravel(DetailsOfTravel detailsOfTravel, Stream fileStream)
        {
            List<Station> lPassenger = new List<Station>();
           // Station oDestination = new Station(string.Empty, string.Empty, "נודע ביהודה 11 מודיעין עילית", 31.9350843, 35.0455159);
            Station oDestination = new Station(string.Empty, string.Empty, detailsOfTravel.DestinationOrSource,detailsOfTravel.Latitude,detailsOfTravel.Longitude);
            oDestination.IsDestination = true;

            lPassenger.Add(oDestination);
            WorkBook workbook = WorkBook.Load(fileStream);
            WorkSheet sheet = workbook.WorkSheets.First();
            int row = sheet.RowCount;
            //List<common.DetailsOfPassenger> names = new List<common.DetailsOfPassenger>();
            for (int j = 2; j <= row; j++)
            {
                string name = sheet['A' + j.ToString()].StringValue;
                string address = sheet['B' + j.ToString()].StringValue;
                lPassenger.Add(new Station(j.ToString(), name, address));
            }
            TransportationEngine oEngine = new TransportationEngine();

            //lPassenger.Add(new Station("111", "אבני נזר 15 בני ברק", 32.0835951, 34.8409983));
            //lPassenger.Add(new Station("111", "אבני נזר 15 בני ברק", 32.0835951, 34.8409983));
            //lPassenger.Add(new Station("112", "נויפלד 20 בני ברק", 32.096778, 34.8386998));
            //lPassenger.Add(new Station("113", "ראול ולנברג 13 תל אביב", 32.108818, 34.8361033));
            //lPassenger.Add(new Station("114", "אור החיים 7 קרית ספר", 31.9332758, 35.0440538));
            //lPassenger.Add(new Station("115", "ירמיהו 21 ירושלים", 31.7918511, 35.2058739));
            //lPassenger.Add(new Station("116", "הרצל 2 רחובות", 31.879174, 34.818532));
            //lPassenger.Add(new Station("117", "הרב שך 30  בני ברק", 32.0881959, 34.8358902));
            //lPassenger.Add(new Station("118", "שאולזון 2 ירושלים", 31.790726, 35.1764291));
            //lPassenger.Add(new Station("119", "מרים מזרחי 10 רחובות", 31.891134, 34.817165));
            //lPassenger.Add(new Station("1111", "חברון 20 בני ברק", 32.0853294, 34.8261837));
            ////lPassenger.Add(new Station("1112", "נודע ביהודה 11 מודיעין עילית", 31.9350843, 35.0455159));
            //lPassenger.Add(new Station("1113", "אחיעזר 5 ראשון לציון", 31.9677785, 34.808136));
            //lPassenger.Add(new Station("1114", "יהודה בורלא 3 תל אביב", 32.1052315, 34.7907317));
            //lPassenger.Add(new Station("1115", "הראה 16 רמת גן", 32.0836819, 34.8176566));
            //lPassenger.Add(new Station("1116", "יעל הגיבורה 3 מודיעין", 31.882529, 35.0120132));
            //lPassenger.Add(new Station("1117", "העלייה 2 בית שמש", 31.7498503, 34.9868694));
            //lPassenger.Add(new Station("1118", "ר עקיבא 113 בני ברק", 32.0858739, 34.8347491));
            //lPassenger.Add(new Station("1119", "יוסף טרומפלדור 2 עכו", 32.9270581, 35.0713098));
            //lPassenger.Add(new Station("1120", "הנגב 13 נתניה", 32.3228663, 34.8531387));
            //lPassenger.Add(new Station("1121", "חתם סופר 4 תל אביב", 32.0884106, 34.7765964));
            //lPassenger.Add(new Station("1121", "חתם סופר 4  הרצליה", 32.152144, 34.8429402));
            //lPassenger.Add(new Station("1123", "כנרת 2 בית שאן", 32.4875837, 35.4997774));
            //lPassenger.Add(new Station("1110", "חתם סופר 4 בני ברק", 32.0893941, 34.8268689));
            //lPassenger.Add(new Station("1124", "חתם סופר 4 ירושלים", 31.7758303, 35.211177));
            //lPassenger.Add(new Station("1125", "ירושלים 86 בני ברק", 32.0827852, 34.8257788));
            //lPassenger.Add(new Station("1126", "הארי הקדוש 3 אשדוד", 31.785499, 34.6633993));
            //lPassenger.Add(new Station("1127", "שדרות נחל צאלים 12 בית שמש", 31.7130877, 34.9855916));
            //lPassenger.Add(new Station("1128", "יגאל ידין 20 חולון", 32.0119612, 34.7824527));
            //lPassenger.Add(new Station("1129", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("1130", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("1131", "אליעזר בן יהודה 2 נתניה", 32.3235604, 34.8520549));
            //lPassenger.Add(new Station("1132", "אליעזר בן יהודה 2 פתח תקווה", 32.0822402, 34.8815566));
            //lPassenger.Add(new Station("1133", "אליעזר בן יהודה 2 אשקלון", 31.6468688, 34.5575587));
            //lPassenger.Add(new Station("221", "אבני נזר 15 בני ברק", 32.0835951, 34.8409983));
            //lPassenger.Add(new Station("222", "נויפלד 20 בני ברק", 32.096778, 34.8386998));
            //lPassenger.Add(new Station("223", "ראול ולנברג 13 תל אביב", 32.108818, 34.8361033));
            //lPassenger.Add(new Station("224", "אור החיים 7 קרית ספר", 31.9332758, 35.0440538));
            //lPassenger.Add(new Station("225", "ירמיהו 21 ירושלים", 31.7918511, 35.2058739));
            //lPassenger.Add(new Station("226", "הרצל 2 רחובות", 31.879174, 34.818532));
            //lPassenger.Add(new Station("227", "הרב שך 30  בני ברק", 32.0881959, 34.8358902));
            //lPassenger.Add(new Station("228", "שאולזון 2 ירושלים", 31.790726, 35.1764291));
            //lPassenger.Add(new Station("229", "מרים מזרחי 10 רחובות", 31.891134, 34.817165));
            //lPassenger.Add(new Station("2211", "חברון 20 בני ברק", 32.0853294, 34.8261837));
            //lPassenger.Add(new Station("2213", "אחיעזר 5 ראשון לציון", 31.9677785, 34.808136));
            //lPassenger.Add(new Station("2214", "יהודה בורלא 3 תל אביב", 32.1052315, 34.7907317));
            //lPassenger.Add(new Station("2215", "הראה 16 רמת גן", 32.0836819, 34.8176566));
            //lPassenger.Add(new Station("2216", "יעל הגיבורה 3 מודיעין", 31.882529, 35.0120132));
            //lPassenger.Add(new Station("2217", "העלייה 2 בית שמש", 31.7498503, 34.9868694));
            //lPassenger.Add(new Station("2218", "הנחושת 10 תל אביב", 32.1101422, 34.8384126));
            //lPassenger.Add(new Station("2219", "יוסף טרומפלדור 2 עכו", 32.9270581, 35.0713098));
            //lPassenger.Add(new Station("2220", "הנגב 13 נתניה", 32.3228663, 34.8531387));
            //lPassenger.Add(new Station("2221", "חתם סופר 4 תל אביב", 32.0884106, 34.7765964));
            //lPassenger.Add(new Station("2221", "חתם סופר 4  הרצליה", 32.152144, 34.8429402));
            //lPassenger.Add(new Station("2223", "כנרת 2 בית שאן", 32.4875837, 35.4997774));
            //lPassenger.Add(new Station("2210", "חתם סופר 4 בני ברק", 32.0893941, 34.8268689));
            //lPassenger.Add(new Station("2224", "חתם סופר 4 ירושלים", 31.7758303, 35.211177));
            //lPassenger.Add(new Station("2225", "הברזל 5 תל אביב", 32.106903, 34.8356821));
            //lPassenger.Add(new Station("2226", "הארי הקדוש 3 אשדוד", 31.785499, 34.6633993));
            //lPassenger.Add(new Station("2227", "שדרות נחל צאלים 12 בית שמש", 31.7130877, 34.9855916));
            //lPassenger.Add(new Station("2228", "יגאל ידין 20 חולון", 32.0119612, 34.7824527));
            //lPassenger.Add(new Station("2229", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("2230", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("2231", "אליעזר בן יהודה 2 נתניה", 32.3235604, 34.8520549));
            //lPassenger.Add(new Station("2232", "אליעזר בן יהודה 2 פתח תקווה", 32.0822402, 34.8815566));
            //lPassenger.Add(new Station("2233", "אליעזר בן יהודה 2 אשקלון", 31.6468688, 34.5575587));
            //lPassenger.Add(new Station("331", "אבני נזר 15 בני ברק", 32.0835951, 34.8409983));
            //lPassenger.Add(new Station("332", "נויפלד 20 בני ברק", 32.096778, 34.8386998));
            //lPassenger.Add(new Station("333", "ראול ולנברג 13 תל אביב", 32.108818, 34.8361033));
            //lPassenger.Add(new Station("334", "אור החיים 7 קרית ספר", 31.9332758, 35.0440538));
            //lPassenger.Add(new Station("335", "ירמיהו 21 ירושלים", 31.7918511, 35.2058739));
            //lPassenger.Add(new Station("336", "הרצל 2 רחובות", 31.879174, 34.818532));
            //lPassenger.Add(new Station("337", "הרב שך 30  בני ברק", 32.0881959, 34.8358902));
            //lPassenger.Add(new Station("338", "שאולזון 2 ירושלים", 31.790726, 35.1764291));
            //lPassenger.Add(new Station("339", "מרים מזרחי 10 רחובות", 31.891134, 34.817165));
            //lPassenger.Add(new Station("3311", "חברון 20 בני ברק", 32.0853294, 34.8261837));
            //lPassenger.Add(new Station("3313", "אחיעזר 5 ראשון לציון", 31.9677785, 34.808136));
            //lPassenger.Add(new Station("3314", "יהודה בורלא 3 תל אביב", 32.1052315, 34.7907317));
            //lPassenger.Add(new Station("3315", "הראה 16 רמת גן", 32.0836819, 34.8176566));
            //lPassenger.Add(new Station("3316", "יעל הגיבורה 3 מודיעין", 31.882529, 35.0120132));
            //lPassenger.Add(new Station("3317", "העלייה 2 בית שמש", 31.7498503, 34.9868694));
            //lPassenger.Add(new Station("3318", "הברזל 5 תל אביב", 32.106903, 34.8356821));
            //lPassenger.Add(new Station("3319", "יוסף טרומפלדור 2 עכו", 32.9270581, 35.0713098));
            //lPassenger.Add(new Station("3320", "הנגב 13 נתניה", 32.3228663, 34.8531387));
            //lPassenger.Add(new Station("3321", "חתם סופר 4 תל אביב", 32.0884106, 34.7765964));
            //lPassenger.Add(new Station("3321", "חתם סופר 4  הרצליה", 32.152144, 34.8429402));
            //lPassenger.Add(new Station("3323", "כנרת 2 בית שאן", 32.4875837, 35.4997774));
            //lPassenger.Add(new Station("3310", "חתם סופר 4 בני ברק", 32.0893941, 34.8268689));
            //lPassenger.Add(new Station("3324", "חתם סופר 4 ירושלים", 31.7758303, 35.211177));
            //lPassenger.Add(new Station("3325", "הנחושת 5 תל אביב", 32.1093622, 34.8388476));
            //lPassenger.Add(new Station("3326", "הארי הקדוש 3 אשדוד", 31.785499, 34.6633993));
            //lPassenger.Add(new Station("3327", "שדרות נחל צאלים 12 בית שמש", 31.7130877, 34.9855916));
            //lPassenger.Add(new Station("3328", "יגאל ידין 20 חולון", 32.0119612, 34.7824527));
            //lPassenger.Add(new Station("3329", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("3330", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("3331", "אליעזר בן יהודה 2 נתניה", 32.3235604, 34.8520549));
            //lPassenger.Add(new Station("3332", "אליעזר בן יהודה 2 פתח תקווה", 32.0822402, 34.8815566));
            //lPassenger.Add(new Station("3333", "אליעזר בן יהודה 2 אשקלון", 31.6468688, 34.5575587));
            //lPassenger.Add(new Station("441", "אבני נזר 15 בני ברק", 32.0835951, 34.8409983));
            //lPassenger.Add(new Station("442", "נויפלד 20 בני ברק", 32.096778, 34.8386998));
            //lPassenger.Add(new Station("443", "ראול ולנברג 13 תל אביב", 32.108818, 34.8361033));
            //lPassenger.Add(new Station("444", "אור החיים 7 קרית ספר", 31.9332758, 35.0440538));
            //lPassenger.Add(new Station("445", "ירמיהו 21 ירושלים", 31.7918511, 35.2058739));
            //lPassenger.Add(new Station("446", "הרצל 2 רחובות", 31.879174, 34.818532));
            //lPassenger.Add(new Station("447", "הרב שך 30  בני ברק", 32.0881959, 34.8358902));
            //lPassenger.Add(new Station("448", "שאולזון 2 ירושלים", 31.790726, 35.1764291));
            //lPassenger.Add(new Station("449", "מרים מזרחי 10 רחובות", 31.891134, 34.817165));
            //lPassenger.Add(new Station("4411", "חברון 20 בני ברק", 32.0853294, 34.8261837));
            //lPassenger.Add(new Station("4413", "אחיעזר 5 ראשון לציון", 31.9677785, 34.808136));
            //lPassenger.Add(new Station("4414", "יהודה בורלא 3 תל אביב", 32.1052315, 34.7907317));
            //lPassenger.Add(new Station("4415", "הראה 16 רמת גן", 32.0836819, 34.8176566));
            //lPassenger.Add(new Station("4416", "יעל הגיבורה 3 מודיעין", 31.882529, 35.0120132));
            //lPassenger.Add(new Station("4417", "העלייה 2 בית שמש", 31.7498503, 34.9868694));
            //lPassenger.Add(new Station("4418", "הברזל 5 תל אביב", 32.106903, 34.8356821));
            //lPassenger.Add(new Station("4419", "יוסף טרומפלדור 2 עכו", 32.9270581, 35.0713098));
            //lPassenger.Add(new Station("4420", "הנגב 13 נתניה", 32.3228663, 34.8531387));
            //lPassenger.Add(new Station("4421", "חתם סופר 4 תל אביב", 32.0884106, 34.7765964));
            //lPassenger.Add(new Station("4421", "חתם סופר 4  הרצליה", 32.152144, 34.8429402));
            //lPassenger.Add(new Station("4423", "כנרת 2 בית שאן", 32.4875837, 35.4997774));
            //lPassenger.Add(new Station("4410", "חתם סופר 4 בני ברק", 32.0893941, 34.8268689));
            //lPassenger.Add(new Station("4424", "חתם סופר 4 ירושלים", 31.7758303, 35.211177));
            //lPassenger.Add(new Station("4425", "הנחושת 5 תל אביב", 32.1093622, 34.8388476));
            //lPassenger.Add(new Station("4426", "הארי הקדוש 3 אשדוד", 31.785499, 34.6633993));
            //lPassenger.Add(new Station("4427", "שדרות נחל צאלים 12 בית שמש", 31.7130877, 34.9855916));
            //lPassenger.Add(new Station("4428", "יגאל ידין 20 חולון", 32.0119612, 34.7824527));
            //lPassenger.Add(new Station("4429", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("4430", "הארי הקדוש 3 כפר סבא", 32.0824416, 34.894244));
            //lPassenger.Add(new Station("4431", "אליעזר בן יהודה 2 נתניה", 32.3235604, 34.8520549));
            //lPassenger.Add(new Station("4432", "אליעזר בן יהודה 2 פתח תקווה", 32.0822402, 34.8815566));
            //lPassenger.Add(new Station("4433", "אליעזר בן יהודה 2 אשקלון", 31.6468688, 34.5575587));



            List<Transportation> lTransportation = oEngine.GetJourneyDetails(lPassenger);


           return ManagementOfTravel.management_of_travel.AddTravel(detailsOfTravel, lTransportation);

        }
        //public static void AddTravel(DetailsOfTravel detailsOfTravel)
        //{
        //    ManagementOfTravel.management_of_travel.AddTravel(detailsOfTravel);
        //}
        public static void UpdateTravel(DetailsOfTravel detailsOfTravel)
        {
            ManagementOfTravel.management_of_travel.UpdateTravel(detailsOfTravel);
        }
        public static void RemoveTravel(int id)
        {
            ManagementOfTravel.management_of_travel.RemoveTravel(id);
        }
    }

}
