using System;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SPOAPAKmmReceiver.Extensions;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Infrastructure.Commands.Base;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private IStore<Organization> _dBOrganization;
        private IStore<Room> _dBRoom;
        private IStore<Element> _dBElement;
        private IStore<Device> _dBDevice;
        private IStore<MeasPoint> _dBMeasPoint;
        private IStore<Measuring> _dBMeasuring;
        
        private bool _isSelected;
        private bool _isChanged;
        private object _selectedValue;
        private Page _userPage;
        private Organization _selectedOrganization;
        private Room _selectedRoom;
        private Element _selectedElement;
        private MeasPoint _selectedPoint;
        private ViewModel _selectedViewModel;
        private Visibility _isVisibilityOrganization = Visibility.Collapsed;
        private Visibility _isVisibilityRoom = Visibility.Collapsed;
        private Visibility _isVisibilityElement = Visibility.Collapsed;
        private Visibility _isVisibilityPoint = Visibility.Collapsed;
        private Visibility _isVisibilityTabControl = Visibility.Hidden;
        private int _selectedTab = 0;
        private string _selectedOrganizationName;
        private string? _selectedOrganizationDescription;
        private string? _selectedOrganizationAddress;
        private string _selectedRoomName;
        private string? _selectedRoomDescription;
        private string _selectedElementName;
        private string? _selectedElementDescription;
        private string _selectedPointName;
        private string? _selectedPointDescription;
        private ICollection<Measuring> _selectedPointMeasurings;
        private string _originalselectedOrganizationName;
        private string? _originalselectedOrganizationDescription;
        private string? _originalselectedOrganizationAddress;
        private string _originalselectedRoomName;
        private string? _originalselectedRoomDescription;
        private string _originalselectedElementName;
        private string? _originalselectedElementDescription;
        private string _originalselectedPointName;
        private string? _originalselectedPointDescription;
        private ICollection<Measuring> _originalselectedPointMeasurings;

        public ObservableCollection<Organization> Organizations { get; set; }
        //public SortableObservableCollection<Organization> Organizations { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Element> Elements { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<MeasPoint> Points { get; set; }
        public ObservableCollection<Measuring> Measurings { get; set; }

        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set => Set(ref _selectedOrganization, value);
        }
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }
        public Element SelectedElement
        {
            get => _selectedElement;
            set => Set(ref _selectedElement, value);
        }
        public MeasPoint SelectedPoint
        {
            get => _selectedPoint;
            set => Set(ref _selectedPoint, value);
        }
        public Visibility IsVisibilityOrganization
        {
            get => _isVisibilityOrganization;
            set => Set(ref _isVisibilityOrganization, value);
        }
        public Visibility IsVisibilityRoom
        {
            get => _isVisibilityRoom;
            set => Set(ref _isVisibilityRoom, value);
        }
        public Visibility IsVisibilityElement
        {
            get => _isVisibilityElement;
            set => Set(ref _isVisibilityElement, value);
        }
        public Visibility IsVisibilityPoint
        {
            get => _isVisibilityPoint;
            set => Set(ref _isVisibilityPoint, value);
        }
        public Visibility IsVisibilityTabControl
        {
            get => _isVisibilityTabControl;
            set => Set(ref _isVisibilityTabControl, value);
        }
        public int SelectedTab
        {
            get => _selectedTab;
            set => Set(ref _selectedTab, value);
        }
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
        public bool IsChanged
        {
            get => _isChanged;
            set => Set(ref _isChanged, value);
        }
        public object SelectedValue
        {
            get => _selectedValue;
            set
            {
                Set(ref _selectedValue, value);
                OpenValue(value);
                IsChanged = false;
            }
        }
        public string SelectedOrganizationName
        {
            get => _selectedOrganizationName;
            set
            {
                Set(ref _selectedOrganizationName, value);
                IsChanged = IsChangeText(_originalselectedOrganizationName, value);
            } 
        }
        public string? SelectedOrganizationAddress
        {
            get => _selectedOrganizationAddress;
            set
            {
                Set(ref _selectedOrganizationAddress, value);
                IsChanged = IsChangeText(_originalselectedOrganizationAddress, value);
            }
        }
        public string? SelectedOrganizationDescription
        {
            get => _selectedOrganizationDescription;
            set
            {
                Set(ref _selectedOrganizationDescription, value);
                IsChanged = IsChangeText(_originalselectedOrganizationDescription, value);
            }
        }
        public string SelectedRoomName
        {
            get => _selectedRoomName;
            set
            {
                Set(ref _selectedRoomName, value);
                IsChanged = IsChangeText(_originalselectedRoomName, value);
            }
        }
        public string? SelectedRoomDescription
        {
            get => _selectedRoomDescription;
            set
            {
                Set(ref _selectedRoomDescription, value);
                IsChanged = IsChangeText(_originalselectedRoomDescription, value);
            }
        }
        public string SelectedElementName
        {
            get => _selectedElementName;
            set
            {
                Set(ref _selectedElementName, value);
                IsChanged = IsChangeText(_originalselectedElementName, value);
            }
        }
        public string? SelectedElementDescription
        {
            get => _selectedElementDescription;
            set
            {
                Set(ref _selectedElementDescription, value);
                IsChanged = IsChangeText(_originalselectedElementDescription, value);
            }
        }
        public string SelectedPointName
        {
            get => _selectedPointName;
            set
            {
                Set(ref _selectedPointName, value);
                IsChanged = IsChangeText(_originalselectedPointName, value);
            }
        }
        public string? SelectedPointDescription
        {
            get => _selectedPointDescription;
            set
            {
                Set(ref _selectedPointDescription, value);
                IsChanged = IsChangeText(_originalselectedPointDescription, value);
            }
        }

        public ICollection<Measuring> SelectedPointMeasurings
        {
            get => _selectedPointMeasurings;
            set => Set(ref _selectedPointMeasurings, value);
        }

        public IStore<Organization> DbOrganizationStore { get; set; }
        public IStore<Room> DbRoomStore { get; set; }
        public IStore<Element> DbElementStore { get; set; }
        public IStore<MeasPoint> DbPointStore { get; set; }
        public IStore<Device> DbDeviceStore { get; set; }
        public IStore<Measuring> DbMeasuringStore { get; set; }

        public ViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }
        public Page UserPage
        {
            get => _userPage;
            set => Set(ref _userPage, value);
        }

        public MainWindowViewModel(IStore<Organization> dBOrganization,
            IStore<Room> dBRoom,
            IStore<Element> dBElement,
            IStore<Device> dBDevice,
            IStore<MeasPoint> dBMeasPoint,
            IStore<Measuring> dBMeasuring)
        {
            DbOrganizationStore = dBOrganization;
            DbRoomStore = dBRoom;
            DbElementStore = dBElement;
            DbDeviceStore = dBDevice;
            DbPointStore = dBMeasPoint;
            DbMeasuringStore = dBMeasuring;

#if DEBUG
            IEnumerable<Organization> organizationsInDb = new List<Organization>();
            organizationsInDb = DbOrganizationStore.GetAll();

            var c = organizationsInDb.Count();

            foreach (var org in TestData.TestDataOrganizations)
            {
                if(c == 0 || (organizationsInDb.FirstOrDefault(o => o.Name == org.Name) == null))
                    DbOrganizationStore.Add(org);
            }
#endif
            Organizations = new ObservableCollection<Organization>(DbOrganizationStore.GetAll());
            //Organizations = new SortableObservableCollection<Organization>(DbOrganizationStore.GetAll());
            //Organizations.Sort(o => o.Name);
            Rooms = new ObservableCollection<Room>(DbRoomStore.GetAll());
            Elements = new ObservableCollection<Element>(DbElementStore.GetAll());
            Devices = new ObservableCollection<Device>(DbDeviceStore.GetAll());
            Points = new ObservableCollection<MeasPoint>(DbPointStore.GetAll());
            Measurings = new ObservableCollection<Measuring>(DbMeasuringStore.GetAll());
        }

        private void OpenValue(object obj)
        {
            IsVisibilityTabControl = Visibility.Hidden;
            if (obj != null)
            {
                IsVisibilityTabControl = Visibility.Visible;

                if (obj is Organization)
                {
                    SelectedOrganization = (Organization)obj;
                    SelectedOrganizationName = SelectedOrganization.Name;
                    _originalselectedOrganizationName = SelectedOrganization.Name;
                    SelectedOrganizationDescription = SelectedOrganization.Description;
                    _originalselectedOrganizationDescription = SelectedOrganization.Description;
                    SelectedOrganizationAddress = SelectedOrganization.Address;
                    _originalselectedOrganizationAddress = SelectedOrganization.Address;
                    IsVisibilityOrganization = Visibility.Visible;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 0;
                }
                else if (obj is Room)
                {
                    SelectedRoom = (Room)obj;
                    SelectedRoomName = SelectedRoom.Name;
                    _originalselectedRoomName = SelectedRoom.Name;
                    SelectedRoomDescription = SelectedRoom.Description;
                    _originalselectedRoomDescription = SelectedRoom.Description;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Visible;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 1;
                }
                else if (obj is Element)
                {
                    SelectedElement = (Element)obj;
                    SelectedElementName = SelectedElement.Name;
                    _originalselectedElementName = SelectedElement.Name;
                    SelectedElementDescription = SelectedElement.Description;
                    _originalselectedElementDescription = SelectedElement.Description;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Visible;
                    IsVisibilityPoint = Visibility.Hidden;
                    SelectedTab = 2;
                }
                else if (obj is MeasPoint)
                {
                    SelectedPoint = (MeasPoint)obj;
                    SelectedPointName = SelectedPoint.Name;
                    _originalselectedPointName = SelectedPoint.Name;
                    SelectedPointDescription = SelectedPoint.Description;
                    _originalselectedPointDescription = SelectedPoint.Description;
                    SelectedPointMeasurings = SelectedPoint.Measurings;
                    _originalselectedPointMeasurings = SelectedPoint.Measurings;
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Visible;
                    SelectedTab = 3;
                }
            }
        }

        private bool IsChangeText(object oldValue, object newValue)
        {
            bool isChange = false;
            if (oldValue != newValue)
                isChange = true;
            return isChange;
        }

        #region SaveChangesCommand

        private LambdaCommand _saveChangesCommand;
        public LambdaCommand SaveChangesCommand => _saveChangesCommand
            ??= new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);
        private void OnSaveChangesCommandExecuted(object p)
        {
            if (SelectedValue is Organization)
            {
                if (Organizations.FirstOrDefault(o => o.Name == SelectedOrganizationName) != null)
                {
                    MessageBox.Show("Организация с таким названием уже имеется!");
                    IsChanged = false;
                    return;
                }

                var org = SelectedOrganization;
                org.Name = SelectedOrganizationName;
                org.Description = SelectedOrganizationDescription;
                org.Address = SelectedOrganizationAddress;
                SelectedValue = org;

                //DbOrganizationStore.Update(org);
                _originalselectedOrganizationName = SelectedOrganization.Name;
                _originalselectedOrganizationAddress = SelectedOrganization.Address;
                _originalselectedOrganizationDescription = SelectedOrganization.Description;
                IsChanged = false;
            }
            else if (SelectedValue is Room)
            {
                var r = ((Room)SelectedValue).Organization.Rooms.FirstOrDefault(r => r.Name == SelectedRoomName);
                if (r != null)
                {
                    MessageBox.Show("Помещение с данным названием уже имеется!");
                    IsChanged = false;
                    return;
                }

                Room room = SelectedRoom;
                room.Name = SelectedRoomName;
                room.Description = SelectedRoomDescription;
                SelectedValue = room;
                
                //DbRoomStore.Update(room);
                _originalselectedRoomName = SelectedRoom.Name;
                _originalselectedRoomDescription = SelectedRoom.Description;
                IsChanged = false;
            }
            else if (SelectedValue is Element)
            {
                var e = ((Element)SelectedValue).Room.Elements.FirstOrDefault(e => e.Name == SelectedElementName);
                if (e != null)
                {
                    MessageBox.Show("Элемент с данным названием уже имеется!");
                    IsChanged = false;
                    return;
                }

                Element element = SelectedElement;
                element.Name = SelectedElementName;
                element.Description = SelectedElementDescription;
                SelectedValue = element;
                
                //DbElementStore.Update(SelectedElement);
                _originalselectedElementName = SelectedElement.Name;
                _originalselectedElementDescription = SelectedElement.Description;
                IsChanged = false;
            }
            else if (SelectedValue is MeasPoint)
            {
                var point = ((MeasPoint)SelectedValue).Element.Points.FirstOrDefault(p => p.Name == SelectedPointName);
                if (point != null)
                {
                    MessageBox.Show("Точка с данным названием уже имеется!");
                    IsChanged = false;
                    return;
                }

                MeasPoint measPoint = SelectedPoint;
                measPoint.Name = SelectedPointName;
                measPoint.Description = SelectedPointDescription;
                measPoint.Measurings = SelectedPointMeasurings;
                SelectedValue = measPoint;

                //DbPointStore.Update(SelectedPoint);
                _originalselectedPointName = SelectedPoint.Name;
                _originalselectedPointDescription = SelectedPoint.Description;
                IsChanged = false;
            }
        }
        private bool CanSaveChangesCommandExecute(object p) => IsChanged;

        #endregion

        #region AddItemCommand

        private LambdaCommand _addItemCommand;

        public LambdaCommand AddItemCommand => _addItemCommand
            ??= new LambdaCommand(OnAddItemCommandExecuted, CanAddItemCommandExecute);

        private void OnAddItemCommandExecuted(object p)
        {
            if (SelectedValue is Organization)
            {
                var room = new Room();
                var collection = new ObservableCollection<Room>((SelectedValue as Organization).Rooms);
                room.Name = GetNewName(collection);
                room.Organization = (Organization)SelectedValue;
                ObservableCollection<Element> elements = new ObservableCollection<Element>();
                room.Elements = elements;
                ((Organization)SelectedValue).Rooms.Add(room);
                SelectedValue = room;
            }
            else if (SelectedValue is Room)
            {
                var element = new Element();
                element.Name = GetNewName((SelectedValue as Room).Elements);
                element.Room = (Room)SelectedValue;
                ObservableCollection<MeasPoint> points = new ObservableCollection<MeasPoint>();
                element.Points = points;
                ((Room)SelectedValue).Elements.Add(element);
                SelectedValue = element;
            }
            else if (SelectedValue is Element)
            {
                var point = new MeasPoint();
                point.Name = GetNewName((SelectedValue as Element).Points);
                point.Element = (Element)SelectedValue;
                ObservableCollection<Measuring> measurings = new ObservableCollection<Measuring>();
                point.Measurings = measurings;
                ((Element)SelectedValue).Points.Add(point);
                SelectedValue = point;
            }
            else if (SelectedValue is MeasPoint)
            {
                var measure = new Measuring();
                measure.MeasPoint = (MeasPoint)SelectedValue;
                ((MeasPoint)SelectedValue).Measurings.Add(measure);
                SelectedValue = measure;
            }
        }

        private bool CanAddItemCommandExecute(object p)
        {
            bool result = SelectedValue != null;
            return result;
        }

        #endregion

        #region AddOrganizationCommand

        private LambdaCommand _addOrganizationCommand;

        public LambdaCommand AddOrganizationCommand => _addOrganizationCommand
            ??= new LambdaCommand(OnAddOrganizationCommandExecuted, CanAddOrganizationCommandExecute);

        private void OnAddOrganizationCommandExecuted(object p)
        {
            if (Organizations.Count == 0)
                Organizations = new ObservableCollection<Organization>();

            Organization org = new Organization();
            org.Name = GetNewName(Organizations);
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            org.Rooms = rooms;
            Organizations.Add(org);
            SelectedValue = org;
        }

        private bool CanAddOrganizationCommandExecute(object p) => true;

        #endregion

        #region RemoveItemCommand

        private LambdaCommand _removeItemCommand;

        public LambdaCommand RemoveItemCommand => _removeItemCommand
            ??= new LambdaCommand(OnRemoveItemCommandExecuted, CanRemoveItemCommandExecute);

        private void OnRemoveItemCommandExecuted(object p)
        {
            if (SelectedValue is Organization)
            {
                Organizations.Remove((Organization)SelectedValue);
                //DbOrganizationStore.Delete(((Organization)SelectedValue).Id);
            }
            else if (SelectedValue is Room)
            {
                var room = (Room)SelectedValue;
                var org = Organizations.First(o => o.Name == room.Organization.Name);
                var rooms = org.Rooms.Where(r => r.Name != room.Name);
                org.Rooms = new ObservableCollection<Room>(rooms);
                Organizations.First(o => o.Name == org.Name).Rooms = new ObservableCollection<Room>(rooms);
                //DbRoomStore.Delete(room.Id);
            }
            else if (SelectedValue is Element)
            {
                var element = (Element)SelectedValue;
                var room = element.Room;
                var elements = room.Elements.Where(e => e.Name != element.Name);
                room.Elements = new ObservableCollection<Element>(elements);
                //DbElementStore.Delete(element.Id);
            }
            else if (SelectedValue is MeasPoint)
            {
                var point = (MeasPoint)SelectedValue;
                var element = point.Element;
                var points = element.Points.Where(p => p.Name != point.Name);
                element.Points = new ObservableCollection<MeasPoint>(points);
                //DbPointStore.Delete(point.Id);
            }
            else if (SelectedValue is Measuring)
            {
                var measuring = (Measuring)SelectedValue;
                var point = measuring.MeasPoint;
                var measurings = point.Measurings.Where(m => m.Freq != measuring.Freq);
                point.Measurings = new ObservableCollection<Measuring>(measurings);
                //DbMeasuringStore.Delete(measuring.Id);
            }
        }

        private bool CanRemoveItemCommandExecute(object p)
        {
            bool result = SelectedValue != null;
            return result;
        }

        #endregion

        #region CopyItemCommand

        private LambdaCommand _copyItemCommand;

        public LambdaCommand CopyItemCommand => _copyItemCommand
            ??= new LambdaCommand(OnCopyItemCommandExecuted, CanCopyItemCommandExecute);

        private void OnCopyItemCommandExecuted(object p)
        {
            if (SelectedValue is Organization)
            {
                var org = (Organization)SelectedValue;
                var newOrg = new Organization();
                newOrg.Name = org.Name + "-копия";
                newOrg.Address = org.Address;
                newOrg.Description = org.Description;
                newOrg.Rooms = new ObservableCollection<Room>();
                newOrg.IsSelected = true;
                newOrg.IsExpanded = true;
                Organizations.Add(newOrg);
                //DbOrganizationStore.Add(newOrg);

            }
            else if (SelectedValue is Room)
            {
                var room = (Room)SelectedValue;
                var newRoom = new Room();
                newRoom.Name = room.Name + "-копия";
                newRoom.Description = room.Description;
                newRoom.Organization = room.Organization;
                newRoom.Elements = new ObservableCollection<Element>();
                newRoom.Devices = new ObservableCollection<Device>();
                newRoom.IsSelected = true;
                newRoom.IsExpanded = true;
                room.Organization.Rooms.Add(newRoom);
                //DbRoomStore.Add(newRoom);
            }
            else if (SelectedValue is Element)
            {
                var element = (Element)SelectedValue;
                var newElement = new Element();
                newElement.Name = element.Name + "-копия";
                newElement.Description = element.Description;
                newElement.Room = element.Room;
                newElement.Points = new ObservableCollection<MeasPoint>();
                newElement.IsSelected = true;
                newElement.IsExpanded = true;
                element.Room.Elements.Add(newElement);
                //DbElementStore.Add(newElement);
            }
            else if (SelectedValue is MeasPoint)
            {
                var point = (MeasPoint)SelectedValue;
                var newPoint = new MeasPoint();
                newPoint.Name = point.Name + "-копия";
                newPoint.Description = point.Description;
                newPoint.Element = point.Element;
                newPoint.Measurings = new ObservableCollection<Measuring>();
                newPoint.IsSelected = true;
                newPoint.IsExpanded = true;
                point.Element.Points.Add(newPoint);
                //DbPointStore.Add(newPoint);
            }
        }

        private bool CanCopyItemCommandExecute(object p)
        {
            bool result = SelectedValue != null;
            return result;
        }

        #endregion

        #region SelectedNodeChangedCommand

        private LambdaCommand _selectedNodeChangedCommand;
        public LambdaCommand SelectedNodeChangedCommand => _selectedNodeChangedCommand
            ??= new LambdaCommand(OnSelectedNodeChangedCommandExecuted, CanSelectedNodeChangedCommandExecute);
        private void OnSelectedNodeChangedCommandExecuted(object p)
        {
            this.SelectedValue = p;
        }
        private bool CanSelectedNodeChangedCommandExecute(object p) => true;

        #endregion

        private string GetNewName(object collection)
        {
            string name = "";
            var t = collection.GetType().GenericTypeArguments[0].Name;

            if (t == "Organization")
            {
                name = "Новая организация";
                var list = (new List<Organization>(collection as ObservableCollection<Organization>)).FindAll(o => o.Name.Contains(name));
                name = GetNameAddedItem(name, list);
            }
            else if (t == "Room")
            {
                name = "Новое помещение";
                var list = new List<Room>(collection as ObservableCollection<Room>);
                list = list.FindAll(r => r.Name.Contains(name));
                name = GetNameAddedItem(name, list);
            }
            else if (t == "Element")
            {
                name = "Новый элемент";
                var list = (new List<Element>(collection as ObservableCollection<Element>)).FindAll(o => o.Name.Contains(name));
                name = GetNameAddedItem(name, list);
            }
            else if (t == "MeasPoint")
            {
                name = "Новая точка";
                var list = (new List<MeasPoint>(collection as ObservableCollection<MeasPoint>)).FindAll(o => o.Name.Contains(name));
                name = GetNameAddedItem(name, list);
            }
            return name;
        }

        private string GetNameAddedItem(string baseName, dynamic list)
        {
            if (((IEnumerable<object>)list).Count() > 0)
            {
                int n = 0;
                int nMax = 0;
                foreach (var item in list)
                {
                    var s = item.Name.TrimStart(baseName.ToCharArray());
                    int.TryParse(s, out n);
                    if (n > nMax)
                        nMax = n;
                }
                baseName = baseName + (nMax + 1).ToString();
            }
            return baseName;
        }
    }
}
