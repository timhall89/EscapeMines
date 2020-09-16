using System.ComponentModel;
namespace EscapeMinesLib
{
    public enum Result
    {
        [Description("The turtle has found the exit point.")]
        Success,
        [Description("The turtle has unfotunately hit a mine.")]
        MineHit,
        [Description("The turlte has sadly fallen off the board.")]
        OffBoard,
        [Description("Nothing has happeneded to the turtle, but it is still in danger.")]
        StillInDanger,
    }

    public static class ResultExstensions
    {
        public static string GetDescription(this Result result)
        {
            var attrs = typeof(Result).GetField(result.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
            return null;
        }
    }
}
