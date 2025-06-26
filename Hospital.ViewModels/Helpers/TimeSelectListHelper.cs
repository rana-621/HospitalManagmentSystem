using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.ViewModels.Helpers
{
    public static class TimeSelectListHelper
    {
        public static List<SelectListItem> GetMorningShiftStartTimes()
        {
            return GenerateHourList(6, 12); // من 6 لـ 12
        }

        public static List<SelectListItem> GetMorningShiftEndTimes()
        {
            return GenerateHourList(7, 13); // من 7 لـ 1
        }

        public static List<SelectListItem> GetAfternoonShiftStartTimes()
        {
            return GenerateHourList(13, 17); // من 1 لـ 5
        }

        public static List<SelectListItem> GetAfternoonShiftEndTimes()
        {
            return GenerateHourList(14, 18); // من 2 لـ 6
        }

        private static List<SelectListItem> GenerateHourList(int start, int end)
        {
            var items = new List<SelectListItem>();
            for (int hour = start; hour <= end; hour++)
            {
                items.Add(new SelectListItem
                {
                    Value = hour.ToString(),
                    Text = $"{hour}:00"
                });
            }
            return items;
        }
    }
}