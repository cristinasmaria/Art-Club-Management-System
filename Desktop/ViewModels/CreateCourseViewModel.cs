// Code written by Popescu Cristina
using Common;
using Desktop.Helpers;
using Desktop.Models;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels
{
    public class CreateCourseViewModel : AbstractViewModel
    {
        #region Private members
        private readonly TrainerService _trainerService;
        private readonly RoomService _roomService;
        private readonly AppRegionManager _regionManager;
        private readonly CourseService _courseService;
        #endregion


        #region Commands
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand BackToMainMenuCommand { get; }
        #endregion


        #region ctor
        public CreateCourseViewModel(TrainerService trainerService, RoomService roomService, CourseService courseService, AppRegionManager regionManager) : base()
        {
            _roomService = roomService;
            _trainerService = trainerService;
            _regionManager = regionManager;
            _courseService = courseService;

            SetSaveButtonName();
            LoadTrainers();
            LoadRooms();

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            SaveCommand = new DelegateCommand(Save);
            BackToMainMenuCommand = new DelegateCommand(BackToMainMenu);
        }
        #endregion


        #region Properties
        private string _nameCourseInput;
        public string NameCourseInput
        {
            get => _nameCourseInput;
            set => ChangeAndNotify(ref _nameCourseInput, value);
        }

        private ObservableCollection<UserData> _trainers;
        public ObservableCollection<UserData> Trainers
        {
            get => _trainers;
            set => ChangeAndNotify(ref _trainers, value);
        }

        private UserData _selectedTrainer;
        public UserData SelectedTrainer
        {
            get => _selectedTrainer;
            set => ChangeAndNotify(ref _selectedTrainer, value);
        }

        private ObservableCollection<RoomData> _rooms;
        public ObservableCollection<RoomData> Rooms
        {
            get => _rooms;
            set => ChangeAndNotify(ref _rooms, value);
        }

        private RoomData _selectedRoom;
        public RoomData SelectedRoom
        {
            get => _selectedRoom;
            set => ChangeAndNotify(ref _selectedRoom, value);
        }

        private string _saveButtonName;
        public string SaveButtonName
        {
            get => _saveButtonName;
            set => ChangeAndNotify(ref _saveButtonName, value);
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => ChangeAndNotify(ref _startDate, value);
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => ChangeAndNotify(ref _endDate, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => ChangeAndNotify(ref _message, value);
        }
        #endregion


        #region Private Methods
        private void SetSaveButtonName()
        {
            if (CurrentUser.IsTrainer)
            {
                SaveButtonName = "Send request to admin";
            }
            else
            {
                SaveButtonName = "Save";
            }
        }

        private async void LoadTrainers()
        {
			var trainers = await _trainerService.GetTrainersAsync();
			if (trainers != null)
			{
				Trainers = new ObservableCollection<UserData>(trainers);

                if (CurrentUser.IsTrainer)
                {
                    var currentTrainer = Trainers.FirstOrDefault(t => t.TrainerId == CurrentUser.UserData.TrainerId);
                    SelectedTrainer = currentTrainer;
                }
            }
        }

        private async void LoadRooms()
        {
			var rooms = await _roomService.GetRoomsAsync();
			if (rooms != null)
			{
				Rooms = new ObservableCollection<RoomData>(rooms);
			}
        }

        private void BackToMainMenu()
        {
            _regionManager.Load<MainMenu>();
        }

        private async void Save()
        {
            CourseData newCourse = new CourseData
            {
                Name = NameCourseInput,
                RoomId = SelectedRoom.RoomId,
                TrainerId = SelectedTrainer.TrainerId,
                StartTime = StartDate,
                EndTime = EndDate,
                IsEnabled = true,
                IsApproved = CurrentUser.IsAdmin
            };

            if (!CheckIfStartAndEndDateAreValid())
            {
                return;
            }

            var courseSaved = await _courseService.SaveNewCourse(newCourse);

            if (courseSaved)
            {
                Message = "Course added successfully!";
            }
            else
            {
                Message = "Failed to add course!";
            }
        }

        private bool CheckIfStartAndEndDateAreValid()
        {
            if (StartDate < DateTime.Now)
            {
                Message = "The start date should not be in the past";
                return false;
            }
            if (StartDate > EndDate)
            {
                Message = "The end date should not be before the start date";
                return false;
            }

            Message = String.Empty;
            return true;
        }
        #endregion
    }
}
