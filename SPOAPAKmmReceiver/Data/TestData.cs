using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPOAPAKmmReceiver.Entities;

namespace SPOAPAKmmReceiver.Data
{
    public static class TestData
    {
        public static ICollection<Organization> TestDataOrganizations { get; } = new List<Organization>
        {
            new()
            {
                Name = "ООО Рога и копыта",
                Address = "г. Н.Н.",
                Rooms = new List<Room>
                {
                    new Room()
                    {
                        Name = "317",
                        Devices = new List<Device>
                        {
                            new() { Type = "Анализатор спектра", Name = "R&S FSV40", Number = "11111111", },
                            new() { Type = "Генератор", Name = "R&S SMB100A", Number = "22222222", },
                            new() { Type = "Антенна", Name = "П6-151", Number = "33333333", },
                            new() { Type = "Антенна", Name = "П6-151", Number = "44444444", },
                        },
                        Elements = GetElements(),
                    }
                },
                Description = "",
            },
            new()
            {
                Name = "ООО Команд и Ко",
                Address = "г. Москва",
                Rooms = new List<Room>
                {
                    new Room()
                    {
                        Name = "215",
                        Devices = new List<Device>
                        {
                            new() { Type = "Анализатор спектра", Name = "R&S FSV40", Number = "11111111", },
                            new() { Type = "Генератор", Name = "R&S SMB100A", Number = "22222222", },
                            new() { Type = "Антенна", Name = "П6-151", Number = "33333333", },
                            new() { Type = "Антенна", Name = "П6-151", Number = "44444444", },
                        },
                        Elements = GetElements(),
                    }
                },
                Description = "",
            },
        };

        public static ICollection<Element> GetElements()
        {
            ICollection<Element> elements = new List<Element>
            {
                new()
                {
                    Name = "Дверь",
                    Points = GetMeasPoints(),
                },
            };

            return elements;
        }

        public static ICollection<MeasPoint> GetMeasPoints()
        {
            ICollection<MeasPoint> measPoints = new List<MeasPoint>
            {
                new()
                {
                    AverageE = 90,
                    DX = 0.2,
                    E = 90,
                    Measurings = GetMeasurings(),
                    Name = "Верх",
                },
            };

            return measPoints;
        }

        public static ICollection<Measuring> GetMeasurings()
        {
            Random rnd = new Random();
            ICollection<Measuring> measurings = new List<Measuring>();
            for (int i = 0; i < 5; i++)
            {
                double freq = rnd.Next(1000, 5000);
                double _P1 = rnd.Next(-60, -50);
                double _P2 = rnd.Next(-130, -120);
                Measuring meas = new Measuring()
                {
                    Freq = freq,
                    P1 = _P1,
                    P2 = _P2,
                };
                measurings.Add(meas);
            }

            return measurings;
        }
    }
}
