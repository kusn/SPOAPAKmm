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
                        Devices = GetDevices(),
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
                        Devices = GetDevices(),
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
                    Name = "Верх",
                    MeasureItems = GetMeasurings(),
                },
            };

            return measPoints;
        }

        public static ICollection<MeasureItem> GetMeasurings()
        {
            Random rnd = new Random();
            ICollection<MeasureItem> measurings = new List<MeasureItem>();
            for (int i = 0; i < 5; i++)
            {
                double freq = rnd.Next(1000, 5000);
                double _P1 = rnd.Next(-60, -50);
                double _P2 = rnd.Next(-130, -120);
                string _E = "";
                MeasureItem meas = new MeasureItem()
                {
                    Freq = freq,
                    P1 = _P1,
                    P2 = _P2,
                    E = _E,
                };
                measurings.Add(meas);
            }

            return measurings;
        }

        public static ICollection<Device> GetDevices()
        {
            ICollection<Device> devices = new List<Device>();
            devices = new List<Device>
            {
                new()
                {
                    Type = GeDeviceTypes().FirstOrDefault(t => t.Name == "Анализатор спектра"),
                    Name = "R&S FSV40",
                    Number = "11111111",
                    Range = new MeasRange() { SartFreq = 0.00001, EndFreq = 40000},
                    VerificationDate = new DateTime(2001,01,01),
                    
                },
                new()
                {
                    Type = GeDeviceTypes().FirstOrDefault(t => t.Name == "Генератор"),
                    Name = "R&S SMB100A",
                    Number = "22222222",
                    Range = new MeasRange() { SartFreq = 0.1, EndFreq = 40000},
                    VerificationDate = new DateTime(2001,01,01),
                },
                new()
                {
                    Type = GeDeviceTypes().FirstOrDefault(t => t.Name == "Антенна"),
                    Name = "П6-151",
                    Number = "33333333",
                    Range = new MeasRange() { SartFreq = 800, EndFreq = 16000},
                    VerificationDate = new DateTime(2001,01,01),
                },
                new()
                {
                    Type = GeDeviceTypes().FirstOrDefault(t => t.Name == "Антенна"),
                    Name = "П6-151",
                    Number = "44444444",
                    Range = new MeasRange() { SartFreq = 800, EndFreq = 16000},
                    VerificationDate = new DateTime(2001,01,01),
                },
            };
            return devices;
        }

        public static ICollection<DeviceType> GeDeviceTypes()
        {
            ICollection<DeviceType> deviceTypes = new List<DeviceType>();
            deviceTypes.Add(new DeviceType() { Name = "Анализатор спектра" });
            deviceTypes.Add(new DeviceType() { Name = "Генератор" });
            deviceTypes.Add(new DeviceType() { Name = "Антенна" });
            return deviceTypes;
        }
    }
}
