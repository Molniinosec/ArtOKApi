namespace ArtOKApi.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int IDUserDialog { get; set; }
        public string Message1 { get; set; }
        public Nullable<System.DateTime> TimeOfSend { get; set; }
        public string FilePath { get; set; }
        public Nullable<bool> IsEdit { get; set; }

        public  DialogUser DialogUser { get; set; }
    }
}
