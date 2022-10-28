using System;
using SPOAPAKmmReceiver.Data;
using SPOAPAKmmReceiver.Entities;
using SPOAPAKmmReceiver.Interfaces;
using SPOAPAKmmReceiver.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SPOAPAKmmReceiver.Extensions;
using SPOAPAKmmReceiver.Infrastructure.Commands;
using SPOAPAKmmReceiver.Infrastructure.Commands.Base;
using SPOAPAKmmReceiver.Models;
using System.Text.Json;
using static SPOAPAKmmReceiver.Models.ReceiverMessage;
using SPOAPAKmmReceiver.Views;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Diagnostics;
using RohdeSchwarz.RsFsw;
using System.Windows.Documents;
using System.Runtime;

namespace SPOAPAKmmReceiver.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        static private bool _isSimulate = false;

        private IStore<Organization> _dBOrganization;
        private IStore<Room> _dBRoom;
        private IStore<Element> _dBElement;
        private IStore<Device> _dBDevice;
        private IStore<MeasPoint> _dBMeasPoint;
        private IStore<MeasureItem> _dBMeasueItem;
        private IStore<Levels> _dBLevels;

        private bool _isSelected;
        private bool _isChanged;
        private bool _isEnabledMSettingsPanel;
        private bool _isChangedFrequencyList;
        private bool _isCalibratedFrequenciesList = false;
        private bool _isCalibrated = false;
        private object _selectedValue;
        private Page _userPage;
        private Organization _selectedOrganization;
        private Room _selectedRoom;
        private Element _selectedElement;
        private MeasPoint _selectedPoint;
        private MeasPoint _measPoint;
        private List<MeasureItem> _measurings;
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
        private SortableObservableCollection<MeasureItem> _selectedPointMeasurings;
        private string _originalselectedOrganizationName;
        private string? _originalselectedOrganizationDescription;
        private string? _originalselectedOrganizationAddress;
        private string _originalselectedRoomName;
        private string? _originalselectedRoomDescription;
        private string _originalselectedElementName;
        private string? _originalselectedElementDescription;
        private string _originalselectedPointName;
        private string? _originalselectedPointDescription;
        private SortableObservableCollection<MeasureItem> _originalselectedPointMeasurings;
        private string _sendMessage;
        private string _recieveMessage;
        private MeasureSettings _mSettings;
        private string? _extraItemToFrequencyList;
        private CancellationTokenSource _cancelTokenSource;
        private CancellationToken _cancellationToken;
        private InstrumentSettings _receiverSettings;
        private InstrumentSettings _generatorSettings;
        private IConfiguration _configuration;
        private TcpListener _listner;
        private INetConnection _connection;
        private Dictionary<double, double> _calibratedFrequenciesDict;
        private Dictionary<double, double> _calibrationLevelDict;
        private RsFsw _specAn;

        public ObservableCollection<Organization> Organizations { get; set; }
        //public SortableObservableCollection<Organization> Organizations { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Element> Elements { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<MeasPoint> Points { get; set; }
        public ObservableCollection<MeasureItem> Measurings { get; set; }
        public ObservableCollection<Levels> Levels { get; set; }

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
        public bool IsEnabledMSettingsPanel
        {
            get => _isEnabledMSettingsPanel;
            set => Set(ref _isEnabledMSettingsPanel, value);
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
                IsChanged = IsChangeValue(_originalselectedOrganizationName, value);
            }
        }
        public string? SelectedOrganizationAddress
        {
            get => _selectedOrganizationAddress;
            set
            {
                Set(ref _selectedOrganizationAddress, value);
                IsChanged = IsChangeValue(_originalselectedOrganizationAddress, value);
            }
        }
        public string? SelectedOrganizationDescription
        {
            get => _selectedOrganizationDescription;
            set
            {
                Set(ref _selectedOrganizationDescription, value);
                IsChanged = IsChangeValue(_originalselectedOrganizationDescription, value);
            }
        }
        public string SelectedRoomName
        {
            get => _selectedRoomName;
            set
            {
                Set(ref _selectedRoomName, value);
                IsChanged = IsChangeValue(_originalselectedRoomName, value);
            }
        }
        public string? SelectedRoomDescription
        {
            get => _selectedRoomDescription;
            set
            {
                Set(ref _selectedRoomDescription, value);
                IsChanged = IsChangeValue(_originalselectedRoomDescription, value);
            }
        }
        public string SelectedElementName
        {
            get => _selectedElementName;
            set
            {
                Set(ref _selectedElementName, value);
                IsChanged = IsChangeValue(_originalselectedElementName, value);
            }
        }
        public string? SelectedElementDescription
        {
            get => _selectedElementDescription;
            set
            {
                Set(ref _selectedElementDescription, value);
                IsChanged = IsChangeValue(_originalselectedElementDescription, value);
            }
        }
        public string SelectedPointName
        {
            get => _selectedPointName;
            set
            {
                Set(ref _selectedPointName, value);
                IsChanged = IsChangeValue(_originalselectedPointName, value);
            }
        }
        public string? SelectedPointDescription
        {
            get => _selectedPointDescription;
            set
            {
                Set(ref _selectedPointDescription, value);
                IsChanged = IsChangeValue(_originalselectedPointDescription, value);
            }
        }

        public SortableObservableCollection<MeasureItem> SelectedPointMeasurings
        {
            get => _selectedPointMeasurings;
            set 
            {
                Set(ref _selectedPointMeasurings, value);
                IsChanged = IsChangeValue(_originalselectedPointMeasurings, value);
            }
        }

        public string SendMessage
        {
            get => _sendMessage;
            set => Set(ref _sendMessage, value);
        }
        public string RecieveMessage
        {
            get => _recieveMessage;
            set => Set(ref _recieveMessage, value);
        }

        public IStore<Organization> DbOrganizationStore { get; set; }
        public IStore<Room> DbRoomStore { get; set; }
        public IStore<Element> DbElementStore { get; set; }
        public IStore<MeasPoint> DbPointStore { get; set; }
        public IStore<Device> DbDeviceStore { get; set; }
        public IStore<MeasureItem> DbMeasuringStore { get; set; }
        public IStore<Levels> DbLevelsStore { get; set; }

        public MeasureSettings MSettings
        {
            get => _mSettings;
            set => Set(ref _mSettings, value);
        }

        public string? ExtraItemToFrequencyList
        {
            get => _extraItemToFrequencyList;
            set => Set(ref _extraItemToFrequencyList, value);
        }

        public bool IsChangedFrequencyList
        {
            get => _isChangedFrequencyList;
            set => Set(ref _isChangedFrequencyList, value);
        }

        public ICommand Send { get; set; }

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
            IStore<MeasureItem> dBMeasuring,
            IStore<Levels> dBLevels,
            IConfiguration configuration,
            INetConnection netConnection)
        {
            DbOrganizationStore = dBOrganization;
            DbRoomStore = dBRoom;
            DbElementStore = dBElement;
            DbDeviceStore = dBDevice;
            DbPointStore = dBMeasPoint;
            DbMeasuringStore = dBMeasuring;
            DbLevelsStore = dBLevels;

            _connection = netConnection;

#if DEBUG
            IEnumerable<Organization> organizationsInDb = new List<Organization>();
            organizationsInDb = DbOrganizationStore.GetAll();

            var c = organizationsInDb.Count();

            foreach (var org in TestData.TestDataOrganizations)
            {
                if (c == 0 || (organizationsInDb.FirstOrDefault(o => o.Name == org.Name) == null))
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
            Measurings = new ObservableCollection<MeasureItem>(DbMeasuringStore.GetAll());
            Levels = new ObservableCollection<Levels>(DbLevelsStore.GetAll());

            MSettings = new MeasureSettings();

            _configuration = configuration;

            Send = new LambdaCommand(OnSendExecuted, CanSendMessageExecute);

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
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
                    IsEnabledMSettingsPanel = false;
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
                    IsEnabledMSettingsPanel = true;
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
                    IsEnabledMSettingsPanel = true;
                }
                else if (obj is MeasPoint)
                {
                    SelectedPoint = (MeasPoint)obj;
                    SelectedPointName = SelectedPoint.Name;
                    _originalselectedPointName = SelectedPoint.Name;
                    SelectedPointDescription = SelectedPoint.Description;
                    _originalselectedPointDescription = SelectedPoint.Description;
                    SelectedPointMeasurings = new SortableObservableCollection<MeasureItem>(SelectedPoint.MeasureItems);
                    SelectedPointMeasurings.Sort(l => l.Freq);
                    _originalselectedPointMeasurings = new SortableObservableCollection<MeasureItem>(SelectedPoint.MeasureItems);
                    _originalselectedPointMeasurings.Sort(l => l.Freq);
                    IsVisibilityOrganization = Visibility.Hidden;
                    IsVisibilityRoom = Visibility.Hidden;
                    IsVisibilityElement = Visibility.Hidden;
                    IsVisibilityPoint = Visibility.Visible;
                    SelectedTab = 3;
                    IsEnabledMSettingsPanel = true;
                }
            }
        }

        private bool IsChangeValue(object oldValue, object newValue)
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

                DbOrganizationStore.Update(org);
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

                DbRoomStore.Update(room);
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

                DbElementStore.Update(SelectedElement);
                _originalselectedElementName = SelectedElement.Name;
                _originalselectedElementDescription = SelectedElement.Description;
                IsChanged = false;
            }
            else if (SelectedValue is MeasPoint)
            {
                MessageBoxResult result = MessageBoxResult.No;
                var point = ((MeasPoint)SelectedValue).Element.Points.FirstOrDefault(p => p.Name == SelectedPointName);
                if (point != null)
                {
                    result = MessageBox.Show("Точка с данным названием уже имеется!\nСохранить изменения?", "Внимание!", MessageBoxButton.YesNo);                    
                }

                if (result == MessageBoxResult.Yes)
                {
                    MeasPoint measPoint = SelectedPoint;
                    measPoint.Name = SelectedPointName;
                    measPoint.Description = SelectedPointDescription;
                    measPoint.MeasureItems = SelectedPointMeasurings;
                    SelectedValue = measPoint;

                    DbPointStore.Update(SelectedPoint);
                    _originalselectedPointName = SelectedPoint.Name;
                    _originalselectedPointDescription = SelectedPoint.Description;
                    _originalselectedPointMeasurings = SelectedPointMeasurings;
                    IsChanged = false;
                }
                else
                    return;
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
                var collection = new ObservableCollection<Element>((SelectedValue as Room).Elements);
                element.Name = GetNewName(collection);
                element.Room = (Room)SelectedValue;
                ObservableCollection<MeasPoint> points = new ObservableCollection<MeasPoint>();
                element.Points = points;
                ((Room)SelectedValue).Elements.Add(element);
                SelectedValue = element;
            }
            else if (SelectedValue is Element)
            {
                var point = new MeasPoint();
                var collection = new ObservableCollection<MeasPoint>((SelectedValue as Element).Points);
                point.Name = GetNewName(collection);
                point.Element = (Element)SelectedValue;
                ObservableCollection<MeasureItem> measurings = new ObservableCollection<MeasureItem>();
                point.MeasureItems = measurings;
                ((Element)SelectedValue).Points.Add(point);
                SelectedValue = point;
            }
            else if (SelectedValue is MeasPoint)
            {
                var measure = new MeasureItem();
                measure.MeasPoint = (MeasPoint)SelectedValue;
                ((MeasPoint)SelectedValue).MeasureItems.Add(measure);
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
            else if (SelectedValue is MeasureItem)
            {
                var measuring = (MeasureItem)SelectedValue;
                var point = measuring.MeasPoint;
                var measurings = point.MeasureItems.Where(m => m.Freq != measuring.Freq);
                point.MeasureItems = new ObservableCollection<MeasureItem>(measurings);
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
                newPoint.MeasureItems = new ObservableCollection<MeasureItem>();
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

        #region AutoCalculationFrequencyRowCommand

        private LambdaCommand _autoCalculationFrequencyRowCommand;
        public LambdaCommand AutoCalculationFrequencyRowCommand => _autoCalculationFrequencyRowCommand
            ??= new LambdaCommand(OnAutoCalculationFrequencyRowCommandExecuted, CanAutoCalculationFrequencyRowCommandExecute);
        private void OnAutoCalculationFrequencyRowCommandExecuted(object p)
        {
            MSettings.GetFrequencyList();
            IsChangedFrequencyList = true;
        }
        private bool CanAutoCalculationFrequencyRowCommandExecute(object p) => true;

        #endregion

        #region AddItemToFrequencyListCommand

        private LambdaCommand _addItemToFrequencyListCommand;
        public LambdaCommand AddItemToFrequencyListCommand => _addItemToFrequencyListCommand
            ??= new LambdaCommand(OnAddItemToFrequencyListCommandExecuted, CanAddItemToFrequencyListCommandExecute);
        private void OnAddItemToFrequencyListCommandExecuted(object p)
        {
            MSettings.FrequencyList.Add(Convert.ToDouble(ExtraItemToFrequencyList));
            MSettings.FrequencyList.Sort(l => l);
            IsChangedFrequencyList = true;
        }
        private bool CanAddItemToFrequencyListCommandExecute(object p)
        {
            double f;            
            bool result = false;

            if (_extraItemToFrequencyList is not null)
            {
                if (_extraItemToFrequencyList.Contains('.'))
                    _extraItemToFrequencyList = _extraItemToFrequencyList.Replace('.', ',');                

                result = Double.TryParse(_extraItemToFrequencyList, out f);
                if (result)
                    if (!MSettings.FrequencyList.Contains(f))
                        result = true;
                    else result = false;
            }
            
            return result;
        }

        #endregion

        #region ApplyMeasurementSettingsCommand - Команда открытия окна настроек

        private LambdaCommand _applyMeasurementSettingsCommand;
        public LambdaCommand ApplyMeasurementSettingsCommand => _applyMeasurementSettingsCommand
            ??= new LambdaCommand(OnApplyMeasurementSettingsCommandExecuted, CanApplyMeasurementSettingsCommandExecute);
        private void OnApplyMeasurementSettingsCommandExecuted(object p)
        {
            if (MSettings.FrequencyList.Count >= 5)
            {
                StartListen();

                var message = new ReceiverMessage(WorkMode.ApplyMeasureSettings);
                message.FromMeasureSettings(MSettings);
                SendMessage = JsonSerializer.Serialize(message);
                SendToClient(SendMessage);
            }
            else
            {
                MessageBox.Show("Задайте список частот!");
            }
            
        }
        private bool CanApplyMeasurementSettingsCommandExecute(object p) => true;

        #endregion

        #region OpenSettingsWindowCommand - Команда открытия окна настроек

        private LambdaCommand _openSettingsWindowCommand;
        public LambdaCommand OpenSettingsWindowCommand => _openSettingsWindowCommand
            ??= new LambdaCommand(OnOpenSettingsWindowCommandExecuted, CanOpenSettingsWindowCommandExecute);
        private void OnOpenSettingsWindowCommandExecuted(object p)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
        private bool CanOpenSettingsWindowCommandExecute(object p) => true;

        #endregion

        #region RunCalibrationCommand - Команда калибровки

        private LambdaCommand _runCalibrationCommand;
        public LambdaCommand RunCalibrationCommand => _runCalibrationCommand 
            ??= new LambdaCommand(OnRunCalibrationCommandExecuted, CanRunCalibrationCommandExecute);
        private void OnRunCalibrationCommandExecuted(object p)
        {
            bool _isOk = false;


            if (MSettings.FrequencyList.Count >= 5)
            {
                if(SelectedPointMeasurings is null)
                    SelectedPointMeasurings = new SortableObservableCollection<MeasureItem>();

                if (SelectedPointMeasurings.Count == 0)
                    _isOk = true;
                else
                {
                    var result = MessageBox.Show("Удалить предыдущие измерения?", "Внимание!", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedPointMeasurings = new SortableObservableCollection<MeasureItem>();
                        _isOk = true;
                    }
                    else if (result == MessageBoxResult.No)
                        _isOk = true;
                    else
                        _isOk = false;
                }                
            }
            else
            {
                MessageBox.Show("Задайте список частот!");
            }            

            if (_isOk == true)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                GetInstrumentsSettings();

                if (InitializeReciever())
                {
                    List<double> freqList;
                    List<(double, double)> measureList = new List<(double, double)>();
                    
                    //if (SelectedPoint.MeasureItems is null)
                    //    SelectedPoint.MeasureItems = new List<MeasureItem>();

                    if (_isCalibratedFrequenciesList)
                    {
                        freqList = new List<double>();
                        _calibratedFrequenciesDict.Values.ToList().ForEach(freq => freqList.Add(freq));
                    }
                    else
                    {
                        freqList = new List<double>();
                        MSettings.FrequencyList.ToList().ForEach(freq => freqList.Add(freq * 1.0e+6));
                    }

                    StartListen();
                    var message = new ReceiverMessage(WorkMode.Сalibration);
                    message.FromMeasureSettings(MSettings);
                    message.InstrAddress = _generatorSettings.InstrAddress;
                    SendMessage = JsonSerializer.Serialize(message);
                    SendToClient(SendMessage);
                    Task<List<(double, double)>> task = new Task<List<(double, double)>>(() => Measuring(freqList));
                    task.Start();
                    measureList = task.Result;
                    
                    foreach (var freq in freqList)
                    {                                               
                        var meas = measureList.FindAll(m => m.Item1 == freq / 1.0e+6);
                        List<Levels> levels = new List<Levels>();
                        meas.ToList().ForEach(m => levels.Add(new Levels { P1 = m.Item2}));
                        MeasureItem measureItem = new MeasureItem();
                        measureItem.Levels = new List<Levels>(levels);
                        
                        double level = 0.0;                        
                        foreach(var m in meas)
                        {                            
                            level = level + m.Item2;                            
                        }
                        measureItem.Freq = freq / 1.0e+6;
                        measureItem.P1 = level / 10.0;
                        SelectedPointMeasurings.Add(measureItem);                        
                    }
                    _isCalibrated = true;
                }
                else
                    MessageBox.Show("Ошибка инициализации приёмника!");
            }
        }
        private bool CanRunCalibrationCommandExecute(object p) => true;

        #endregion

        #region RunFrequencyCalibrationCommand - Команда калибровки частоты

        private LambdaCommand _runFrequencyCalibrationCommand;
        public LambdaCommand RunFrequencyCalibrationCommand => _runFrequencyCalibrationCommand
            ??= new LambdaCommand(OnRunFrequencyCalibrationCommandExecuted, CanRunFrequencyCalibrationCommandExecute);
        private void OnRunFrequencyCalibrationCommandExecuted(object p)
        {
            bool _isOk = false;


            if (MSettings.FrequencyList.Count >= 5)
            {
                if (SelectedPointMeasurings.Count == 0)
                    _isOk = true;
                else
                {
                    var result = MessageBox.Show("Удалить предыдущие измерения?", "Внимание!", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedPointMeasurings.Clear();
                        _isOk = true;
                    }
                    else if (result == MessageBoxResult.No)
                        _isOk = true;
                    else
                        _isOk = false;
                }
            }
            else
            {
                MessageBox.Show("Задайте список частот!");
            }

            if (_isOk == true)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                GetInstrumentsSettings();
                
                if (InitializeReciever())
                {
                    StartListen();
                    var message = new ReceiverMessage(WorkMode.Сalibration);
                    message.FromMeasureSettings(MSettings);
                    message.InstrAddress = _generatorSettings.InstrAddress;
                    SendMessage = JsonSerializer.Serialize(message);
                    SendToClient(SendMessage);
                    FrequencyCalibrate();
                }
                else
                    MessageBox.Show("Ошибка инициализации приёмника!");
            }
        }
        private bool CanRunFrequencyCalibrationCommandExecute(object p) => true;

        #endregion

        #region RunCalibrationCommand - Команда измерения

        private LambdaCommand _runMeasuringCommand;
        public LambdaCommand RunMeasuringCommand => _runMeasuringCommand
            ??= new LambdaCommand(OnRunMeasuringCommandExecuted, CanRunMeasuringCommandExecute);
        private void OnRunMeasuringCommandExecuted(object p)
        {
            Console.WriteLine("---ИЗМЕРЕНЕИЕ---");
            
            CancellationTokenSource cts = new CancellationTokenSource();
            GetInstrumentsSettings();

            if (InitializeReciever())
            {
                List<double> freqList;
                List<(double, double)> measureList = new List<(double, double)>();

                freqList = new List<double>();
                SelectedPointMeasurings.ToList().ForEach(o => freqList.Add(o.Freq * 1.0e+6));

                StartListen();
                Task messageTask = new Task(() => MessageBox.Show("Закройте дверь!"));
                messageTask.Start();
                //MessageBox.Show("Закройте дверь!");
                Console.WriteLine("Закройте дверь!");
                var message = new ReceiverMessage(WorkMode.Measuring);
                message.FromMeasureSettings(MSettings);
                message.InstrAddress = _generatorSettings.InstrAddress;
                SendMessage = JsonSerializer.Serialize(message);
                SendToClient(SendMessage);
                Console.WriteLine("Отправлено сообщение: " + SendMessage);
                Thread.Sleep(60000);

                Task<List<(double, double)>> task = new Task<List<(double, double)>>(() => Measuring(freqList));
                task.Start();
                measureList = task.Result;

                foreach (var freq in freqList)
                {
                    MeasureItem mm;
                    var meas = measureList.FindAll(m => m.Item1 == freq / 1.0e+6);
                    double aLevel = 0.0;
                    List<double> mLevels = new List<double>();
                    List<Levels> lLevels = new List<Levels>(SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).Levels);
                    meas.ToList().ForEach(m => mLevels.Add(m.Item2));

                    int i = 0;
                    List<double> qiList = new List<double>();
                    double q = 0.0;
                    foreach (var level in lLevels)
                    {
                        level.P2 = mLevels.ToArray()[i];
                        qiList.Add(level.P1 - level.P2);
                        q = q + (level.P1 - level.P2);
                        aLevel = aLevel + level.P2;
                        i++;
                    }
                    q = q / 10.0;
                    aLevel = aLevel / 10.0;

                    double sn = 0.0;
                    foreach (var qi in qiList)
                    {
                        sn = q - qi;
                    }
                    sn = Math.Sqrt(sn / 9.0);
                    double sx = sn / Math.Sqrt(10.0);
                    double dx = 2.26 * sx;

                    SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).E = q.ToString() + "±" + dx.ToString();
                    SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).AverageE = q;
                    SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).P2 = aLevel;
                    SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).DX = dx;
                    SelectedPointMeasurings.FirstOrDefault(o => o.Freq == freq / 1.0e+6).Levels = lLevels;
                }
            }
            else
            {
                MessageBox.Show("Ошибка инициализации приёмника!");
                Console.WriteLine("Ошибка инициализации приёмника!");
            }
        }
        private bool CanRunMeasuringCommandExecute(object p) => _isCalibrated;

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

        private void OnSendExecuted(object p)
        {
            //SendMessage = JsonSerializer.Serialize(MSettings);
            SendToClient(SendMessage); 
        }
        private bool CanSendMessageExecute(object arg) => true;

        private void GetAccessToClientProgram(CancellationToken token)
        {
            GetInstrumentsSettings();

            while (!token.IsCancellationRequested)
            {
                if (_listner is null)
                    _listner = new TcpListener(new IPEndPoint(IPAddress.Parse(_receiverSettings.IpAddress), _receiverSettings.Port));
                _listner.Start();
                while (true)
                {
                    TcpClient client = _listner.AcceptTcpClient();
                    StreamReader sr = new StreamReader(client.GetStream());

                    Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                    client.Close();
                }
            }
            if (token.IsCancellationRequested)
            {
                _listner.Stop();
            }

            /*TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11001));
            listner.Start();
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                
                Execute(sr.ReadLine());   //<---------- самописная функция Execute, что-то выполняет с пришедшими данными

                client.Close();
            }*/
        }

        /// <summary>
        /// Посылает сообщение приложению-клиенту
        /// </summary>
        /// <param name="Massage">Передаваемое сообщение</param>
        private void SendToClient(string Massage)
        {
            GetInstrumentsSettings();
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(_generatorSettings.IpAddress), _generatorSettings.Port));
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine(Massage);
            }
            catch
            {
                Console.WriteLine("Ошибка при подключении к Server.exe");
            }
            client.Close();
        }

        private void Execute(string Data)
        {
            //Выводим принятое сообщение на экран
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                this.RecieveMessage = Data;
                var m = JsonSerializer.Deserialize<TransmitterMessage>(Data);
                if(m.Mode == WorkMode.Сalibration)
                {
                    
                    
                }
            }
            ));
        }

        private void StartListen()
        {
            _cancelTokenSource = new CancellationTokenSource();
            Task task = new Task(() =>
            {
                GetAccessToClientProgram(_cancellationToken);
                
            }, _cancelTokenSource.Token, TaskCreationOptions.AttachedToParent);
            task.Start();

            /*Thread AccessToClientProgram = new Thread(GetAccessToClientProgram);
            AccessToClientProgram.IsBackground = true;
            AccessToClientProgram.Start();*/
        }

        private void GetInstrumentsSettings()
        {
            _receiverSettings = _configuration.GetSection("InstrumentSettings:Receiver").Get<InstrumentSettings>();
            _generatorSettings = _configuration.GetSection("InstrumentSettings:Generator").Get<InstrumentSettings>();
        }

        private bool InitializeReciever()
        {
            var resourceString = _receiverSettings.InstrAddress;

            Console.WriteLine("---ИНИЦИАЛИЗАЦИЯ ПРИЁМНИКА---");
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                _specAn = new RsFsw(resourceString, true, true, "Simulate = " + _isSimulate.ToString());
                Console.WriteLine("Приёмник проинициализирован по адрессу {0}. Симуляция - {1}", resourceString, _isSimulate);
                _specAn.Utilities.InstrumentStatusChecking = true;
                _specAn.System.Display.Update.Set(true);
                _specAn.Initiate.Continuous.Set(true);
                _specAn.Sense.Bandwidth.Resolution.Set(MSettings.Rbw * 1.0e+3);
                Console.WriteLine("RBW: " + MSettings.Rbw * 1.0e+3 + "кГц");
                _specAn.Sense.Bandwidth.Video.Set(MSettings.Rbw * 1.0e+3);
                Console.WriteLine("VBW: " + MSettings.Rbw * 1.0e+3 + "кГц");
                _specAn.Sense.Window.Detector.Function.Set(DetectorBenum.POSitive, WindowRepCap.Nr1, TraceRepCap.Tr1);
                _specAn.Sense.Window.Detector.Function.Set(DetectorBenum.AVERage, WindowRepCap.Nr1, TraceRepCap.Tr2);
                _specAn.Sense.Frequency.Span.Set(MSettings.Span * 1.0e+3);
                Console.WriteLine("Полоса обзора: " + MSettings.Span * 1.0e+3 + "кГц");
                _specAn.Display.Window.Trace.Mode.Set(TraceModeCenum.AVERage);
                _specAn.Input.Attenuation.Set(MSettings.Attenuation);
                Console.WriteLine("Ослабление: " + MSettings.Attenuation + "дБ");
                _specAn.Input.Gain.State.Set(MSettings.IsPreamp);
                Console.WriteLine("Предусилитель вкл.: " + MSettings.IsPreamp);
                _specAn.Calculate.Unit.Power.Set(PowerUnitEnum.DBM);
                _specAn.Format.Data.Set(DataFormatEnum.ASCii);
                _specAn.Initiate.ImmediateAndWait();
                _specAn.Display.Window.Subwindow.Trace.Mode.Set(TraceModeCenum.WRITe, WindowRepCap.Nr1, SubWindowRepCap.Default, RohdeSchwarz.RsFsw.TraceRepCap.Tr1);
                _specAn.Display.Window.Subwindow.Trace.Mode.Set(TraceModeCenum.AVERage, WindowRepCap.Nr1, SubWindowRepCap.Default, RohdeSchwarz.RsFsw.TraceRepCap.Tr2);

                Console.WriteLine("Время инициализации приёмника: " + stopwatch.ElapsedMilliseconds + "мс");

                return true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
                Console.WriteLine("Ошибка: " + ex.Message);
                return false;
            }
        }

        private void FrequencyCalibrate()
        {
            Console.WriteLine("---КАЛИБРОВКА ЧАСТОТЫ---");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                _calibratedFrequenciesDict = new Dictionary<double, double>();

                foreach (var freq in MSettings.FrequencyList)
                {
                    _specAn.Sense.Frequency.Center.Set(freq * 1.0e+6);
                    Console.WriteLine("Частота: " + freq + "МГц");
                    _specAn.Calculate.Marker.Maximum.Peak.Set();

                    _specAn.Calculate.Marker.Trace.Set(2, WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                    Thread.Sleep(MSettings.TimeOfEmission * 1000);
                    _specAn.Calculate.Marker.Maximum.Peak.Set(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                    double m2x = _specAn.Calculate.Marker.X.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                    Console.WriteLine("Измеренная частота: " + m2x / 1e+6 + "МГц");

                    //specAn.Calculate.Marker.Maximum.Peak.Set(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                    //double m1x = specAn.Calculate.Marker.X.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);

                    //var trace = specAn.Trace.Data.Get(TraceNumberEnum.TRACe1);
                    //var x = specAn.Calculate.Marker.X.Get();
                    //var y = specAn.Calculate.Marker.Y.Get();

                    _calibratedFrequenciesDict.Add(freq, m2x);

                }

                _isCalibratedFrequenciesList = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            stopwatch.Stop();
            Console.WriteLine("Время калибровки частоты: " + stopwatch.ElapsedMilliseconds + "мс");
        }

        private List<(double, double)> Measuring(List<double> frequencyList)
        {
            int d = 10;            
            double y = 0.0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            List<(double, double)> list = new List<(double, double)>();

            foreach (var freq in frequencyList)
            {
                _specAn.Initiate.Continuous.Set(true);
                _specAn.Sense.Frequency.Center.Set(freq);
                Console.WriteLine("Частота: " + freq + "МГц");
                _specAn.Calculate.Marker.Trace.Set(1, WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                _specAn.Calculate.Marker.X.Set(freq);                
                y = 0.0;

                for (int i = 0; i < d; i++)
                {
                    Thread.Sleep(MSettings.TimeOfEmission * 1000 / d - 1);
                    y = _specAn.Calculate.Marker.Y.Get(WindowRepCap.Nr1, RohdeSchwarz.RsFsw.MarkerRepCap.Nr1);
                    Console.WriteLine("Измеренное значение: " + y + "дБм");
                    list.Add(new (freq / 1.0e+6, y));
                }                
            }

            stopwatch.Stop();
            Console.WriteLine("Время измерения: " + stopwatch.ElapsedMilliseconds + "мс");

            return list;
        }        
    }
}
