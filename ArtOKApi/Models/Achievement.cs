namespace ArtOKApi.Models
{
    public class Achievement
    {
        public int ID { get; set; }
        public string AchievementName { get; set; }
        public string Description { get; set; }

        public  ICollection<UserAchievement> UserAchievement { get; set; }
    }
}
