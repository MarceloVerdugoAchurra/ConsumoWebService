using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTypeV;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;

namespace PegasusConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            bool DoProcessing = true;
            Int32 timeTimer = Int32.Parse(ConfigurationManager.AppSettings["tiempoTimer"]); 

            while (DoProcessing)
            {
                string token = "";
                token = getTokenFromPegasus();

                List<Vehicle> vehicles = new List<Vehicle>();
                vehicles = getAllVehicles(token);

                Console.WriteLine("Procesando información...");
                Thread.Sleep(timeTimer); //20000 (20 seconds); 5 minutos (300000)

            }
        }

        private static string getTokenFromPegasus()
        {
            var client = new RestClient("https://example.com/api/login");
            var request = new RestRequest(Method.POST);
            string contentResponse = "";
            string token = "";

            request.AddHeader("postman-token", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("origin", "anyvalue");
            request.AddHeader("content-type", "application/json");

            //recupera el user y password para token
            string user = ConfigurationManager.AppSettings["user"]; 
            string password = ConfigurationManager.AppSettings["password"]; 

            string uri = "{\"username\":\"$USER$\", \"password\":\"$PASSWORD$\"}";
            uri = uri.Replace("$USER$", user);
            uri = uri.Replace("$PASSWORD$", password);

            request.AddParameter("application/json", uri, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            contentResponse = response.Content;

            token = QuickType.Token.FromJson(contentResponse).Auth.ToString();

            return token;

        }

        private static List<Vehicle> getAllVehicles(string token)
        {

            var client = new RestClient("https://example.com/api/vehicles?auth=" + token);
            var request = new RestRequest(Method.GET);
            string contentResponse = "";

            //pojo completo
            QuickTypeV.Vehicles vehiclesJSON = new QuickTypeV.Vehicles();

            //objeto de salida vehicles
            List<Vehicle> vehiclesList = new List<Vehicle>();
            Vehicle vehicle;

            IRestResponse response = client.Execute(request);
            contentResponse = response.Content;

            vehiclesJSON = QuickTypeV.Vehicles.FromJson(contentResponse);

            foreach (Datum itemVehicle in vehiclesJSON.Data)
            {
                vehicle = new Vehicle();

                vehicle.Id = itemVehicle.Id;
                vehicle.Device = itemVehicle.Device;

                //acá debo obtener el ECU
                getVehicleGPS_Ecu(token, vehicle.Id.ToString());

                vehiclesList.Add(vehicle);
            }

            return vehiclesList;

        }

        private static string putZero(int numero)
        {
            if(numero < 10)
            {
                return "0" + numero.ToString();
            }else
            {
                return numero.ToString();
            }
        }

        private static void getVehicleGPS_Ecu(string token, string id_vehicle)
        {
            //string p_from = "2018-08-" + putZero(Convert.ToInt16(DateTime.Today.Day)) + "T00:00:00";
            //string p_to = "2018-08-" + putZero(Convert.ToInt16(DateTime.Today.Day)) + "T23:59:59";

            string p_from = "2018-08-17T00:00:00";
            string p_to = "2018-08-17T23:59:59";


            string p_fields = ConfigurationManager.AppSettings["camposECU"];

            string uri = "https://example.com/api/rawdata?from=$FROM$&to=$TO$&vehicles=$ID_VEHICLE$&fields=$FIELDS$&auth=$TOKEN$";
            uri = uri.Replace("$TOKEN$", token);
            uri = uri.Replace("$ID_VEHICLE$", id_vehicle);
            uri = uri.Replace("$FROM$", p_from);
            uri = uri.Replace("$TO$", p_to);
            uri = uri.Replace("$FIELDS$", p_fields);

            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET);
            string contentResponse = "";

            //pojo completo
            QuickTypeEcu.Ecu ecuJSON = new QuickTypeEcu.Ecu();

            IRestResponse response = client.Execute(request);
            contentResponse = response.Content;

            //este es el objeto que debo tener claro cual será el formato para producir el pojo respectivo
            ecuJSON = QuickTypeEcu.Ecu.FromJson(contentResponse);

            foreach (QuickTypeEcu.Event ecuItem in ecuJSON.Events)
            {

                proc_registro_BD(ecuItem, "EcuPg4", ecuItem.EcuPg4);
                proc_registro_BD(ecuItem, "EcuPg2", ecuItem.EcuPg2);
                proc_registro_BD(ecuItem, "EcuPg3", ecuItem.EcuPg3);
                proc_registro_BD(ecuItem, "EcuPg0", ecuItem.EcuPg0);
                proc_registro_BD(ecuItem, "EcuPg1", ecuItem.EcuPg1);
                proc_registro_BD(ecuItem, "EcuSpeedFlag", ecuItem.EcuSpeedFlag);
                proc_registro_BD(ecuItem, "EcuWeights", ecuItem.EcuWeights);
                proc_registro_BD(ecuItem, "EcuThrottle", ecuItem.EcuThrottle);
                proc_registro_BD(ecuItem, "EcuWithMilTime", ecuItem.EcuWithMilTime);
                proc_registro_BD(ecuItem, "EcuCoolLvl", ecuItem.EcuCoolLvl);
                proc_registro_BD(ecuItem, "EcuIntakeAirTmp", ecuItem.EcuIntakeAirTmp);
                proc_registro_BD(ecuItem, "EcuEidle", ecuItem.EcuEidle);
                proc_registro_BD(ecuItem, "EcuBrakePedal", ecuItem.EcuBrakePedal);
                proc_registro_BD(ecuItem, "EcuTorqueFlag", ecuItem.EcuTorqueFlag);
                proc_registro_BD(ecuItem, "EcuEngOilLvlFlag", ecuItem.EcuEngOilLvlFlag);
                proc_registro_BD(ecuItem, "EcuRbatt", ecuItem.EcuRbatt);
                proc_registro_BD(ecuItem, "EcuErrorsCount", ecuItem.EcuErrorsCount);
                proc_registro_BD(ecuItem, "EcuPtoFlag", ecuItem.EcuPtoFlag);
                proc_registro_BD(ecuItem, "EcuMilErrorCount", ecuItem.EcuMilErrorCount);
                proc_registro_BD(ecuItem, "EcuTransPsiFlag", ecuItem.EcuTransPsiFlag);
                proc_registro_BD(ecuItem, "EcuEngOilPsiFlag", ecuItem.EcuEngOilPsiFlag);
                proc_registro_BD(ecuItem, "EcuClutchPedal", ecuItem.EcuClutchPedal);
                proc_registro_BD(ecuItem, "EcuFuelIconsumptionFlag", ecuItem.EcuFuelIconsumptionFlag);
                proc_registro_BD(ecuItem, "EcuCoolPsi", ecuItem.EcuCoolPsi);
                proc_registro_BD(ecuItem, "EcuDefLevel", ecuItem.EcuDefLevel);
                proc_registro_BD(ecuItem, "EcuHours", ecuItem.EcuHours);
                proc_registro_BD(ecuItem, "EcuHydrOilTmpFlag", ecuItem.EcuHydrOilTmpFlag);
                proc_registro_BD(ecuItem, "EcuBattery", ecuItem.EcuBattery);
                proc_registro_BD(ecuItem, "EcuDist", ecuItem.EcuDist);
                proc_registro_BD(ecuItem, "EcuSpeed", ecuItem.EcuSpeed);
                proc_registro_BD(ecuItem, "EcuEon", ecuItem.EcuEon);
                proc_registro_BD(ecuItem, "EcuIfuel", ecuItem.EcuIfuel);
                proc_registro_BD(ecuItem, "EcuTransTmpFlag", ecuItem.EcuTransTmpFlag);
                proc_registro_BD(ecuItem, "EcuRpm", ecuItem.EcuRpm);
                proc_registro_BD(ecuItem, "EcuServDistanceFlag", ecuItem.EcuServDistanceFlag);
                proc_registro_BD(ecuItem, "EcuTfuel", ecuItem.EcuTfuel);
                proc_registro_BD(ecuItem, "EcuTripDistance", ecuItem.EcuTripDistance);
                proc_registro_BD(ecuItem, "EcuHydrOilPsiFlag", ecuItem.EcuHydrOilPsiFlag);
                proc_registro_BD(ecuItem, "EcuTransPsi", ecuItem.EcuTransPsi);
                proc_registro_BD(ecuItem, "EcuEngOilPsi", ecuItem.EcuEngOilPsi);
                proc_registro_BD(ecuItem, "EcuIdleFuelFlag", ecuItem.EcuIdleFuelFlag);
                proc_registro_BD(ecuItem, "EcuCcontrol", ecuItem.EcuCcontrol);
                proc_registro_BD(ecuItem, "EcuCoolLvlFlag", ecuItem.EcuCoolLvlFlag);
                proc_registro_BD(ecuItem, "EcuBrakePedalFlag", ecuItem.EcuBrakePedalFlag);
                proc_registro_BD(ecuItem, "EcuWithMilDistance", ecuItem.EcuWithMilDistance);
                proc_registro_BD(ecuItem, "EcuCoolTmpFlag", ecuItem.EcuCoolTmpFlag);
                proc_registro_BD(ecuItem, "EcuDefLevelFlag", ecuItem.EcuDefLevelFlag);
                proc_registro_BD(ecuItem, "EcuAload", ecuItem.EcuAload);
                proc_registro_BD(ecuItem, "EcuEload", ecuItem.EcuEload);
                proc_registro_BD(ecuItem, "EcuMilStateFlag", ecuItem.EcuMilStateFlag);
                proc_registro_BD(ecuItem, "EcuErrorFlag", ecuItem.EcuErrorFlag);
                proc_registro_BD(ecuItem, "EcuHydrOilLvlFlag", ecuItem.EcuHydrOilLvlFlag);
                proc_registro_BD(ecuItem, "EcuHydrOilTmp", ecuItem.EcuHydrOilTmp);
                proc_registro_BD(ecuItem, "EcuObdFtype", ecuItem.EcuObdFtype);
                proc_registro_BD(ecuItem, "EcuMilErrorCode", ecuItem.EcuMilErrorCode);
                proc_registro_BD(ecuItem, "EcuDistance", ecuItem.EcuDistance);
                proc_registro_BD(ecuItem, "EcuMaf", ecuItem.EcuMaf);
                proc_registro_BD(ecuItem, "EcuEngOilTmpFlag", ecuItem.EcuEngOilTmpFlag);
                proc_registro_BD(ecuItem, "EcuIntakeManifTmp", ecuItem.EcuIntakeManifTmp);
                proc_registro_BD(ecuItem, "EcuThrottleFlag", ecuItem.EcuThrottleFlag);
                proc_registro_BD(ecuItem, "EcuDdemandFlag", ecuItem.EcuDdemandFlag);
                proc_registro_BD(ecuItem, "EcuTiresTmp", ecuItem.EcuTiresTmp);
                proc_registro_BD(ecuItem, "EcuEngOilTmp", ecuItem.EcuEngOilTmp);
                proc_registro_BD(ecuItem, "EcuDdemand", ecuItem.EcuDdemand);
                proc_registro_BD(ecuItem, "EcuTransTmp", ecuItem.EcuTransTmp);
                proc_registro_BD(ecuItem, "EcuServDistance", ecuItem.EcuServDistance);
                proc_registro_BD(ecuItem, "EcuDefTmp", ecuItem.EcuDefTmp);
                proc_registro_BD(ecuItem, "EcuError1", ecuItem.EcuError1);
                proc_registro_BD(ecuItem, "EcuError2", ecuItem.EcuError2);
                proc_registro_BD(ecuItem, "EcuError3", ecuItem.EcuError3);
                proc_registro_BD(ecuItem, "EcuError4", ecuItem.EcuError4);
                proc_registro_BD(ecuItem, "EcuError5", ecuItem.EcuError5);
                proc_registro_BD(ecuItem, "EcuError6", ecuItem.EcuError6);
                proc_registro_BD(ecuItem, "EcuError7", ecuItem.EcuError7);
                proc_registro_BD(ecuItem, "EcuInsEfficiencyFlag", ecuItem.EcuInsEfficiencyFlag);
                proc_registro_BD(ecuItem, "EcuBatteryFlag", ecuItem.EcuBatteryFlag);
                proc_registro_BD(ecuItem, "EcuCoolPsiFlag", ecuItem.EcuCoolPsiFlag);
                proc_registro_BD(ecuItem, "EcuCoolTmp", ecuItem.EcuCoolTmp);
                proc_registro_BD(ecuItem, "EcuWeightsFlag", ecuItem.EcuWeightsFlag);
                proc_registro_BD(ecuItem, "EcuFuelLevelReal", ecuItem.EcuFuelLevelReal);
                proc_registro_BD(ecuItem, "EcuAmbientAirTmpFlag", ecuItem.EcuAmbientAirTmpFlag);
                proc_registro_BD(ecuItem, "EcuEusage", ecuItem.EcuEusage);
                proc_registro_BD(ecuItem, "EcuIdleFuel", ecuItem.EcuIdleFuel);
                proc_registro_BD(ecuItem, "EcuTiresTmpFlag", ecuItem.EcuTiresTmpFlag);
                proc_registro_BD(ecuItem, "EcuWithMilDistanceFlag", ecuItem.EcuWithMilDistanceFlag);
                proc_registro_BD(ecuItem, "EcuPto", ecuItem.EcuPto);
                proc_registro_BD(ecuItem, "EcuHydrOilPsi", ecuItem.EcuHydrOilPsi);
                proc_registro_BD(ecuItem, "EcuAmbientAirTmp", ecuItem.EcuAmbientAirTmp);
                proc_registro_BD(ecuItem, "EcuDefConsumedFlag", ecuItem.EcuDefConsumedFlag);
                proc_registro_BD(ecuItem, "EcuOxygen", ecuItem.EcuOxygen);
                proc_registro_BD(ecuItem, "EcuFuelLevelFlag", ecuItem.EcuFuelLevelFlag);
                proc_registro_BD(ecuItem, "EcuDefTmpFlag", ecuItem.EcuDefTmpFlag);
                proc_registro_BD(ecuItem, "EcuTransLvlFlag", ecuItem.EcuTransLvlFlag);
                proc_registro_BD(ecuItem, "EcuRpmFlag", ecuItem.EcuRpmFlag);
                proc_registro_BD(ecuItem, "EcuTotalFuelFlag", ecuItem.EcuTotalFuelFlag);
                proc_registro_BD(ecuItem, "EcuOxygenFlag", ecuItem.EcuOxygenFlag);
                proc_registro_BD(ecuItem, "EcuEngOilLvl", ecuItem.EcuEngOilLvl);
                proc_registro_BD(ecuItem, "EcuTorque", ecuItem.EcuTorque);
                proc_registro_BD(ecuItem, "EcuIntakeManifTmpFlag", ecuItem.EcuIntakeManifTmpFlag);
                proc_registro_BD(ecuItem, "EcuBpressure", ecuItem.EcuBpressure);
                proc_registro_BD(ecuItem, "EcuFanStateFlag", ecuItem.EcuFanStateFlag);
                proc_registro_BD(ecuItem, "EcuHoursIdleFlag", ecuItem.EcuHoursIdleFlag);
                proc_registro_BD(ecuItem, "EcuFanState", ecuItem.EcuFanState);
                proc_registro_BD(ecuItem, "EcuFpressure", ecuItem.EcuFpressure);
                proc_registro_BD(ecuItem, "EcuFuelIconsumption", ecuItem.EcuFuelIconsumption);
                proc_registro_BD(ecuItem, "EcuDtcCleared", ecuItem.EcuDtcCleared);
                proc_registro_BD(ecuItem, "EcuMilState", ecuItem.EcuMilState);
                proc_registro_BD(ecuItem, "EcuObdAuxios", ecuItem.EcuObdAuxios);
                proc_registro_BD(ecuItem, "EcuHydrOilLvl", ecuItem.EcuHydrOilLvl);
                proc_registro_BD(ecuItem, "EcuVin", ecuItem.EcuVin);
                proc_registro_BD(ecuItem, "EcuDistanceFlag", ecuItem.EcuDistanceFlag);
                proc_registro_BD(ecuItem, "EcuHoursFlag", ecuItem.EcuHoursFlag);
                proc_registro_BD(ecuItem, "EcuInsEfficiency", ecuItem.EcuInsEfficiency);
                proc_registro_BD(ecuItem, "EcuFuelLevel", ecuItem.EcuFuelLevel);
                proc_registro_BD(ecuItem, "EcuTripDistanceFlag", ecuItem.EcuTripDistanceFlag);
                proc_registro_BD(ecuItem, "EcuTransLvl", ecuItem.EcuTransLvl);
                proc_registro_BD(ecuItem, "EcuDefConsumed", ecuItem.EcuDefConsumed);
                proc_registro_BD(ecuItem, "EcuTotalFuel", ecuItem.EcuTotalFuel);
                proc_registro_BD(ecuItem, "EcuHoursIdle", ecuItem.EcuHoursIdle);
                proc_registro_BD(ecuItem, "EcuFuelLevelRealFlag", ecuItem.EcuFuelLevelRealFlag);

            }

        }

        private static void proc_registro_BD(QuickTypeEcu.Event ecuItem, string nameParam, string valueParam)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            using (SqlCommand cmd = new SqlCommand("SP_INS_PARAM_PEGASUS", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_vehicle", ecuItem.Vid);
                cmd.Parameters.AddWithValue("@nameParameter", nameParam);
                cmd.Parameters.AddWithValue("@valueParameter", (valueParam == null ? "" : valueParam));

                //cmd.Parameters.AddWithValue("@system_time", Convert.ToDateTime(ecuItem.SystemTime).ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@systemTime", Convert.ToDateTime(ecuItem.SystemTime.DateTime));
                //cmd.Parameters.AddWithValue("@event_time", Convert.ToDateTime(ecuItem.EventTime).ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@eventTime", Convert.ToDateTime(ecuItem.EventTime.DateTime));

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

    }
}
