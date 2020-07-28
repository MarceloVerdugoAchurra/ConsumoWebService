// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var ecu = Ecu.FromJson(jsonString);

namespace QuickTypeEcu
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Ecu
    {
        [JsonProperty("units")]
        public Units Units { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("ecu_pg4")]
        public string EcuPg4 { get; set; }

        [JsonProperty("ecu_pg2")]
        public string EcuPg2 { get; set; }

        [JsonProperty("ecu_pg3")]
        public string EcuPg3 { get; set; }

        [JsonProperty("ecu_pg0")]
        public string EcuPg0 { get; set; }

        [JsonProperty("ecu_pg1")]
        public string EcuPg1 { get; set; }

        [JsonProperty("ecu_speed_flag")]
        public string EcuSpeedFlag { get; set; }

        [JsonProperty("ecu_weights")]
        public string EcuWeights { get; set; }

        [JsonProperty("ecu_throttle")]
        public string EcuThrottle { get; set; }

        [JsonProperty("ecu_with_mil_time")]
        public string EcuWithMilTime { get; set; }

        [JsonProperty("event_time")]
        public DateTimeOffset EventTime { get; set; }

        [JsonProperty("ecu_cool_lvl")]
        public string EcuCoolLvl { get; set; }

        [JsonProperty("ecu_intake_air_tmp")]
        public string EcuIntakeAirTmp { get; set; }

        [JsonProperty("ecu_eidle")]
        public string EcuEidle { get; set; }

        [JsonProperty("ecu_brake_pedal")]
        public string EcuBrakePedal { get; set; }

        [JsonProperty("ecu_torque_flag")]
        public string EcuTorqueFlag { get; set; }

        [JsonProperty("ecu_eng_oil_lvl_flag")]
        public string EcuEngOilLvlFlag { get; set; }

        [JsonProperty("ecu_rbatt")]
        public string EcuRbatt { get; set; }

        [JsonProperty("ecu_errors_count")]
        public string EcuErrorsCount { get; set; }

        [JsonProperty("ecu_pto_flag")]
        public string EcuPtoFlag { get; set; }

        [JsonProperty("ecu_mil_error_count")]
        public string EcuMilErrorCount { get; set; }

        [JsonProperty("ecu_trans_psi_flag")]
        public string EcuTransPsiFlag { get; set; }

        [JsonProperty("ecu_eng_oil_psi_flag")]
        public string EcuEngOilPsiFlag { get; set; }

        [JsonProperty("ecu_clutch_pedal")]
        public string EcuClutchPedal { get; set; }

        [JsonProperty("ecu_fuel_iconsumption_flag")]
        public string EcuFuelIconsumptionFlag { get; set; }

        [JsonProperty("system_time")]
        public DateTimeOffset SystemTime { get; set; }

        [JsonProperty("ecu_cool_psi")]
        public string EcuCoolPsi { get; set; }

        [JsonProperty("ecu_def_level")]
        public string EcuDefLevel { get; set; }

        [JsonProperty("ecu_hours")]
        public string EcuHours { get; set; }

        [JsonProperty("ecu_hydr_oil_tmp_flag")]
        public string EcuHydrOilTmpFlag { get; set; }

        [JsonProperty("ecu_battery")]
        public string EcuBattery { get; set; }

        [JsonProperty("ecu_dist")]
        public string EcuDist { get; set; }

        [JsonProperty("ecu_speed")]
        public string EcuSpeed { get; set; }

        [JsonProperty("ecu_eon")]
        public string EcuEon { get; set; }

        [JsonProperty("ecu_ifuel")]
        public string EcuIfuel { get; set; }

        [JsonProperty("ecu_trans_tmp_flag")]
        public string EcuTransTmpFlag { get; set; }

        [JsonProperty("ecu_rpm")]
        public string EcuRpm { get; set; }

        [JsonProperty("ecu_serv_distance_flag")]
        public string EcuServDistanceFlag { get; set; }

        [JsonProperty("ecu_tfuel")]
        public string EcuTfuel { get; set; }

        [JsonProperty("ecu_trip_distance")]
        public string EcuTripDistance { get; set; }

        [JsonProperty("ecu_hydr_oil_psi_flag")]
        public string EcuHydrOilPsiFlag { get; set; }

        [JsonProperty("ecu_trans_psi")]
        public string EcuTransPsi { get; set; }

        [JsonProperty("ecu_eng_oil_psi")]
        public string EcuEngOilPsi { get; set; }

        [JsonProperty("ecu_idle_fuel_flag")]
        public string EcuIdleFuelFlag { get; set; }

        [JsonProperty("ecu_ccontrol")]
        public string EcuCcontrol { get; set; }

        [JsonProperty("ecu_cool_lvl_flag")]
        public string EcuCoolLvlFlag { get; set; }

        [JsonProperty("ecu_brake_pedal_flag")]
        public string EcuBrakePedalFlag { get; set; }

        [JsonProperty("ecu_with_mil_distance")]
        public string EcuWithMilDistance { get; set; }

        [JsonProperty("ecu_cool_tmp_flag")]
        public string EcuCoolTmpFlag { get; set; }

        [JsonProperty("ecu_def_level_flag")]
        public string EcuDefLevelFlag { get; set; }

        [JsonProperty("ecu_aload")]
        public string EcuAload { get; set; }

        [JsonProperty("ecu_eload")]
        public string EcuEload { get; set; }

        [JsonProperty("ecu_mil_state_flag")]
        public string EcuMilStateFlag { get; set; }

        [JsonProperty("ecu_error_flag")]
        public string EcuErrorFlag { get; set; }

        [JsonProperty("ecu_hydr_oil_lvl_flag")]
        public string EcuHydrOilLvlFlag { get; set; }

        [JsonProperty("ecu_hydr_oil_tmp")]
        public string EcuHydrOilTmp { get; set; }

        [JsonProperty("ecu_obd_ftype")]
        public string EcuObdFtype { get; set; }

        [JsonProperty("ecu_mil_error_code")]
        public string EcuMilErrorCode { get; set; }

        [JsonProperty("ecu_distance")]
        public string EcuDistance { get; set; }

        [JsonProperty("ecu_maf")]
        public string EcuMaf { get; set; }

        [JsonProperty("ecu_eng_oil_tmp_flag")]
        public string EcuEngOilTmpFlag { get; set; }

        [JsonProperty("ecu_intake_manif_tmp")]
        public string EcuIntakeManifTmp { get; set; }

        [JsonProperty("ecu_throttle_flag")]
        public string EcuThrottleFlag { get; set; }

        [JsonProperty("ecu_ddemand_flag")]
        public string EcuDdemandFlag { get; set; }

        [JsonProperty("ecu_tires_tmp")]
        public string EcuTiresTmp { get; set; }

        [JsonProperty("vid")]
        public long Vid { get; set; }

        [JsonProperty("ecu_eng_oil_tmp")]
        public string EcuEngOilTmp { get; set; }

        [JsonProperty("ecu_ddemand")]
        public string EcuDdemand { get; set; }

        [JsonProperty("ecu_trans_tmp")]
        public string EcuTransTmp { get; set; }

        [JsonProperty("ecu_serv_distance")]
        public string EcuServDistance { get; set; }

        [JsonProperty("ecu_def_tmp")]
        public string EcuDefTmp { get; set; }

        [JsonProperty("ecu_error1")]
        public string EcuError1 { get; set; }

        [JsonProperty("ecu_error2")]
        public string EcuError2 { get; set; }

        [JsonProperty("ecu_error3")]
        public string EcuError3 { get; set; }

        [JsonProperty("ecu_error4")]
        public string EcuError4 { get; set; }

        [JsonProperty("ecu_error5")]
        public string EcuError5 { get; set; }

        [JsonProperty("ecu_error6")]
        public string EcuError6 { get; set; }

        [JsonProperty("ecu_error7")]
        public string EcuError7 { get; set; }

        [JsonProperty("ecu_ins_efficiency_flag")]
        public string EcuInsEfficiencyFlag { get; set; }

        [JsonProperty("ecu_battery_flag")]
        public string EcuBatteryFlag { get; set; }

        [JsonProperty("ecu_cool_psi_flag")]
        public string EcuCoolPsiFlag { get; set; }

        [JsonProperty("ecu_cool_tmp")]
        public string EcuCoolTmp { get; set; }

        [JsonProperty("ecu_weights_flag")]
        public string EcuWeightsFlag { get; set; }

        [JsonProperty("ecu_fuel_level_real")]
        public string EcuFuelLevelReal { get; set; }

        [JsonProperty("ecu_ambient_air_tmp_flag")]
        public string EcuAmbientAirTmpFlag { get; set; }

        [JsonProperty("ecu_eusage")]
        public string EcuEusage { get; set; }

        [JsonProperty("ecu_idle_fuel")]
        public string EcuIdleFuel { get; set; }

        [JsonProperty("ecu_tires_tmp_flag")]
        public string EcuTiresTmpFlag { get; set; }

        [JsonProperty("ecu_with_mil_distance_flag")]
        public string EcuWithMilDistanceFlag { get; set; }

        [JsonProperty("ecu_pto")]
        public string EcuPto { get; set; }

        [JsonProperty("ecu_hydr_oil_psi")]
        public string EcuHydrOilPsi { get; set; }

        [JsonProperty("ecu_ambient_air_tmp")]
        public string EcuAmbientAirTmp { get; set; }

        [JsonProperty("ecu_def_consumed_flag")]
        public string EcuDefConsumedFlag { get; set; }

        [JsonProperty("ecu_oxygen")]
        public string EcuOxygen { get; set; }

        [JsonProperty("ecu_fuel_level_flag")]
        public string EcuFuelLevelFlag { get; set; }

        [JsonProperty("ecu_def_tmp_flag")]
        public string EcuDefTmpFlag { get; set; }

        [JsonProperty("ecu_trans_lvl_flag")]
        public string EcuTransLvlFlag { get; set; }

        [JsonProperty("ecu_rpm_flag")]
        public string EcuRpmFlag { get; set; }

        [JsonProperty("ecu_total_fuel_flag")]
        public string EcuTotalFuelFlag { get; set; }

        [JsonProperty("ecu_oxygen_flag")]
        public string EcuOxygenFlag { get; set; }

        [JsonProperty("ecu_eng_oil_lvl")]
        public string EcuEngOilLvl { get; set; }

        [JsonProperty("ecu_torque")]
        public string EcuTorque { get; set; }

        [JsonProperty("ecu_intake_manif_tmp_flag")]
        public string EcuIntakeManifTmpFlag { get; set; }

        [JsonProperty("ecu_bpressure")]
        public string EcuBpressure { get; set; }

        [JsonProperty("ecu_fan_state_flag")]
        public string EcuFanStateFlag { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ecu_hours_idle_flag")]
        public string EcuHoursIdleFlag { get; set; }

        [JsonProperty("ecu_fan_state")]
        public string EcuFanState { get; set; }

        [JsonProperty("ecu_fpressure")]
        public string EcuFpressure { get; set; }

        [JsonProperty("ecu_fuel_iconsumption")]
        public string EcuFuelIconsumption { get; set; }

        [JsonProperty("ecu_dtc_cleared")]
        public string EcuDtcCleared { get; set; }

        [JsonProperty("ecu_mil_state")]
        public string EcuMilState { get; set; }

        [JsonProperty("ecu_obd_auxios")]
        public string EcuObdAuxios { get; set; }

        [JsonProperty("ecu_hydr_oil_lvl")]
        public string EcuHydrOilLvl { get; set; }

        [JsonProperty("ecu_vin")]
        public string EcuVin { get; set; }

        [JsonProperty("ecu_distance_flag")]
        public string EcuDistanceFlag { get; set; }

        [JsonProperty("ecu_hours_flag")]
        public string EcuHoursFlag { get; set; }

        [JsonProperty("ecu_ins_efficiency")]
        public string EcuInsEfficiency { get; set; }

        [JsonProperty("ecu_fuel_level")]
        public string EcuFuelLevel { get; set; }

        [JsonProperty("ecu_trip_distance_flag")]
        public string EcuTripDistanceFlag { get; set; }

        [JsonProperty("ecu_trans_lvl")]
        public string EcuTransLvl { get; set; }

        [JsonProperty("ecu_def_consumed")]
        public string EcuDefConsumed { get; set; }

        [JsonProperty("ecu_total_fuel")]
        public string EcuTotalFuel { get; set; }

        [JsonProperty("ecu_hours_idle")]
        public string EcuHoursIdle { get; set; }

        [JsonProperty("ecu_fuel_level_real_flag")]
        public string EcuFuelLevelRealFlag { get; set; }
    }

    public partial class Units
    {
        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public partial class Ecu
    {
        public static Ecu FromJson(string json) => JsonConvert.DeserializeObject<Ecu>(json, QuickTypeEcu.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Ecu self) => JsonConvert.SerializeObject(self, QuickTypeEcu.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
