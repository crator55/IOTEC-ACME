namespace IOTEC_ACME.RatesNameSpace
{
    internal interface IRates
    {
        int GetNightWeekDayRate();
        int GetNormalWeekDayRate();
        int GetExtraWeekDayRate();
        int GetNightWeekendDayRate();
        int GetExtraWeekendDayRate();
        int GetNormalWeekendDayRate();

    }
}
