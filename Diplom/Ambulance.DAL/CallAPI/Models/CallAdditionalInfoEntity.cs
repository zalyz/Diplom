using System;

namespace Ambulance.DAL.CallAPI.Models
{
    public class CallAdditionalInfoEntity
    {
        public int Id { get; set; }

        public int CallId { get; set; }

        public byte AdditionalInfoType { get; set; }

        public byte? UnsuccessfulDeparture { get; set; }

        public DateTime? DateAndTimeOfDeterioration { get; set; }

        public byte? InjuryType { get; set; }

        public string InjuryTypeDescription { get; set; }

        public string Complaints { get; set; }

        public string Anamnesis { get; set; }

        public string ListedDiseases { get; set; }

        public string ObstetricAndGynecologicalAnamnesis { get; set; }

        public string Allergy { get; set; }

        // общее состояние
        public byte? CommonState { get; set; }

        public byte? Position { get; set; }

        public byte? Behaviour { get; set; }

        public string BehaviourDescription { get; set; }

        public int? GlasgowComaScale { get; set; }

        // сознание
        public byte? Conscience { get; set; }

        public byte? PupilCondition { get; set; }

        public bool? ReactionToLight { get; set; }

        public byte? SpeechState { get; set; }

        public string SpeechStateDescription { get; set; }

        public byte? Gait { get; set; }

        public string GaitDescription { get; set; }

        public bool? IsFaceSymmetrical { get; set; }

        public byte? Nystagmus { get; set; }

        public string MuscleTone { get; set; }

        public string PathologicalReflexes { get; set; }

        public string MeningealSigns { get; set; }

        public string PlegiasAndParesis { get; set; }

        public byte? SkinType { get; set; }

        public string SkinTypeDescription { get; set; }

        public string MucousMembranesDescription { get; set; }

        public string TongueDescription { get; set; }

        public string BloodPressure { get; set; }

        public string AdaptedBloodPressure { get; set; }

        public byte? HeartTones { get; set; }

        public int? Pulse { get; set; }

        public int? ShockIndex { get; set; }

        public bool? Ascites { get; set; }

        public bool? Edema { get; set; }

        public string EdemaDescription { get; set; }

        public int? RespiratoryRate { get; set; }

        public byte? RespiratoryState { get; set; }

        public byte? PercussionOfTheLungs { get; set; }

        public string PercussionOfTheLungsDescription { get; set; }

        public byte? StomachState { get; set; }

        public string StomachStateDescription { get; set; }

        public bool? Peristalsis { get; set; }

        public string PeristalsisDescription { get; set; }

        public byte? LiverState { get; set; }

        public string LiverStateDescription { get; set; }

        public byte? Urination { get; set; }

        public string UrinationDescription { get; set; }

        public byte? BowelState { get; set; }

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

        public byte? MedicalCareResult { get; set; }

        public byte? Death { get; set; }

        public byte? Result { get; set; }

        public string ResultDescription { get; set; }

        public DateTime? TransportationDateTime { get; set; }

        public byte? ToBrigadeCar { get; set; }

        public byte? FromBrigadeCar { get; set; }

        public byte? TransportationPosition { get; set; }

        public string PatientConditionDuringTransportation { get; set; }

        public byte? DynamicsBefore { get; set; }

        public string PatientConditionAfterTransportation { get; set; }

        public byte? DynamicsAfter { get; set; }

        public DateTime? FinishTransportationDateTime { get; set; }

        public string TranspotedToOrganisation { get; set; }

        public string MedicalWorkerFIO { get; set; }
    }
}
