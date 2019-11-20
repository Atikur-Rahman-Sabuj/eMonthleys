namespace eMonthleys.DAL
{
    public class iVehicleModelYear
    {
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



        public iVehicleModelYear() { }

        public iVehicleModelYear(
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
    }
}
