namespace Battlerite.NET.Rest.DTOs.Players.Attributes.Stats
{
    public class RatingBuilder
    {
        public int Dev { get; set; }

        public int GradeScore { get; set; }

        public int Mean { get; set; }

        public Rating Build()
        {
            return new Rating(Dev, GradeScore, Mean);
        }
    }
}