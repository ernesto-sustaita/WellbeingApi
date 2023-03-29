namespace Domain.Enums
{
    public enum QuestionType
    {
        ShortAnswer = 0b_0000_0001,
        TrueFalse = 0b_0000_0010,
        Multichoice = 0b_0000_0100,
        Essay = 0b_0000_1000
    }
}
