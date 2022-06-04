using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models.Statistics
{
    public class CallFullInfo
    {
        public string FIO { get; set; }

        public int Age { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public Gender Gender { get; set; }

        public string DoktorFIO { get; set; }

        public string FirstMedicalAssistantFIO { get; set; }

        public string SecondMedicalAssistantFIO { get; set; }

        public string OrderlyFIO { get; set; }

        public string DriverFIO { get; set; }

        public int BrigadeNumber { get; set; }

        public string Dispatcher { get; set; }

        public int CallNumber { get; set; }

        public string ResultName { get; set; }

        public string DiagnosisName { get; set; }

        public string CallerName { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public string TransferingDispatcher { get; set; }

        public string ProcessingDispatcher { get; set; }

        public int KilometrageBefor { get; set; }

        public int KilometrageAfter { get; set; }

        public string PlaceName { get; set; }

        public string CallNotes { get; set; }

        public string Type { get; set; }

        public AdditionalInfoType AdditionalInfoType { get; set; }

        public UnsuccessfulDeparture? UnsuccessfulDeparture { get; set; }

        public DateTime? DateAndTimeOfDeterioration { get; set; }

        public InjuryType? InjuryType { get; set; }

        public string InjuryTypeDescription { get; set; }

        public string Complaints { get; set; }

        public string Anamnesis { get; set; }

        public string ListedDiseases { get; set; }

        public string ObstetricAndGynecologicalAnamnesis { get; set; }

        public string Allergy { get; set; }

        public CommonState? CommonState { get; set; }

        public Position? Position { get; set; }

        public Behaviour? Behaviour { get; set; }

        public string BehaviourDescription { get; set; }

        public int GlasgowComaScale { get; set; }

        public Сonscience? Сonscience { get; set; }

        public PupilCondition? PupilCondition { get; set; }

        public bool? ReactionToLight { get; set; }

        public SpeechState? SpeechState { get; set; }

        public string SpeechStateDescription { get; set; }

        public Gait? Gait { get; set; }

        public string GaitDescription { get; set; }

        public bool? IsFaceSymmetrical { get; set; }

        public Nystagmus? Nystagmus { get; set; }

        public string MuscleTone { get; set; }

        public string PathologicalReflexes { get; set; }

        public string MeningealSigns { get; set; }

        public string PlegiasAndParesis { get; set; }

        public SkinType? SkinType { get; set; }

        public string SkinTypeDescription { get; set; }

        public string MucousMembranesDescription { get; set; }

        public string TongueDescription { get; set; }

        public string BloodPressure { get; set; }

        public string AdaptedBloodPressure { get; set; }

        public HeartTones? HeartTones { get; set; }

        public int? Pulse { get; set; }

        public int? ShockIndex { get; set; }

        public bool? Ascites { get; set; }

        public bool? Edema { get; set; }

        public string EdemaDescription { get; set; }

        public int? RespiratoryRate { get; set; }

        public RespiratoryState? RespiratoryState { get; set; }

        public PercussionOfTheLungs? PercussionOfTheLungs { get; set; }

        public string PercussionOfTheLungsDescription { get; set; }

        public StomachState? StomachState { get; set; }

        public string StomachStateDescription { get; set; }

        public bool? Peristalsis { get; set; }

        public string PeristalsisDescription { get; set; }

        public LiverState? LiverState { get; set; }

        public string LiverStateDescription { get; set; }

        public Urination? Urination { get; set; }

        public string UrinationDescription { get; set; }

        public BowelState? BowelState { get; set; }

        public string BowelStateDescription { get; set; }

        public string LocalStatus { get; set; }

        public string Electrocardiogram { get; set; }

        public string SecondElectrocardiogram { get; set; }

        public decimal? GlycemiaBefore { get; set; }

        public decimal? GlycemiaAfter { get; set; }

        public decimal? SaturationBefore { get; set; }

        public decimal? SaturationAfter { get; set; }

        public string DiagnosisCode { get; set; }

        public bool? RefusalToProvideMedicalCare { get; set; }

        public string PatienStateAfterMedicalCare { get; set; }

        public MedicalCareResult? MedicalCareResult { get; set; }

        public Death? Death { get; set; }

        public ResultType? Result { get; set; }

        public string ResultDescription { get; set; }

        public DateTime? TransportationDateTime { get; set; }

        public TransportationType? ToBrigadeCar { get; set; }

        public TransportationType? FromBrigadeCar { get; set; }

        public TransportationPosition? TransportationPosition { get; set; }

        public string PatientConditionDuringTransportation { get; set; }

        public Dynamics? DynamicsBefore { get; set; }

        public string PatientConditionAfterTransportation { get; set; }

        public Dynamics? DynamicsAfter { get; set; }

        public DateTime? FinishTransportationDateTime { get; set; }

        public string TranspotedToOrganisation { get; set; }

        public string MedicalWorkerFIO { get; set; }
    }
}
