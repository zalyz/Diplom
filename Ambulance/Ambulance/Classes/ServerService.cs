using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace Ambulance.Classes
{
    //Обработка ошибок
    class ServerService
    {
        public static List<string> GetDepartments()
        {
            var listOfDepartments = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["DepartmentPath"]))
            {
                while(!reader.EndOfStream)
                {
                    listOfDepartments.Add(reader.ReadLine());
                }
            }

            return listOfDepartments;
        }

        public static List<string> GetCallers()
        {
            var listOfCallers = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["CallersPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfCallers.Add(reader.ReadLine());
                }
            }

            return listOfCallers;
        }

        public static List<string> GetBrigadeTypes()
        {
            var listOfTypes = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["TypesPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfTypes.Add(reader.ReadLine());
                }
            }

            return listOfTypes;
        }

        public static void AddDiagnosis(string diagnosis)
        {
            if (!GetDiagnoses().Contains(diagnosis))
            {
                using (var reader = new StreamWriter(ConfigurationManager.AppSettings["DiagnosisPath"], true))
                {
                    reader.WriteLine(diagnosis);
                }
            }
        }

        public static void RemoveDiagnosis(string diagnosis)
        {
            var listOfDiagnoses = GetDiagnoses();
            if (listOfDiagnoses.Contains(diagnosis))
            {
                listOfDiagnoses.Remove(diagnosis);
                using (var reader = new StreamWriter(ConfigurationManager.AppSettings["DiagnosisPath"]))
                {
                    foreach (var item in listOfDiagnoses)
                    {
                        reader.WriteLine(item);
                    }
                }
            }
        }

        public static List<string> GetDiagnoses()
        {
            var listOfDiagnosis = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["DiagnosisPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfDiagnosis.Add(reader.ReadLine());
                }
            }

            return listOfDiagnosis;
        }

        public static void AddStreet(string street)
        {
            if (!GetStreets().Contains(street))
            {
                using (var reader = new StreamWriter(ConfigurationManager.AppSettings["StreetsPath"], true))
                {
                    reader.WriteLine(street);
                }
            }
        }

        public static void RemoveStreet(string street)
        {
            var listOfDiagnoses = GetStreets();
            if (listOfDiagnoses.Contains(street))
            {
                listOfDiagnoses.Remove(street);
                using (var reader = new StreamWriter(ConfigurationManager.AppSettings["StreetsPath"]))
                {
                    foreach (var item in listOfDiagnoses)
                    {
                        reader.WriteLine(item);
                    }
                }
            }
        }

        public static List<string> GetStreets()
        {
            var listOfStreets = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["StreetsPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfStreets.Add(reader.ReadLine());
                }
            }

            return listOfStreets;
        }

        public static List<string> GetPlaces()
        {
            var listOfPlaces = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["PlacesPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfPlaces.Add(reader.ReadLine());
                }
            }

            return listOfPlaces;
        }

        public static List<string> GetTreatment()
        {
            var listOfTreatment = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["TreatmentPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfTreatment.Add(reader.ReadLine());
                }
            }

            return listOfTreatment;
        }

        public static List<string> GetResults()
        {
            var listOfResults = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["ResultsPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfResults.Add(reader.ReadLine());
                }
            }

            return listOfResults;
        }

        public static List<string> GetDirections()
        {
            var listOfDirections = new List<string>();
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["DirectionsPath"]))
            {
                while (!reader.EndOfStream)
                {
                    listOfDirections.Add(reader.ReadLine());
                }
            }

            return listOfDirections;
        }
    }
}
