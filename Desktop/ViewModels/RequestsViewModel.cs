// Code written by Streata Alexandra
using Common;
using Desktop.Helpers;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels
{
    public class RequestsViewModel : AbstractViewModel
    {
        #region Private members
        private readonly EventService _eventService;
        private readonly CourseService _courseService;
        #endregion


        #region Commands
        public DelegateCommand BackCommand { get; }
        public DelegateCommand SaveCommand { get; }
        #endregion


        #region ctor
        public RequestsViewModel(CourseService courseService, EventService eventService)
        {
            _courseService = courseService;
            _eventService = eventService;

            LoadCourses();
            LoadEvents();

            BackCommand = new DelegateCommand(BackToMainMenu);
            SaveCommand = new DelegateCommand(UpdateCoursesAndEvents);
        }
        #endregion


        #region Properties
        private ObservableCollection<CourseData> _coursesRequests;
        public ObservableCollection<CourseData> CoursesRequests
        {
            get => _coursesRequests;
            set => ChangeAndNotify(ref _coursesRequests, value);
        }

        private ObservableCollection<EventData> _eventsRequests;
        public ObservableCollection<EventData> EventsRequests
        {
            get => _eventsRequests;
            set => ChangeAndNotify(ref _eventsRequests, value);
        }
        #endregion


        #region Private Methods
        private void BackToMainMenu()
        {
            RegionManager.Load<MainMenu>();
        }

        private async void UpdateCoursesAndEvents()
        {
            if (CoursesRequests != null)
            {
                await _courseService.UpdateCourses(CoursesRequests.ToList());
            }
            if (EventsRequests != null)
            {
                await _eventService.UpdateEvents(EventsRequests.ToList());
            }
        }

        private async void LoadEvents()
        {
            var events = await _eventService.GetUnapprovedEvents();
            if (events != null)
            {
                EventsRequests = new ObservableCollection<EventData>(events);
            }
        }

        private async void LoadCourses()
        {
            var courses = await _courseService.GetUnapprovedCourses();
            if (courses != null)
            {
                CoursesRequests = new ObservableCollection<CourseData>(courses);
            }
        }
        #endregion
    }
}
