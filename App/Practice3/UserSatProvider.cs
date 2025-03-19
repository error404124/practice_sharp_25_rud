namespace App.Practice3;

public class UserSatProvider
{
    private List<UserActionItem> FilteredGroupTypeByData(
        UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        var startDate = request.StartDate;
        var endDate = request.EndDate;
        var filteredUserActionItems = new List<UserActionItem>();
        foreach (var userActionItem in userActionItems)
        {
            if (userActionItem.Date >= startDate && userActionItem.Date <= endDate)
            {
                filteredUserActionItems.Add(userActionItem);
            }
        }

        return filteredUserActionItems;
    }

    private DateTime FindPeriodKey(UserActionStatRequest request, UserActionItem userActionItem)
    {
        return request.DateGroupType == DateGroupTypes.Daily
            ? userActionItem.Date.Date
            : new DateTime(userActionItem.Date.Year, userActionItem.Date.Month, 1);
    }

    private void AddToDictionary(
        UserActionItem userActionItem,
        DateTime periodKey,
        Dictionary<DateTime, Dictionary<ActionTypes, int>> actionDict)
    {
        if (!actionDict.ContainsKey(periodKey))
        {
            actionDict[periodKey] = new Dictionary<ActionTypes, int>();
        }

        actionDict[periodKey].TryAdd(userActionItem.Action, 0);
        actionDict[periodKey][userActionItem.Action] += userActionItem.Count;
    }

    private (Dictionary<DateTime, Dictionary<ActionTypes, int>> dailyDict,
        Dictionary<DateTime, Dictionary<ActionTypes, int>> monthDict) GroupActionItems(UserActionStatRequest request,
            List<UserActionItem> userActionItems)
    {
        var filteredUserActionItems = FilteredGroupTypeByData(request, userActionItems);

        var dailyDict = new Dictionary<DateTime, Dictionary<ActionTypes, int>>();
        var monthDict = new Dictionary<DateTime, Dictionary<ActionTypes, int>>();
        foreach (var userActionItem in filteredUserActionItems)
        {
            var periodKey = FindPeriodKey(request, userActionItem);

            if (request.DateGroupType == DateGroupTypes.Daily)
            {
                AddToDictionary(userActionItem, periodKey, dailyDict);
            }
            else
            {
                AddToDictionary(userActionItem, periodKey, monthDict);
            }
        }

        return (dailyDict, monthDict);
    }

    private UserActionStatItem CreateStatItem(KeyValuePair<DateTime, Dictionary<ActionTypes, int>> entry,
        UserActionStatRequest request)
    {
        var statItem = new UserActionStatItem();

        statItem.StartDate = entry.Key;
        statItem.EndDate = request.DateGroupType == DateGroupTypes.Daily
            ? entry.Key
            : new DateTime(entry.Key.Year, entry.Key.Month, DateTime.DaysInMonth(entry.Key.Year, entry.Key.Month));
        statItem.ActionMetrics = entry.Value;

        return statItem;
    }


    public UserActionStatResponse GetUserActionStat(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        var (dailyDict, monthDict) = GroupActionItems(request, userActionItems);
        var userActionStatItems = new List<UserActionStatItem>();
        var selectedDict = request.DateGroupType == DateGroupTypes.Daily ? dailyDict : monthDict;

        foreach (var entry in selectedDict)
        {
            var statItem = CreateStatItem(entry, request);
            userActionStatItems.Add(statItem);
        }

        return new UserActionStatResponse { UserActionStat = userActionStatItems };
    }
}