using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using common;
using dal;

namespace bll
{
    public class TransportationEngine
    {

        #region MEMBERS
        public bool _bInitCoordinatesViaGoogle { get; set; }
        public int _iBusPassCount { get; set; }
        // public int _iMiniBusPassCount { get; set; }
        public int _iMaxDistance { get; set; }
        public int _iMaxDistanceOnTheWay { get; set; }
        public e_Direction _eDirection { get; set; }
        private List<Transportation> _lTransportation { get; set; }
        public List<common.Distance> _lDistance { get; set; }
        public List<Station> _lPassengersStations { get; set; }
        public Station _oDestStation { get; set; }

        public List<VehicleType> _oVehicleTypes { get; set; }
        #endregion

        #region CONSTRUCTOR
        public TransportationEngine()
        {
            InitSettings();

            _lTransportation = new List<Transportation>();
            _lDistance = new List<common.Distance>();
        }

        #endregion

        #region PUBLIC METHODS

        public List<Transportation> GetJourneyDetails(List<Station> lPassengersStations)
        {


            try
            {
                _lPassengersStations = lPassengersStations;
                InitDirection();
                InitCoordinates();
                InitDistance();

                if (_eDirection == e_Direction.DESTINATION)
                {

                    CalcDestinationJourney();
                }
                //else
                //    lTransportation = CalcSourceJourney(ldistance);


                //ExportToExcel(lPassenger);

                return _lTransportation;


            }
            catch (Exception exp)
            {
                Console.WriteLine($"Failed to GetJourneyDetails. Error: {exp.Message}. StackTrace: {exp.StackTrace}");
            }

            return new List<Transportation>();

        }

        #endregion

        #region PRIVATE METHODS
        private void InitSettings()
        {
            //_bInitCoordinatesViaGoogle = Convert.ToBoolean(ConfigurationManager.AppSettings["INIT_COORDINATES_FROM_GOOGLE"]);
            _bInitCoordinatesViaGoogle = true;
            //_iMiniBusPassCount = Convert.ToInt32(ConfigurationManager.AppSettings["MINI_BUS_PASSENGERS_COUNT"]);
            _iMaxDistance = 20 * 1000;
            _iMaxDistanceOnTheWay = 3 * 1000;

            //TODO: init _oVehicleTypes from DB
            List<VehicleType> oVehicleTypes = new List<VehicleType>();
            oVehicleTypes = ManagementOfTypeVehicle.management_of_type_vehicle.GetTypeVehicle();
            //oVehicleTypes.Add(new VehicleType()
            //{
            //    Code = 1,
            //    Count = 53,
            //    Description = "Bus"
            //});

            //oVehicleTypes.Add(new VehicleType()
            //{
            //    Code = 1,
            //    Count = 20,
            //    Description = "MiniBus"
            //});

            //oVehicleTypes.Add(new VehicleType()
            //{
            //    Code = 1,
            //    Count = 6,
            //    Description = "BigTaxi"
            //});

            _oVehicleTypes = oVehicleTypes.OrderByDescending(x => x.Count).ToList();

            _iBusPassCount = _oVehicleTypes.First().Count;
        }

        private void InitDirection()
        {
            if (_lPassengersStations.Any(d => d.IsDestination))
                _eDirection = e_Direction.DESTINATION;
            else
                _eDirection = e_Direction.SOURCE;
        }

        private void CalcDestinationJourney()
        {
            _oDestStation = _lPassengersStations.Where(d => d.IsDestination).First();

            GetDestNextStation(InitDestFirstStation());


            // _lTransportation.Where(t => t.Stations.Count <= _iMiniBusPassCount).ForEach(t => { t.Type = e_TransTypes.MINI_BUS; });
            UpdateType();
        }

        private void UpdateType()
        {
            foreach (var item in _lTransportation)
            {
                foreach (var type in _oVehicleTypes)
                {
                    if (item.Stations.Count > type.Count)
                        break;

                    item.TypeDesc = type.Description;
                }
            }




        }

        private void GetDestNextStation(Station sCurStation)
        {

            if (sCurStation == null)
                return;

            List<common.Distance> lNextDistance = _lDistance.Where(
                d => !d.IsUsed &&
                !(d.Station1.PassengerId == sCurStation.PassengerId && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station2.PassengerId)) &&
                !(d.Station2.PassengerId == sCurStation.PassengerId && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station1.PassengerId)) &&
                (d.Station1.PassengerId == sCurStation.PassengerId || d.Station2.PassengerId == sCurStation.PassengerId) &&
                !d.Station1.IsDestination &&
                !d.Station2.IsDestination &&
                d.distance <= _iMaxDistance// &&
                                           // EnoughSpaceForNextStation(d, sCurStation)
                ).ToList();

            if (lNextDistance.Count == 0)
            {
                GetNextDestOnTheWay(sCurStation);
                return;
            }

            Station nextStation = AddNextMinDistance(lNextDistance, sCurStation);

            if (_lTransportation[_lTransportation.Count - 1].Stations.Count == _iBusPassCount)
                GetDestNextStation(InitDestFirstStation());
            else
                GetDestNextStation(nextStation);

        }

        private Station AddNextMinDistance(List<common.Distance> lNextDistance, Station sCurStation)
        {

            double dMinDistance = lNextDistance.Min(d => d.distance);
            common.Distance oMinDistance = lNextDistance.Where(d => d.distance == dMinDistance).First();
            Station nextStation = oMinDistance.Station1.PassengerId != sCurStation.PassengerId ? oMinDistance.Station1 : oMinDistance.Station2;
            _lTransportation[_lTransportation.Count - 1].Stations.Add(nextStation);


            SetIsUsed(oMinDistance, nextStation);

            return nextStation;
        }

        private void GetNextDestOnTheWay(Station sCurStation)
        {
            List<common.Distance> lNextDistance = _lDistance.Where(
            d => !d.IsUsed &&
            (d.Station1.PassengerId == sCurStation.PassengerId || d.Station2.PassengerId == sCurStation.PassengerId) &&
            !(d.Station1.PassengerId == sCurStation.PassengerId && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station2.PassengerId)) &&
            !(d.Station2.PassengerId == sCurStation.PassengerId && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station1.PassengerId)) &&
            !d.Station1.IsDestination &&
            !d.Station2.IsDestination &&
            IsOnTheWay(sCurStation, d.Station1.PassengerId == sCurStation.PassengerId ? d.Station2 : d.Station1)

            // EnoughSpaceForNextStation(d, sCurStation)
            ).ToList();

            if (lNextDistance.Count == 0)
            {
                GetDestNextStation(InitDestFirstStation());
                return;
            }

            Station nextStation = AddNextMinDistance(lNextDistance, sCurStation);

            if (_lTransportation[_lTransportation.Count - 1].Stations.Count == _iBusPassCount)
                GetDestNextStation(InitDestFirstStation());
            else
                GetNextDestOnTheWay(nextStation);
        }

        private bool IsOnTheWay(Station oCurStation, Station oNextStation)
        {

            common.Distance oCurToDest = _lDistance.Where(d => d.Station1.IsDestination && d.Station2.PassengerId == oCurStation.PassengerId
            || d.Station2.IsDestination && d.Station1.PassengerId == oCurStation.PassengerId).First();

            common.Distance oCurToNext = _lDistance.Where(d => d.Station1.PassengerId == oCurStation.PassengerId && d.Station2.PassengerId == oNextStation.PassengerId
            || d.Station2.PassengerId == oCurStation.PassengerId && d.Station1.PassengerId == oNextStation.PassengerId).First();

            common.Distance oNextToDest = _lDistance.Where(d => d.Station1.IsDestination && d.Station2.PassengerId == oNextStation.PassengerId
            || d.Station2.IsDestination && d.Station1.PassengerId == oNextStation.PassengerId).First();

            return oCurToNext.distance + oNextToDest.distance - oCurToDest.distance <= _iMaxDistanceOnTheWay;
        }

        private Station InitDestFirstStation()
        {
            List<common.Distance> destDistance = _lDistance.Where(d =>
            !d.IsUsed &&
            (d.Station1.IsDestination || d.Station2.IsDestination) &&
            !(d.Station1.IsDestination && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station2.PassengerId)) &&
            !(d.Station2.IsDestination && _lPassengersStations.Any(s => s.IsUsed && s.PassengerId == d.Station1.PassengerId))
            ).ToList();

            if (destDistance.Count == 0)
                return null;

            double dMaxDistance = destDistance.Max(x => x.distance);
            common.Distance oMaxDistance = destDistance.Where(d => d.distance == dMaxDistance).First();
            Station firstStation = oMaxDistance.Station1.IsDestination ? oMaxDistance.Station2 : oMaxDistance.Station1;

            _lTransportation.Add(new Transportation());
            _lTransportation[_lTransportation.Count - 1].Stations.Add(firstStation);

            SetIsUsed(oMaxDistance, firstStation);

            return firstStation;
        }

        private void SetIsUsed(common.Distance oDistance, Station oStation)
        {
            _lPassengersStations.Where(s => s.PassengerId == oStation.PassengerId).ForEach(s => { s.IsUsed = true; });

            _lDistance.Where(d =>
                !d.IsUsed &&
                ((d.Station1.PassengerId == oDistance.Station1.PassengerId && d.Station2.PassengerId == oDistance.Station2.PassengerId) ||
                (d.Station1.PassengerId == oDistance.Station2.PassengerId && d.Station2.PassengerId == oDistance.Station1.PassengerId))
            ).ForEach(d =>
            {
                d.IsUsed = true;
            });


        }

        private void InitDistance()
        {

            int i = 0;
            foreach (Station station1 in _lPassengersStations)
            {
                foreach (Station station2 in _lPassengersStations)
                {


                    if (station1.PassengerId != station2.PassengerId &&
                        !_lDistance.Any(d => (d.Station1.PassengerId == station1.PassengerId && d.Station2.PassengerId == station2.PassengerId) ||
                        (d.Station1.PassengerId == station2.PassengerId && d.Station2.PassengerId == station1.PassengerId)
                        ))
                    {


                        var gcStation1 = new GeoCoordinate(station1.Latitude, station1.Longitude);
                        var gcStation2 = new GeoCoordinate(station2.Latitude, station2.Longitude);

                        //double distance = gcStation1.GetDistanceTo(gcStation2);
                        //double distance2 = station1.GoogleAddress.DistanceBetween(station2.GoogleAddress);
                        _lDistance.Add(new common.Distance()
                        {
                            Station1 = station1.Clone(),
                            Station2 = station2.Clone(),
                            distance = gcStation1.GetDistanceTo(gcStation2),
                            //distance = station1.GoogleAddress.DistanceBetween(station2.GoogleAddress),
                            index = i++
                        });
                    }

                }
            }
        }

        private void InitCoordinates()
        {
            if (!_bInitCoordinatesViaGoogle)
                return;

            foreach (var station in _lPassengersStations)
            {
                try
                {
                    IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "insert your api key", Language = "iw" };

                    Address[] addresses = geocoder.Geocode(station.Address).ToArray();

                    if (addresses == null || addresses.Count() == 0)
                    {
                        Console.WriteLine($"geocoder.Geocode return null. Address: {station.ToString()}");
                        continue;
                    }

                    station.GoogleAddress = addresses.First();
                    station.FormattedAddress = station.GoogleAddress.FormattedAddress;
                    station.Longitude = station.GoogleAddress.Coordinates.Longitude;
                    station.Latitude = station.GoogleAddress.Coordinates.Latitude;



                }
                catch (Exception exp)
                {

                    Console.WriteLine($"Faile to convert address to coordinate. Address: {station.ToString()}. Error: {exp.Message}. StackTrace: {exp.StackTrace}");
                }
            }
        }

        //private void ExportToExcel(List<Station> lPassenger)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.AppendLine("Id,Longitude,Latitude,Address,FormattedAddress");

        //    foreach (var item in lPassenger)
        //        sb.AppendLine(item.ToString());


        //    File.WriteAllText(
        //        System.IO.Path.Combine(@"C:\WorkingFolder\Yehudit\YehuditProject\YehuditProject", "Passenger.csv"),
        //        sb.ToString(),
        //        Encoding.UTF8);

        //}

        //public bool EnoughSpaceForNextStation(Distance oDistance, Station sCurStation) {

        //    Station nextStation = oDistance.Station1.PassengerId == sCurStation.PassengerId ? oDistance.Station2 : oDistance.Station1;


        //    int count =  _lPassengersStations.Where(s =>
        //        s.Latitude == nextStation.Latitude &&
        //        s.Longitude == nextStation.Longitude)
        //            .ToList().Count;

        //    if (count > _iBusPassCount)
        //        return true;

        //    return _lTransportation[_lTransportation.Count - 1].Stations.Count + count <= _iBusPassCount;
        //}

        #endregion
    }


}
