using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class VehicleModelYear : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int ModelId { get; set; }
        public string ModelMakeId { get; set; }
        public string ModelName { get; set; }
        public string ModelTrim { get; set; }
        public int ModelYear { get; set; }
        public string ModelBodyStyle { get; set; }
        public string ModelEnginePosition { get; set; }
        public int ModelEngineCC { get; set; }
        public int ModelEngineNumCyl { get; set; }
        public string ModelEngineType { get; set; }
        public string ModelEngineValvesPerCyl { get; set; }
        public string ModelEnginePowerPS { get; set; }
        public string ModelEnginePowerRPM { get; set; }
        public string ModelEngineTorqueNM { get; set; }
        public string ModelEngineTorqueRPM { get; set; }
        public string ModelEngineBoreMM { get; set; }
        public string ModelEngineStrokeMM { get; set; }
        public string ModelEngineCompression { get; set; }
        public string ModelEngineFuel { get; set; }
        public string ModelTopSpeedKph { get; set; }
        public string Model0To100Kph { get; set; }
        public string ModelDrive { get; set; }
        public string ModelTransmissionType { get; set; }
        public string ModelSeats { get; set; }
        public string ModelDoors { get; set; }
        public int ModelWeightKg { get; set; }
        public int ModelLengthMM { get; set; }
        public int ModelWidthMM { get; set; }
        public int ModelHeightMM { get; set; }
        public int ModelWheelbase { get; set; }
        public string ModelLKmHwy { get; set; }
        public string ModelLKmMixed { get; set; }
        public string ModelLKmCity { get; set; }
        public string ModelFuelCapL { get; set; }
        public int ModelSoldInUs { get; set; }
        public string ModelCo2 { get; set; }
        public string ModelMakeDisplay { get; set; }


        public VehicleModelYear() { }

        public VehicleModelYear(
                int ModelId,
                string ModelMakeId,
                string ModelName,
                string ModelTrim,
                int ModelYear,
                string ModelBodyStyle,
                string ModelEnginePosition,
                int ModelEngineCC,
                int ModelEngineNumCyl,
                string ModelEngineType,
                string ModelEngineValvesPerCyl,
                string ModelEnginePowerPS,
                string ModelEnginePowerRPM,
                string ModelEngineTorqueNM,
                string ModelEngineTorqueRPM,
                string ModelEngineBoreMM,
                string ModelEngineStrokeMM,
                string ModelEngineCompression,
                string ModelEngineFuel,
                string ModelTopSpeedKph,
                string Model0To100Kph,
                string ModelDrive,
                string ModelTransmissionType,
                string ModelSeats,
                string ModelDoors,
                int ModelWeightKg,
                int ModelLengthMM,
                int ModelWidthMM,
                int ModelHeightMM,
                int ModelWheelbase,
                string ModelLKmHwy,
                string ModelLKmMixed,
                string ModelLKmCity,
                string ModelFuelCapL,
                int ModelSoldInUs,
                string ModelCo2,
                string ModelMakeDisplay)
        {
            this.ModelId = ModelId;
            this.ModelMakeId = ModelMakeId;
            this.ModelName = ModelName;
            this.ModelTrim = ModelTrim;
            this.ModelYear = ModelYear;
            this.ModelBodyStyle = ModelBodyStyle;
            this.ModelEnginePosition = ModelEnginePosition;
            this.ModelEngineCC = ModelEngineCC;
            this.ModelEngineNumCyl = ModelEngineNumCyl;
            this.ModelEngineType = ModelEngineType;
            this.ModelEngineValvesPerCyl = ModelEngineValvesPerCyl;
            this.ModelEnginePowerPS = ModelEnginePowerPS;
            this.ModelEnginePowerRPM = ModelEnginePowerRPM;
            this.ModelEngineTorqueNM = ModelEngineTorqueNM;
            this.ModelEngineTorqueRPM = ModelEngineTorqueRPM;
            this.ModelEngineBoreMM = ModelEngineBoreMM;
            this.ModelEngineStrokeMM = ModelEngineStrokeMM;
            this.ModelEngineCompression = ModelEngineCompression;
            this.ModelEngineFuel = ModelEngineFuel;
            this.ModelTopSpeedKph = ModelTopSpeedKph;
            this.Model0To100Kph = Model0To100Kph;
            this.ModelDrive = ModelDrive;
            this.ModelTransmissionType = ModelTransmissionType;
            this.ModelSeats = ModelSeats;
            this.ModelDoors = ModelDoors;
            this.ModelWeightKg = ModelWeightKg;
            this.ModelLengthMM = ModelLengthMM;
            this.ModelWidthMM = ModelWidthMM;
            this.ModelHeightMM = ModelHeightMM;
            this.ModelWheelbase = ModelWheelbase;
            this.ModelLKmHwy = ModelLKmHwy;
            this.ModelLKmMixed = ModelLKmMixed;
            this.ModelLKmCity = ModelLKmCity;
            this.ModelFuelCapL = ModelFuelCapL;
            this.ModelSoldInUs = ModelSoldInUs;
            this.ModelCo2 = ModelCo2;
            this.ModelLKmCity = ModelLKmCity;
            this.ModelMakeDisplay = ModelMakeDisplay;
        }
        # endregion

        #region Private Methods

        private static VehicleModelYear GetVehicleModelYearValuesFromiVehicleModelYear(iVehicleModelYear record)
        {
            if (record == null)
                return null;
            else
            {
                return new VehicleModelYear(
                    record.ModelId,
                    record.ModelMakeId,
                    record.ModelName,
                    record.ModelTrim,
                    record.ModelYear,
                    record.ModelBodyStyle,
                    record.ModelEnginePosition,
                    record.ModelEngineCC,
                    record.ModelEngineNumCyl,
                    record.ModelEngineType,
                    record.ModelEngineValvesPerCyl,
                    record.ModelEnginePowerPS,
                    record.ModelEnginePowerRPM,
                    record.ModelEngineTorqueNM,
                    record.ModelEngineTorqueRPM,
                    record.ModelEngineBoreMM,
                    record.ModelEngineStrokeMM,
                    record.ModelEngineCompression,
                    record.ModelEngineFuel,
                    record.ModelTopSpeedKph,
                    record.Model0To100Kph,
                    record.ModelDrive,
                    record.ModelTransmissionType,
                    record.ModelSeats,
                    record.ModelDoors,
                    record.ModelWeightKg,
                    record.ModelLengthMM,
                    record.ModelWidthMM,
                    record.ModelHeightMM,
                    record.ModelWheelbase,
                    record.ModelLKmHwy,
                    record.ModelLKmMixed,
                    record.ModelLKmCity,
                    record.ModelFuelCapL,
                    record.ModelSoldInUs,
                    record.ModelCo2,
                    record.ModelMakeDisplay
                    );
            }
        }

        private static List<VehicleModelYear> GetVehicleModelYearListFromiVehicleModelYear(List<iVehicleModelYear> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<VehicleModelYear> c = new List<VehicleModelYear>();
                foreach (iVehicleModelYear record in recordset)
                    c.Add(GetVehicleModelYearValuesFromiVehicleModelYear(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<VehicleModelYear> GetAllVehicleModelYear()
        {
            List<VehicleModelYear> VehicleModelYears = null;
            VehicleModelYears = GetVehicleModelYearListFromiVehicleModelYear(VehicleModelYearBase.Instance.SelectAll());
            return VehicleModelYears;
        }

        public static VehicleModelYear GetVehicleModelYearDetails(int id)
        {
            VehicleModelYear c = GetVehicleModelYearValuesFromiVehicleModelYear(VehicleModelYearBase.Instance.Select(id));
            return c;
        }

        public static string GetModelTrimByModelId(int ModelId)
        {
            VehicleModelYear c = GetVehicleModelYearValuesFromiVehicleModelYear(VehicleModelYearBase.Instance.Select(ModelId));
            return c.ModelTrim;
        }

        #endregion

    }
}
