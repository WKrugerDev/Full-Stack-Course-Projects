using FeedbackApp.Models;
using System.Collections.Generic;
using System.Text.Json;
using Blazored.LocalStorage;

namespace FeedbackApp.Services
{
    public class FeedbackService
    {
        private const string FeedbackStorageKey = "feedbackList";
        private readonly ILocalStorageService _localStorage;
        //private readonly List<Models.Feedback> feedbackList = new();
        
        public FeedbackService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        public async Task AddFeedbackAsync(Feedback feedback)
        {
            feedback.SubmittedAt = DateTime.Now;
            var feedbackList = await GetAllFeedbackAsync();
            feedbackList.Add(feedback);
        }
        public async Task<List<Feedback>> GetAllFeedbackAsync()
        {
            var feedbackList = await _localStorage.GetItemAsync<List<Models.Feedback>>(FeedbackStorageKey);
            return feedbackList ?? new List<Models.Feedback>();
        }
    }
}

