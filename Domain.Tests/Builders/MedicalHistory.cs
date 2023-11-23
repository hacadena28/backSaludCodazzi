// using Domain.Entities;
//
// namespace Domain.Tests.Builders;
//
// public class MedicalHistoryBuilder
// {
//     private DateTime _date;
//     private string _description;
//     private string _diagnosis;
//     private string _treatment;
//     private Guid _doctorId;
//     private Guid _patientId;
//
//     public MedicalHistoryBuilder WithDate(DateTime date)
//     {
//         _date = date;
//         return this;
//     }
//
//     public MedicalHistoryBuilder WithDescription(string description)
//     {
//         _description = description;
//         return this;
//     }
//
//     public MedicalHistoryBuilder WithDiagnosis(string diagnosis)
//     {
//         _diagnosis = diagnosis;
//         return this;
//     }
//
//     public MedicalHistoryBuilder WithTreatment(string treatment)
//     {
//         _treatment = treatment;
//         return this;
//     }
//
//     public MedicalHistoryBuilder WithDoctor(Guid doctorId)
//     {
//         _doctorId = doctorId;
//         return this;
//     }
//
//     public MedicalHistoryBuilder WithPatient(Guid patientId)
//     {
//         _patientId = patientId;
//         return this;
//     }
//
//     public MedicalHistory Build()
//     {
//         return new MedicalHistory
//         (
//             _date,
//             _description,
//             _diagnosis,
//             _treatment,
//             _doctorId,
//             _patientId
//         );
//     }
// }