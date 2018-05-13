namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class Rating
    {
        public int Dev { get; }

        public int GradeScore { get; }

        public int Mean { get; }

        public Rating(int dev, int gradeScore, int mean)
        {
            Dev = dev;
            GradeScore = gradeScore;
            Mean = mean;
        }
    }
}